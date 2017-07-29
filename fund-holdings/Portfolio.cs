using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Morningstar.Importer;

namespace fund_holdings
{

    /// <summary>
    ///     A class containing a Dictionary of funds. The dictionary key is the
    ///     symbol; the value is the list of its holdings (class Holding).
    /// </summary>
    class Portfolio
    {
        // the fund dictionary holds the fund ticker and the holdings list of
        // the fund
        Dictionary<string, List<Holding>> fundDictionary { get; set; }

        public Portfolio (List<string> tickerList)
        {
            const string FILE_REPO = @"\Users\norm\Dropbox\" +
            @"windows-manitowoc\Source\Repos\fund-holdings\fund-holdings\" +
            @"file_repo\";

            Dictionary<string, List<Holding>> tempDict = new Dictionary<string,
                List<Holding>>();

            foreach (string ticker in tickerList)
            {
                List<Holding> holdingList = Morningstar.Importer.FundFileImporter.
                    Import(FILE_REPO, ticker);
                tempDict[ticker] = holdingList;
            }
            fundDictionary = tempDict;
        }

        public void PrintRecord_0(string fundTicker)
        {
            List<Holding> holdingList = this.fundDictionary[fundTicker];
            Holding record_0 = holdingList[0];
            record_0.PrintHoldingData();
        }
    }
}
