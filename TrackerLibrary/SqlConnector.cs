using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class SqlConnector : IDataConnection
    {
        // TODO - Connect SQL database.
        /// <summary>
        /// Saves a prize to the database.
        /// </summary>
        /// <param name="model">A prize object</param>
        /// <returns>A prize object, inlcuding its properties.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
