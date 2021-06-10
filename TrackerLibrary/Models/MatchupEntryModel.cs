using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Primary key for the matchup entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id for team.
        /// </summary>
        public int TeamCompetingId { get; set; }
        
        /// <summary>
        /// Represents a team in the matchup.
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// Represents the team's score.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Id for parent matchup.
        /// </summary>
        public int ParentMatchupId { get; set; }

        /// <summary>
        /// Represents the previous matchup played by the team.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}
