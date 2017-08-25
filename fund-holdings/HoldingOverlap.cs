using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fund_holdings
{
    public class HoldingOverlap
    {
        public string HoldingTicker { get; set; }
        public string HoldingName { get; set; }
        public decimal Overlap { get; set; }

        public HoldingOverlap()
        {
            HoldingTicker = "";
            HoldingName = "";
            Overlap = 0.0M;
        }

        public HoldingOverlap(string ticker, string name, decimal overlap)
        {
            HoldingTicker = ticker;
            HoldingName = name;
            Overlap = overlap;
        }
    }
}
