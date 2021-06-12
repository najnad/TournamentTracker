using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
using System.Linq;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        /// <summary>
        /// Saves a player to the text file database.
        /// </summary>
        /// <param name="model">A person object</param>
        /// <returns>A person object, inlcuding its properties.returns>
        public void CreatePlayer(PersonModel model)
        {
            List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            // Find the max ID
            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            // Add the new record with the new ID
            people.Add(model);

            people.SaveToPeopleFile();
        }

        /// <summary>
        /// Saves a prize to the text file database.
        /// </summary>
        /// <param name="model">A prize object</param>
        /// <returns>A prize object, inlcuding its properties.</returns>
        public void CreatePrize(PrizeModel model)
        {
            // Load text file
            // Convert text to List<PrizeMOdel>
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find the max ID
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            // Add the new record with the new ID
            prizes.Add(model);

            // Convert the prizes to list<String>
            // Save the list<string> to the text file
            prizes.SaveToPrizeFile();
        }

        /// <summary>
        /// Saves a team into the text database.
        /// </summary>
        /// <param name="model">A TeamModel object</param>
        /// <returns>A TeamModel object, inlcuding its properties.</returns>
        public void CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

            // Find the max ID
            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            teams.Add(model);

            teams.SaveToTeamFile();
        }

        /// <summary>
        /// Saves a tournament into the text database.
        /// </summary>
        /// <param name="model">A TournamentModel object</param>
        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels();

            // Find the max ID
            int currentId = 1;

            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            model.SaveRoundsToFile();

            tournaments.Add(model);

            tournaments.SaveToTournamentFile();

            TournamentLogic.UpdateTournamentResults(model);
        }

        /// <summary>
        /// Gets all person models in the text database.
        /// </summary>
        /// <returns>A list of PersonModel.</returns>
        public List<PersonModel> GetPerson_All()
        {
            return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        /// <summary>
        /// Gets all team models in the text database.
        /// </summary>
        /// <returns>A list of TeamModel.</returns>
        public List<TeamModel> GetTeam_All()
        {
            return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
        }

        /// <summary>
        /// Gets all tournament models in the text database.
        /// </summary>
        /// <returns>a list of TournamentModel.</returns>
        public List<TournamentModel> GetTournament_All()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();
        }

        /// <summary>
        /// Updates Matchup data in text file database.
        /// </summary>
        /// <param name="model"></param>
        public void UpdateMatchup(MatchupModel model)
        {
            model.UpdateMatchupToFile();
        }
    }
}
