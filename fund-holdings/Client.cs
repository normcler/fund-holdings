using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fund_holdings
{
    class Client
    {
        public Portfolio clientPortfolio { get; set; }

        /// <summary>
        ///     Build a list containing all the tickers in a client's portfolio
        /// </summary>
        /// <returns>
        ///     A string List of the tickers in a clients portfolio
        /// </returns>
        /// <remarks>   When set, this will build a list from the client's
        ///             portfolio. For initial testing, simply supply a list
        ///             of fund tickers.
        /// </remarks>
        public List<string> getTickerList()
        {
            string[] testList = { "FSEVX", "VTMSX"};
            List<string> tickerList = testList.ToList();
            return tickerList;
        }
    }
}
