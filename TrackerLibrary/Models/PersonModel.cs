using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {

        /// <summary>
        /// Primary key for the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents a person's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Represents a person's lsat name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represents a person's email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Represents a person's cellphone number.
        /// </summary>
        public string CellphoneNumber { get; set; }

        /// <summary>
        /// Used to display a person's full name.
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }
    }
}
