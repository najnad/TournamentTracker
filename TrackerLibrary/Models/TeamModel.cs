using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class TeamModel
    {
        /// <summary>
        /// Primary key for the team.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A list of people on the team.
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

        /// <summary>
        /// Represents a team's name.
        /// </summary>
        public string TeamName { get; set; }

    }
}
