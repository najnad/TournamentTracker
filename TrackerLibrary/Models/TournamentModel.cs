using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class TournamentModel
    {
        /// <summary>
        /// Primary key for the tournament.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the tournament name.
        /// </summary>
        /// <example>
        /// Ping Pong Tournament, Basketball Tournament
        /// </example>
        public string TournamentName { get; set; }

        /// <summary>
        /// Represents each team's entry fee to enter the tournament.
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// A list of teams registered for the tournament.
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        
        /// <summary>
        /// A list of prizes for the winners of the tournament.
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        
        /// <summary>
        /// A list of matchups for each round of the tournament.
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();
    }
}
