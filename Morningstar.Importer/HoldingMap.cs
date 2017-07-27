﻿using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morningstar.Importer
{
    /// <summary>
    /// Provide a map to the Holding class
    /// </summary>
    /// <remarks>
    /// Programmer: N. S. Clerman
    /// 
    /// Note: An empty field is indicated in the file by a hyphen (dash) surrounded by
    /// double quotation marks, "-".
    /// </remarks>
    public class HoldingMap : CsvClassMap<Holding>
    {
        protected static DateTime noDate = new DateTime(1000, 1, 1);
        public HoldingMap()
        {
            // Each mapping maps a position in the record to the property name
            // assigned to it in class Holding.
            Map(m => m.Name).Index(0);
            Map(m => m.Weighting).Index(1).
                ConvertUsing(s => ConvertDecimal(s[1]));
            Map(m => m.Type).Index(2);
            Map(m => m.Ticker).Index(3);
            Map(m => m.Style).Index(4);
            Map(m => m.FirstBought).Index(5).
                ConvertUsing(s => ConvertDateTime(s[5]));
            Map(m => m.SharesOwned).Index(6).
                ConvertUsing(s => ConvertInt(s[6]));
            Map(m => m.SharesChange).Index(7).
                ConvertUsing(s => ConvertInt(s[7]));
            Map(m => m.Sector).Index(8);
            Map(m => m.MarketValue).Index(9).
                ConvertUsing(s => ConvertInt(s[9]));
            Map(m => m.Price).Index(10).
                ConvertUsing(s => ConvertDecimal(s[10]));
            Map(m => m.DayChangeValue).Index(11).
                ConvertUsing(s => ConvertDecimalPair(s[11]));
            Map(m => m.DayChangePercent).Index(11).
                ConvertUsing(s => ConvertPercentPair(s[11]));
            Map(m => m.HighDay).Index(12).
                ConvertUsing(s => ConvertHighPair(s[12]));
            Map(m => m.LowDay).Index(12).
                ConvertUsing(s => ConvertLowPair(s[12]));
            Map(m => m.Volume).Index(13).
                ConvertUsing(s => ConvertInt(s[13]));
            Map(m => m.High52week).Index(14).
                ConvertUsing(s => ConvertHighPair(s[14]));
            Map(m => m.Low52week).Index(14).
                ConvertUsing(s => ConvertLowPair(s[14]));
            Map(m => m.Country).Index(15);
            Map(m => m.Return3month).Index(16).
                ConvertUsing(s => ConvertDecimal(s[16]));
            Map(m => m.Return1year).Index(17).
                ConvertUsing(s => ConvertDecimal(s[17]));
            Map(m => m.Return3year).Index(18).
                ConvertUsing(s => ConvertDecimal(s[18));
            Map(m => m.Return5year).Index(19).
                ConvertUsing(s => ConvertDecimal(s[19]));
            Map(m => m.MarketCapMil).Index(20).
                ConvertUsing(s => ConvertDecimal(s[20]));
            Map(m => m.Currency).Index(21);
            Map(m => m.RatingMorningstar).Index(22).
                ConvertUsing(s => ConvertInt(s[22]));
            Map(m => m.ReturnYTD).Index(23).
                ConvertUsing(s => ConvertDecimal(s[23]));
            Map(m => m.PriceToEarnings).Index(24).
                ConvertUsing(s => ConvertDecimal(s[24]));
            Map(m => m.MaturityDate).Index(25).
                ConvertUsing(s => ConvertDateTime(s[25]));
            Map(m => m.CouponPercent).Index(26).
                ConvertUsing(s => ConvertDecimal(s[26]));
            Map(m => m.YieldToMaturity).Index(27).
                ConvertUsing(s => ConvertDecimal(s[27]));
        }

        /// <summary>
        /// Check DateTime for an empty field 
        /// </summary>
        /// <param name="fieldValue">The field</param>
        /// <returns></returns>
        public static DateTime? ConvertDateTime(string fieldValue)
        {
            //DateTime result = IsDash(fieldValue) ? noDate: DateTime.Parse(fieldValue);
            DateTime? result = IsDash(fieldValue) ? (DateTime?)null : 
                DateTime.Parse(fieldValue);
            return result;
        }

        /// <summary>
        /// Parse a decimal field. 
        /// </summary>
        /// <param name="fieldValue">The field</param>
        /// <returns>Return 0.0M if empty; otherwise the value</returns>
        /// <remarks>
        /// Programmer: N. S. Clerman
        /// </remarks>
        public static decimal ConvertDecimal(string fieldValue)
        {
            decimal result = IsDash(fieldValue) ? 0.0M : Decimal.Parse(fieldValue);
            return result;
        }

        /// <summary>
        /// Parse a decimal field that is the first number in a decimal-percent
        /// pair.
        /// </summary>
        /// <param name="fieldValue">The field</param>
        /// <returns>Return 0.0M if empty; otherwise the value</returns>
        /// <remarks>
        /// Programmer: N. S. Clerman
        /// 
        /// Notes: The field is a string containing the day change. Two values
        /// are separated by a vertical bar (|). The first is the change in 
        /// price; the second is the percentage change. Ex: "-1.52|-0.46%"
        /// </remarks>
        public static decimal ConvertDecimalPair(string fieldValue)
        {
            decimal result;
            if (IsDash(fieldValue))
            {
                result = 0.0M;
            }
            else
            {
                result = Decimal.Parse(fieldValue.Split('|')[0]);
            }
            return result;
        }

        /// <summary>
        /// Parse the first first number in a high-low pair.
        /// </summary>
        /// <param name="fieldValue">The field</param>
        /// <returns>Return 0.0M if empty; otherwise the value</returns>
        /// <remarks>
        /// Programmer: N. S. Clerman
        /// 
        /// Notes: The field is a string containing the high and low values. 
        /// Two values are separated by a vertical bar (|). Ex: "386.99-178.19"
        /// </remarks>
        public static decimal ConvertHighPair(string fieldValue)
        {
            decimal result;
            if (IsDash(fieldValue))
            {
                result = 0.0M;
            }
            else
            {
                result = Decimal.Parse(fieldValue.Split('-')[1]);
            }
            return result;
        }

        /// <summary>
        /// Parse an integer field.
        /// </summary>
        /// <param name="fieldValue">The field</param>
        /// <returns>Return 0 if empty; otherwise the value</returns>
        /// <remarks>
        /// Programmer: N. S. Clerman
        /// </remarks>
        public static int ConvertInt(string fieldValue)
        {
            int result = IsDash(fieldValue) ? 0 : Int32.Parse(fieldValue);
            return result;
        }

        /// <summary>
        /// Parse the second number in a high-low pair.
        /// </summary>
        /// <param name="fieldValue">The field</param>
        /// <returns>Return 0.0M if empty; otherwise the value</returns>
        /// <remarks>
        /// Programmer: N. S. Clerman
        /// 
        /// Notes: The field is a string containing the high and low values. 
        /// Two values are separated by a vertical bar (|). Ex: "386.99-178.19"
        /// </remarks>
        public static decimal ConvertLowPair(string fieldValue)
        {
            decimal result;
            if (IsDash(fieldValue))
            {
                result = 0.0M;
            }
            else
            {
                result = Decimal.Parse(fieldValue.Split('-')[1]);
            }
            return result;
        }

        /// <summary>
        /// Parse a percent field that is the second number in a decimal-percent
        /// pair.
        /// </summary>
        /// <param name="fieldValue">The field</param>
        /// <returns>Return 0.0M if empty; otherwise the value</returns>
        /// <remarks>
        /// Programmer: N. S. Clerman
        /// 
        /// Notes: The field is a string containing the day change. Two values
        /// are separated by a vertical bar (|). The first is the change in 
        /// price; the second is the percentage change. Ex: "-1.52|-0.46%"
        /// </remarks>
        public static decimal ConvertPercentPair(string fieldValue)
        {
            decimal result;
            if (IsDash(fieldValue))
            {
                result = 0.0M;
            }
            else
            {
                result = Decimal.Parse(fieldValue.Split('|')[1].
                    Replace("%", String.Empty));
            }
            return result;
        }

        /// <summary>
        /// Return a bool indicating if the field is a dash.
        /// </summary>
        /// <param name="row">The current file record</param>
        /// <param name="index">The current field index</param>
        /// <returns></returns>
        public static bool IsDash(string fieldValue)
        {
            bool isDash = fieldValue == "-";
            return isDash;
        }
    }
}
