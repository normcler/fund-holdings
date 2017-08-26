using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fund_holdings
{
    class Client
    {
        //public MorningstarFundHoldingsData 
            //MorningstarFundDataGroup { get; set; }

        // Portfolio - A list of fund holdings in a portfolio. Each entry is 
        // the fund symbol and the number of shares.
        public List<PortfolioHolding> Portfolio { get; set; }

        /// <summary>
        ///     Constructor: Build a Client object.
        /// </summary>
        /// <remarks>
        ///     Programmer: N. S. Clerman, 29-Jul-2017
        /// </remarks>
        public Client()
        {
            List<string> tickerList = GetFundSymbolList();
            MorningstarFundHoldingsData.BuildFundDictionary(tickerList);
            //this.MorningstarFundDataGroup =
            //    new MorningstarFundHoldingsData(tickerList);

            // test obtaining the value of a particular field by heading name.
            MorningstarFundHoldingsData.PrintRecord_0("FSEVX");
            MorningstarFundHoldingsData.PrintRecord_0("VTMSX");
        }

        /// <summary>
        ///     Build a list containing all the tickers in a client's portfolio
        /// </summary>
        /// <returns>
        ///     tickerList: A string List of the tickers in a clients Portfolio
        /// </returns>
        /// <remarks>
        ///     Programmer: N. S. Clerman, 29-Jul-2017
        ///     
        ///     When completed, this will build a list from the client's
        ///     portfolio. For initial testing, simply supply a list of fund 
        ///     tickers.
        /// </remarks>

        public List<string> GetFundSymbolList()
        {
            string[] testList = { "FSEVX", "VTMSX", "FPMAX", "PRASX", "PRHSX",
            "PRITX", "PRNHX", "VEMAX", "VEUSX", "VFSVX", "VPADX", "VTRIX"};
            List<string> tickerList = testList.ToList();
            return tickerList;
        }
    }
}
