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

        /// <summary>
        ///     Purpose: Main program to test methods.
        /// </summary>
        /// <remarks>
        ///     Programmer: N. S. Clerman
        ///     
        ///     Revisions
        ///     =========
        ///     1) N. S. Clerman, 31-Jul-2017: Compare every fund to all other
        ///        funds.
        /// </remarks>
        /// <param name="args">
        ///     args
        /// </param>
        public static void Main(string[] args)
        {
            Client testClient = new Client();
            List<string> clientFunds = testClient.getFundTickerList();
            int numberOfFunds = clientFunds.Count();
            for (int kntOuter = 0; kntOuter < numberOfFunds; kntOuter++)
            {
                for (int kntInner = kntOuter+1; kntInner < numberOfFunds;
                    kntInner++)
                {
                    testClient.MorningstarFundDataGroup.
                        FindCommonHoldings(clientFunds[kntOuter],
                        clientFunds[kntInner]);
                }
            }
        }
    }
}