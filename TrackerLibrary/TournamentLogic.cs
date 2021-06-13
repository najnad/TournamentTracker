using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        /// <summary>
        /// Creates all rounds of the tournament.
        /// </summary>
        /// <param name="model">A TournamentModel object</param>
        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = OrderRandomizer(model.EnteredTeams);
            int rounds = FindNumOfRounds(randomizedTeams.Count);
            int byes = NumOfByes(rounds, randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));

            CreateRemainingRounds(model, rounds);
        }

        public static void UpdateTournamentResults(TournamentModel model)
        {
            int startingRound = model.CheckCurrentRound();
            List<MatchupModel> toScore = new List<MatchupModel>();
            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel rm in round) 
                {
                    if (rm.Winner == null && (rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
                    {
                        toScore.Add(rm);
                    }
                }
            }

            ScoreMatchups(toScore);

            AdvanceWinners(toScore, model);

            toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));

            int endingRound = model.CheckCurrentRound();

            if (endingRound > startingRound)
            {
                // Send email to users.
                // model.AlertUsersToNewRound();
            }
        }

        /// <summary>
        /// Method that triggers email deliveries.
        /// </summary>
        /// <param name="model">TournamentModel</param>
        public static void AlertUsersToNewRound(this TournamentModel model)
        {
            int currentRound = model.CheckCurrentRound();
            List<MatchupModel> currentMatchupsInRound = model.Rounds.Where(x => x.First().MatchupRound == currentRound).First();

            foreach (MatchupModel matchup in currentMatchupsInRound)
            {
                foreach (MatchupEntryModel me in matchup.Entries)
                {
                    foreach (PersonModel p in me.TeamCompeting.TeamMembers)
                    {
                        AlertPlayerToNewRound(p, me.TeamCompeting.TeamName, matchup.Entries.Where(x => x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
                    }
                }
            }
        }

        /// <summary>
        /// Helper method to AlertUsersToNewRound().
        /// Constructs email that is sent to players.
        /// </summary>
        /// <param name="player">PersonModel</param>
        /// <param name="teamName">string</param>
        /// <param name="competitor">MatchupEntryModel</param>
        private static void AlertPlayerToNewRound(PersonModel player, string teamName, MatchupEntryModel competitor)
        {
            if (player.EmailAddress.Length == 0)
            {
                return;
            }

            string to = "";
            string subject = "";
            StringBuilder body = new StringBuilder();

            if (competitor != null)
            {
                subject = $"Next match against { competitor.TeamCompeting.TeamName }: READY to be played.";

                body.AppendLine("<h1>New match ready!</h1>");
                body.Append("<strong>Next match against: </strong>");
                body.Append(competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("<h3>Good luck!</h3>");
            }
            else
            {
                subject = "Congratulations, your team was selected for a BYE round.";

                body.AppendLine("You will be notified when your next match is ready!");
            }

            to = player.EmailAddress;

            // EmailLogic.SendEmail(to, subject, body.ToString());
        }

        /// <summary>
        /// Checks current round of the tournament.
        /// </summary>
        /// <param name="model">TournamentModel</param>
        /// <returns>int; current round</returns>
        private static int CheckCurrentRound(this TournamentModel model)
        {
            int output = 1;

            foreach (List<MatchupModel> round in model.Rounds)
            {
                if (round.All(x => x.Winner != null)) 
                {
                    output += 1;
                }
                else
                {
                    return output;
                }
            }

            // Tournament Over
            CompleteTournament(model);

            return output - 1;
        }

        /// <summary>
        /// Calculates prizes, constructs winning email, triggers CompleteTournament event.
        /// </summary>
        /// <param name="model">TournamentModel</param>
        private static void CompleteTournament(TournamentModel model)
        {
            GlobalConfig.Connection.CompleteTournament(model);

            TeamModel winner = model.Rounds.Last().First().Winner;
            TeamModel runnerUp = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winner).First().TeamCompeting;

            decimal winnerPrize = 0;
            decimal runnerUpPrize = 0;
            if (model.Prizes.Count > 0)
            {
                decimal prizePool = model.EnteredTeams.Count * model.EntryFee;
                PrizeModel firstPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
                PrizeModel secondPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();
               
                if (firstPlacePrize != null)
                {
                    winnerPrize = firstPlacePrize.CalculatePrize(prizePool);
                }

                if (secondPlacePrize != null)
                {
                    runnerUpPrize = secondPlacePrize.CalculatePrize(prizePool);
                }
            }

            // Send championsip email
            string subject = "";
            StringBuilder body = new StringBuilder();

            subject = $"{ model.TournamentName } Winner: { winner.TeamName }";

            body.AppendLine("<h1>Congratulations to the winning team!</h1>");
            body.AppendLine("<p>Thank you to everyone that participated in this tournament.</p>");
            body.AppendLine("<br />");

            if (winnerPrize > 0)
            {
                body.AppendLine($"<p>{ winner.TeamName } wins ${ winnerPrize }!</p>");
            }

            if (runnerUpPrize > 0)
            {
                body.AppendLine($"<p>{ runnerUp.TeamName } wins ${ runnerUpPrize }!</p>");
            }

            body.AppendLine();
            body.AppendLine("<p>See you in the next one!</p>");

            List<string> bcc = new List<string>();

            foreach (TeamModel t in model.EnteredTeams) {
                foreach (PersonModel p in t.TeamMembers)
                {
                    if (p.EmailAddress.Length > 0)
                    {
                        bcc.Add(p.EmailAddress); 
                    }
                }
            }

            // EmailLogic.SendEmail(new List<string>(), bcc, subject, body.ToString());

            model.CompleteTournament();
        }

        /// <summary>
        /// Calculates prizes in the tournament.
        /// </summary>
        /// <param name="p">PrizeModel</param>
        /// <param name="prizePool">decimal</param>
        /// <returns>decimal; prize amount</returns>
        private static decimal CalculatePrize(this PrizeModel p, decimal prizePool)
        {
            decimal output = 0;

            if (p.PrizeAmount > 0)
            {
                output = p.PrizeAmount;
            }
            else
            {
                output = Decimal.Multiply(prizePool, Convert.ToDecimal(p.PrizePercentage / 100));
            }

            return output;
        }

        private static void AdvanceWinners(List<MatchupModel> models, TournamentModel tournament)
        {
            foreach (MatchupModel m in models)
            {
                foreach (List<MatchupModel> round in tournament.Rounds)
                {
                    foreach (MatchupModel rm in round)
                    {
                        foreach (MatchupEntryModel me in rm.Entries)
                        {
                            if (me.ParentMatchup != null)
                            {
                                if (me.ParentMatchup.Id == m.Id)
                                {
                                    me.TeamCompeting = m.Winner;
                                    GlobalConfig.Connection.UpdateMatchup(rm);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void ScoreMatchups(List<MatchupModel> models)
        {
            string greaterWins = ConfigurationManager.AppSettings["greaterWins"];

            foreach (MatchupModel m in models)
            {
                // BYES
                if (m.Entries.Count == 1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;
                }

                // 0 - false || lower score wins
                if (greaterWins == "0")
                {
                    if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("System does not support tie games.");
                    }
            }
                else
                {
                    if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("System does not support tie games.");
                    }
                } 
            }
        }

        /// <summary>
        /// Helper method for CreateRounds().
        /// Creates rounds #2 and beyond (if exists).
        /// </summary>
        /// <param name="model">A TournamentModel object</param>
        /// <param name="rounds">int</param>
        private static void CreateRemainingRounds(TournamentModel model, int rounds)
        {
            int round = 2;
            List<MatchupModel> previousRound = model.Rounds[0];
            List<MatchupModel> currRound = new List<MatchupModel>();
            MatchupModel currMatchup = new MatchupModel();

            while (round <= rounds)
            {
                foreach (MatchupModel match in previousRound)
                {
                    currMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                    if (currMatchup.Entries.Count > 1)
                    {
                        currMatchup.MatchupRound = round;
                        currRound.Add(currMatchup);
                        currMatchup = new MatchupModel();
                    }
                }

                model.Rounds.Add(currRound);
                previousRound = currRound;
                currRound = new List<MatchupModel>();
                round += 1;
            }
        }

        /// <summary>
        /// Helper method for CreateRounds().
        /// Creates the first round of the tournament.
        /// </summary>
        /// <param name="byes">int</param>
        /// <param name="teams">A List of TeamModel</param>
        /// <returns>A List of MatchupModel</returns>
        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel curr = new MatchupModel();

            foreach (TeamModel team in teams)
            {
                curr.Entries.Add(new MatchupEntryModel { TeamCompeting = team });
                if (byes > 0 || curr.Entries.Count > 1)
                {
                    curr.MatchupRound = 1;
                    output.Add(curr);
                    curr = new MatchupModel();

                    if (byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Helper method for CreateRounds().
        /// Determines the number of byes in the first round.
        /// </summary>
        /// <param name="rounds">int</param>
        /// <param name="teamCount">int</param>
        /// <returns>int</returns>
        private static int NumOfByes(int rounds, int teamCount)
        {
            int output = 0;
            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - teamCount;

            return output;
        }

        /// <summary>
        /// Helper method for CreateRounds().
        /// Determines the total number of rounds to be played in the tournament.
        /// </summary>
        /// <param name="teamCount">int</param>
        /// <returns>int</returns>
        private static int FindNumOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while (val < teamCount)
            {
                output += 1;
                val *= 2;
            }

            return output;
        }

        /// <summary>
        /// Helper method for CreateRounds().
        /// Randomizes the order of teams.
        /// </summary>
        /// <param name="teams">List<TeamModel></param>
        /// <returns>A list of TeamModel.</returns>
        private static List<TeamModel> OrderRandomizer(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
