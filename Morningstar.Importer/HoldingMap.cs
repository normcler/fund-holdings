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
            Map(m => m.Weighting).Index(1);
            Map(m => m.Type).Index(2);
            Map(m => m.Ticker).Index(3);
            Map(m => m.Style).Index(4);
            Map(m => m.FirstBought).Index(5);
            Map(m => m.SharesOwned).Index(6);
            Map(m => m.SharesChange).Index(7);
            Map(m => m.Sector).Index(8);
            Map(m => m.MarketValue).Index(9);
            Map(m => m.Price).Index(10);
            Map(m => m.DayChange).Index(11);
            Map(m => m.HighLowDay).Index(12);
            Map(m => m.Volume).Index(13);
            Map(m => m.HighLow52week).Index(14);
            Map(m => m.Country).Index(15);
            Map(m => m.Return3month).Index(16);
            Map(m => m.Return1year).Index(17);
            Map(m => m.Return3year).Index(18);
            Map(m => m.Return5year).Index(19);
            Map(m => m.MarketCapMil).Index(20);
            Map(m => m.Currency).Index(21);
            Map(m => m.RatingMorningstar).Index(22);
            Map(m => m.ReturnYTD).Index(23);
            Map(m => m.PriceToEarnings).Index(24);
            Map(m => m.MaturityDate).Index(25);
            Map(m => m.CouponPercent).Index(26);
            Map(m => m.YieldToMaturity).Index(27);
        }
    }
}
