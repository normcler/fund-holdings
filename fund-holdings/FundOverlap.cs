using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fund_holdings
{
    /// <summary>
    ///     A class that holds one data point in the overlap table matrix.
    /// </summary>
    class FundOverlap
    {
        public string Fund_1Ticker { get; set; }
        public string Fund_2Ticker { get; set; }
        public decimal Overlap { get; set; }

        public FundOverlap()
        {
        }

        public FundOverlap(string fundTicker1, string fundTicker2,
            decimal overlap)
        {
            this.Fund_1Ticker = fundTicker1;
            this.Fund_2Ticker = fundTicker2;
            Overlap = overlap;
        }
    }
}
