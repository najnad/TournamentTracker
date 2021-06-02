using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represents a team in the matchup.
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// Represents the team's score.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Represents the previous matchup played by the team.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}
