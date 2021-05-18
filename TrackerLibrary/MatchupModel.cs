using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class MatchupModel
    {
        /// <summary>
        /// A list of the two teams competing in a single matchup.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        
        /// <summary>
        /// Represents the winner of the matchup.
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Represents the round the matchup is being played at.
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
