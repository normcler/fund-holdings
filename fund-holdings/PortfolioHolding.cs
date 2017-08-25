using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fund_holdings
{
    /// <summary>
    ///     A single holding (fund) in a portfolio.
    /// </summary>
    class PortfolioHolding
    {
        public string Symbol { get; set; }
        public int NumberOfShares { get; set; }
    }
}
