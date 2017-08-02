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
    class MorningstarFundHoldingsData
    {
        // the fund dictionary holds the fund ticker and the holdings list of
        // the fund
        Dictionary<string, List<Holding>> fundDictionary { get; set; }

        public MorningstarFundHoldingsData (List<string> fundTickerList)
        {
            const string FILE_REPO = @"\Users\norm\Dropbox\" +
            @"windows-manitowoc\Source\Repos\fund-holdings\fund-holdings\" +
            @"file_repo\";

            Dictionary<string, List<Holding>> tempDict = new Dictionary<string,
                List<Holding>>();

            /*
             *  Loop through all the funds in the list of fund tickers.
             *  Import the file. Filter out all holdings that are not equities
             *  or do not have a ticker symbol.
             */
            foreach (string ticker in fundTickerList)
            {
                List<Holding> rawList = Morningstar.Importer.FundFileImporter.
                    Import(FILE_REPO, ticker);
                List<Holding> equityList = rawList.Where(x => (x.IsEquityHolding() && 
                x.HasTicker())).ToList();
                tempDict[ticker] = equityList;
            }
            fundDictionary = tempDict;
        }

        /// <summary>
        ///     Purpose: Find the common holdings in two funds in the portfolio.
        /// </summary>
        /// <param name="fundTicker_1">
        ///     fundTicker_1: The ticker for the first funds
        /// </param>
        /// <param name="fundTicker_2">
        ///     fundTicker_2: The ticker for the second fund
        /// </param>
        /// <remarks>
        ///     Programmer: N. S. Clerman, 29-Jul-2017
        /// </remarks>
        public void FindCommonHoldings(string fundTicker_1, string fundTicker_2)
        {
            if ((fundTicker_1 != fundTicker_2) &&
                (fundDictionary.Count > 0) &&
                fundDictionary.ContainsKey(fundTicker_1) &&
                fundDictionary.ContainsKey(fundTicker_2))
            {
                WriteLine($"Searching funds {fundTicker_1} and " +
                    $"{fundTicker_2} for common holdings.");

                List<Holding> hList_1 = fundDictionary[fundTicker_1];
                List<Holding> hList_2 = fundDictionary[fundTicker_2];
                List<string> commonHoldings = new List<string>();
                int knt = 0;
                int kntCommon = 0;
                foreach (Holding h_1 in hList_1)
                {
                    knt++;
                    // WriteLine($"{knt}: Searching for " + $"{h_1.Ticker}");
                    foreach (Holding h_2 in hList_2)
                    {
                        if (h_1 == h_2)
                        {
                            commonHoldings.Add(h_1.Ticker);
                            kntCommon++;
                            //WriteLine($"{h_1.Ticker} is also in {fundTicker_2}");
                        }
                    }
                }
                WriteLine($"Found {kntCommon} common holdings.");
                if (kntCommon > 0)
                {
                    for (int iCnt = 0; iCnt < commonHoldings.Count(); iCnt++)
                    {
                        WriteLine($"{iCnt}) {commonHoldings[iCnt]}");
                    }
                    ReadLine();
                }
                else
                {
                    WriteLine();
                }
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
