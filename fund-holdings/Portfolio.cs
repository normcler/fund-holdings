using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Morningstar.Importer;

namespace fund_holdings
{

    /// <summary>
    /// A class containing a Dictionary of funds. The dictionary key is the
    /// symbol; the value is the list of its holdings (class Holding).
    /// </summary>
    class Portfolio
    {
        Dictionary<string, List<Holding>> fund { get; set; }
    }
}
