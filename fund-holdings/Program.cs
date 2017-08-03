using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Morningstar.Importer;

namespace fund_holdings
{
    class Program
    {
        /*
         * Programmer: N. S. Clerman
         * 
         * Revisions
         * =========
         *  1) N. S. Clerman, 31-Jul-2017: Compare every fund to all other
         *      funds.
         *  2) N. S. Clerman, 02-Aug-2017: Remove unused variable.
         */
        public const string OVERLAP_FILE_NAME = @"overlap.txt";

        /// <summary>
        ///     Purpose: Main program to test methods.
        /// </summary>
        /// <param name="args">
        ///     command-line args
        /// </param>
        public static void Main(string[] args)
        {
            Client testClient = new Client();
            List<string> clientFunds = testClient.getFundTickerList();

            // Open a file to write to in the FILE_REPO directory
            string filename = MorningstarFundHoldingsData.FILE_REPO +
                OVERLAP_FILE_NAME;
            StreamWriter textWriter = File.CreateText(filename);

            int numberOfFunds = clientFunds.Count();
            decimal[,] overlapMatrix = new decimal[numberOfFunds, numberOfFunds];
            for (int kntOuter = 0; kntOuter < numberOfFunds; kntOuter++)
            {
                textWriter.Write($"{clientFunds[kntOuter]} ");
                for (int iCol = 0; iCol < kntOuter; iCol++)
                {
                    // write the overlaps up to the diagonal; they are the mirror
                    // of overlaps already computed.
                    textWriter.Write($"{overlapMatrix[kntOuter,iCol]},");
                }
                // and then the diagonal
                textWriter.Write(" - ,");
                for (int kntInner = kntOuter+1; kntInner < numberOfFunds;
                    kntInner++)
                {
                    overlapMatrix[kntOuter, kntInner] =
                        testClient.MorningstarFundDataGroup.
                        FindCommonHoldings(clientFunds[kntOuter],
                        clientFunds[kntInner]);
                    // and fill out the row from the column past the diagonal to 
                    // the end with the newly-computed overlap.
                }
                for (int iCol = kntOuter+1; iCol < numberOfFunds; iCol++)
                {
                    if (iCol < numberOfFunds-1)
                    {
                        textWriter.Write($"{overlapMatrix[kntOuter, iCol]},");
                    }
                    else
                    {
                        textWriter.
                            WriteLine($"{overlapMatrix[kntOuter, iCol]}");
                    }
                }
            }
            textWriter.Dispose();
        }
    }
}