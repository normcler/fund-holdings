using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;

namespace Morningstar.Importer
{
    public class FundFileImporter
    {
        /// <summary>
        /// Purpose: Import fund data from a csv file from Morningstar
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>A List of class Holding</returns>
        /// <remarks>
        /// Programmer: N. S. Clerman
        /// 
        /// Revisions:
        /// 1) N. S. Clerman, 28-Jul-2017: Read the file in with a single
        ///    operation.
        /// </remarks>
        public static List<Holding> Import (string fileName)
        {
            List<Holding> result = new List<Holding>();
            using (StreamReader reader = File.OpenText(fileName))
            {
                var fund_csv = new CsvReader(reader);
                fund_csv.Configuration.RegisterClassMap<HoldingMap>();
                fund_csv.Configuration.HasHeaderRecord = true;
                // Code to read the file record by record.
                /*while (fund_csv.Read())
                {
                    Holding record = fund_csv.GetRecord<Holding>();
                    result.Add(record);
                }*/

                // Code to read all the records. (This requires Linq)
                result = fund_csv.GetRecords<Holding>().ToList();
                return result;
            }
        }
    }
}
