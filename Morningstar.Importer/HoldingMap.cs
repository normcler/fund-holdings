using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morningstar.Importer
{
    public class HoldingMap : CsvClassMap<Holding>
    {
        public HoldingMap()
        {
            // Each mapping maps a position in the record to the property name
            // assigned to it in class Holding.
            Map(m => m.Name).Index(0);
            
        }
    }
}
