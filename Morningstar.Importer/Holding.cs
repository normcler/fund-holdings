﻿using System;

namespace Morningstar.Importer
{
    /// <summary>
    /// A class containing one mutual fund holding.
    /// </summary>
    public class Holding
    {
        public string Name { get; set; }
        public decimal Weighting { get; set; }
        public string Type { get; set; }
        public string Ticker { get; set; }
        public string Style { get; set; }
        public DateTime FirstBought { get; set; }
        public int SharesOwned { get; set; }
        public int SharesChange { get; set; }
        public string Sector { get; set; }
        public int MarketValue { get; set; }
        public decimal Price { get; set; }
        // day change is a string containing the change in currency and in
        // percentage, separated by a vertical bar, |. The percentage includes
        // the percent symbol, %.
        public string DayChange { get; set; }
        // high low is a pair of floating point numbers separated by a hyphen
        // (dash), -.
        public string HighLowDay { get; set; }
        public int Volume { get; set; }
        // same as highLowDay
        public string HighLow52week { get; set; }
        public string Country { get; set; }
        public decimal Return3month { get; set; }
        public decimal Return1year { get; set; }
        public decimal Return3year { get; set; }
        public decimal Return5year { get; set; }
        public decimal MarketCapMil { get; set; }
        public string Currency { get; set; }
        public int RatingMorningstar { get; set; }
        public decimal ReturnYTD { get; set; }
        public decimal PriceToEarnings { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal CouponPercent { get; set; }
        public decimal YieldToMaturity { get; set; }
    }
}
