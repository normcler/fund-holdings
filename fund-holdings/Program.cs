using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Morningstar.Importer;

namespace fund_holdings
{
    class Program
    {
        public const string FILE_REPO = @"\Users\norm\Dropbox\" + 
            @"windows-manitowoc\Source\Repos\fund-holdings\fund-holdings\" + 
            @"file_repo\";

        public static void Main(string[] args)
        {
            
            List<Holding> holdingList = Morningstar.Importer.FundFileImporter.
                Import(FILE_REPO + "Holdings_FSEVX.csv");
            Holding record_1 = holdingList[1];
            record_1.PrintHoldingData();
        }
    }
}
