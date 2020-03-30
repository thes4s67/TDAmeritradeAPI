using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Fields
{
    public static class MarketType
    {
        /// <summary>
        /// Used for getting market hour(s)
        /// </summary>
        public const string
            Bond = "BOND",
            Equity = "EQUITY",
            ETF = "ETF",
            Forex = "FOREX",
            Future = "FUTURE",
            Future_Option = "FUTURE_OPTION",
            Index = "INDEX",
            Indicator = "INDICATOR",
            Mutual_Fund = "MUTAL_FUND",
            Option = "OPTION",
            Unknown = "UNKNOWN";
    }
}
