using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using TrackerLibrary.Models;

// Load text file
// Convert text to List<PrizeMOdel>
// Find the max ID
// Add the new record with the new ID
// Convert the prizes to list<String>
// Save the list<string> to the text file

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// The file path to the text database.
        /// </summary>
        /// <param name="fileName">File Name</param>
        /// <returns>The full file path.</returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName } ";
        }

        /// <summary>
        /// Loads file, if it exists, and turns each line into a list of string.
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>A list of string.</returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Converts the List<string> from the LoadFile() method into a List<PrizeModel>.
        /// </summary>
        /// <param name="lines">output from LoadFile()</param>
        /// <returns>A list of PrizeModel</returns>
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);

                output.Add(p);
            }

            return output;
        }

        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellphoneNumber = cols[4];

                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// Saves data into Prize file database.
        /// </summary>
        /// <param name="models">Output from ConvertToPrizeModels()</param>
        /// <param name="fileName">File</param>
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{ p.Id },{ p.PlaceNumber },{ p.PlaceName },{ p.PrizeAmount },{ p.PrizePercentage }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToPeopleFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel p in models)
            {
                lines.Add($"{ p.Id },{ p.FirstName },{ p.LastName },{ p.EmailAddress },{ p.CellphoneNumber }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
