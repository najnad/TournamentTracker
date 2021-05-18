using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        /// <summary>
        /// Represents a place number for the prize.
        /// </summary>
        public int PlaceNumber { get; set; }
        
        /// <summary>
        /// Represents a place name.
        /// </summary>
        /// <example>
        /// First Place, Champion, Fist Runner Up, etc.
        /// </example>
        public string PlaceName { get; set; }

        /// <summary>
        /// Represents the prize amount.
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Represents the prize percentage.
        /// </summary>
        public double PrizePercentage { get; set; }

    }
}
