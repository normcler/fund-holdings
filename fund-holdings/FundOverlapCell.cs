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
    class FundOverlapCell
    {
        public string SymbolFund_1 { get; set; }
        public string SymbolFund_2 { get; set; }
        public decimal Overlap { get; set; }

        public FundOverlapCell()
        {
        }

        public FundOverlapCell(string fundSymbol_1, string fundSymbol_2,
            decimal overlap)
        {
            this.SymbolFund_1 = fundSymbol_1;
            this.SymbolFund_2 = fundSymbol_2;
            Overlap = overlap;
        }
    }
}
