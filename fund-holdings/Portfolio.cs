using System;
using static System.Console;
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
                List<Holding> rawList = Morningstar.Importer.FundFileImporter.
                    Import(FILE_REPO, ticker);
                List<Holding> equityList = rawList.Where(x => x.IsEquityHolding()).ToList();
                tempDict[ticker] = equityList;
            }
            fundDictionary = tempDict;
        }

        public void FindCommonHoldings(string fundTicker_1, string fundTicker_2)
        {
            if ((fundTicker_1 != fundTicker_2) &&
                (fundDictionary.Count > 0) &&
                fundDictionary.ContainsKey(fundTicker_1) &&
                fundDictionary.ContainsKey(fundTicker_2))
            {
                List<Holding> hList_1 = fundDictionary[fundTicker_1];
                List<Holding> hList_2 = fundDictionary[fundTicker_2];
                int knt = 0;
                int kntCommon = 0;
                foreach (Holding h_1 in hList_1)
                {
                    WriteLine($"Searching funds {fundTicker_1} and " +
                        $"{fundTicker_2} for common holdings.");
                    knt++;
                    WriteLine($"{knt}: Searching for " + $"{h_1.Ticker}");
                    foreach (Holding h_2 in hList_2)
                    {
                        if (h_1 == h_2)
                        {
                            kntCommon++;
                            WriteLine($"{h_1.Ticker} is also in {fundTicker_2}");
                        }
                    }
                }
                WriteLine($"Found {kntCommon} common holdings.");
                ReadLine();
            }
        }

        public void PrintRecord_0(string fundTicker)
        {
            List<Holding> holdingList = this.fundDictionary[fundTicker];
            Holding record_0 = holdingList[0];
            record_0.PrintHoldingData();
        }
    }
}
