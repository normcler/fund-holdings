using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;

namespace Morningstar.Importer
{
    public class FundFileImporter
    {
        public static List<Holding> Import (string fileName)
        {
            List<Holding> result = new List<Holding>();
            using (StreamReader reader = File.OpenText(fileName))
            {
                // result = new char[reader.BaseStream.Length];
                // await reader.ReadAsync(result, 0, (int)reader.BaseStream.Length);
                var fund_csv = new CsvReader(reader);
                fund_csv.Configuration.RegisterClassMap<HoldingMap>();
                fund_csv.Read();
                while (fund_csv.Read())
                {
                    Holding record = fund_csv.GetRecord<Holding>();
                    result.Add(record);
                }
             return result;
            }
        }
    }
}
