using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// Primary key for the matchup.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A list of the two teams competing in a single matchup.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        /// <summary>
        /// Id to identify winner.
        /// </summary>
        public int WinnerId { get; set; }

        /// <summary>
        /// Represents the winner of the matchup.
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Represents the round the matchup is being played at.
        /// </summary>
        public int MatchupRound { get; set; }

        /// <summary>
        /// Property used to display teams competing.
        /// </summary>
        public string DisplayName
        {
            get
            {
                string output = "";
                foreach (MatchupEntryModel entry in Entries)
                {
                    if (entry.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {
                            output = entry.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs. { entry.TeamCompeting.TeamName}";
                        } 
                    }
                    else
                    {
                        output = "Match TBD";
                        break;
                    }
                }

                return output;
            }
        }
    }
}
