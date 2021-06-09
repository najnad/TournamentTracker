using System;
using System.Collections.Generic;
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
