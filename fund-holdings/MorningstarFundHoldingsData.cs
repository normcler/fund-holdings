﻿using System;
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
    /// <remarks>
    ///     N. S. Clerman, 20-Aug-2017: add fundOverlapList
    /// </remarks>
    class MorningstarFundHoldingsData
    {
        public const string FILE_REPO = @"\Users\norm\Dropbox\" +
        @"windows-manitowoc\Source\Repos\fund-holdings\fund-holdings\" +
        @"file_repo\";

        // the fund dictionary holds the fund ticker and the holdings list of
        // the fund
        public Dictionary<string, List<Holding>> FundDictionary { get; set; }
        internal List<FundOverlap> FundOverlapList { get => fundOverlapList;
            set => fundOverlapList = value; }

        private List<FundOverlap> fundOverlapList;

        /// <summary>
        ///     Contructor - build the fundDictionary for each fund in the list.
        /// </summary>
        /// <param name="fundTickerList">A List of fund tickers.</param>
        public MorningstarFundHoldingsData (List<string> fundTickerList)
        {
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
            FundDictionary = tempDict;
        }

        /// <summary>
        ///     Purpose: Find the common holdings in two funds in the portfolio
        ///         and return the overlap between the two funds.
        /// </summary>
        /// <param name="fundSymbol_1">
        ///     fundSymbol_1: The ticker for the first funds
        /// </param>
        /// <param name="fundSymbol_2">
        ///     fundSymbol_2: The ticker for the second fund
        /// </param>
        /// <returns>
        ///     fundsOverlap: the overlap in holdings between the funds.
        /// </returns>
        public decimal FindCommonHoldings(string fundSymbol_1, 
            string fundSymbol_2)
        {
            /*
             * Programmer: N. S. Clerman, 29-Jul-2017
             * 
             * Revisions
             * =========
             *  1) N.S. Clerman, 02-Aug-2017: Change the commonHoldings List to
             *      a List of class Holding. Write a text file to create an table.
             */
            decimal fundsOverlap = 0.0M;
            if ((fundSymbol_1 != fundSymbol_2) &&
                (FundDictionary.Count > 0) &&
                FundDictionary.ContainsKey(fundSymbol_1) &&
                FundDictionary.ContainsKey(fundSymbol_2))
            {
                WriteLine($"Searching funds {fundSymbol_1} and " +
                    $"{fundSymbol_2} for common holdings.");
                WriteLine();

                List<Holding> hList_1 = FundDictionary[fundSymbol_1];
                List<Holding> hList_2 = FundDictionary[fundSymbol_2];
                List<Holding> commonHoldings = new List<Holding>();

                // my guess is that there's a Linq function that will
                // accomplish this in one statement.
                Dictionary<string, decimal> overlapList =
                    new Dictionary<string, decimal>();

                /*
                 * A nested loop over the all the holdings in all the funds.
                 */
                //for (int knt_1 = 0; knt_1 < hList_1.Count; knt_1++)
                // I cannot use this. I need to collect some data for each
                // individual overlap. Also, I need the loop to sum the individual
                // overlaps. I could use Intersect, but them I would need other,
                // different loops to compute what I need.

                //commonHoldings = (hList_1.Intersect(hList_2)).ToList<Holding>();
                //WriteLine($"trialIntersect has {commonHoldings.Count} elements");

                /*
                 * A nested loop over the all the holdings in all the funds.
                                */
                //for (int knt_1 = 0; knt_1 < hList_1.Count; knt_1++)
                int kntCommon = 0;
                FundsOverlapTable overlapTable =
                new FundsOverlapTable(fundSymbol_1, fundSymbol_2);
                foreach (Holding h_1 in hList_1)
                {
                    // WriteLine($"{knt}: Searching for " + $"{h_1.Ticker}");
                    foreach (Holding h_2 in hList_2)
                    {
                        if (h_1 == h_2)
                        {
                            commonHoldings.Add(h_1);
                            decimal currentOverlap = h_1.ComputerOverlap(h_2);
                            kntCommon++;
                            // Code for creating overlap table.
                            overlapList[h_1.Ticker] = currentOverlap;
                            //HoldingOverlap holdingOverlap =
                            //    new HoldingOverlap(ticker: h_1.Ticker,
                            //    name: h_1.Name,
                            //    overlap: currentOverlap);
                            //overlapTable.OverlapList.Add(holdingOverlap);
                            //WriteLine($"{h_1.Ticker} is also in {fundTicker_2}");
                            //WriteLine($"Their overlap is {holdingOverlap}");
                            fundsOverlap += currentOverlap;
                        }
                    }
                }

                //if (kntCommon > 0)
                //{
                //    overlapTable.PrintTable();
                //    ReadLine();
                //}

                WriteLine($"{fundSymbol_1} and {fundSymbol_2} have " +
                    $"{commonHoldings.Count} common holdings");
                ReadLine();

                string ticker;
                if (commonHoldings.Count() > 0)
                {
                    for (int iCnt = 0; iCnt < commonHoldings.Count(); iCnt++)
                    {
                        ticker = commonHoldings[iCnt].Ticker;
                    }
                    //WriteLine($"Their total overlap is {fundsOverlap}");
                    //ReadLine();
                }
                else
                {
                    //WriteLine();
                }
                overlapList.Clear();
            }
            return fundsOverlap;
        }

        public void PrintRecord_0(string fundTicker)
        {
            List<Holding> holdingList = this.FundDictionary[fundTicker];
            Holding record_0 = holdingList[0];
            record_0.PrintHoldingData();
        }
    }
}
