using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Props
{
    public class OptionChainSettings
    {
        public string symbol { get; set; }
        public string? contractType { get; set; }
        public int? strikeCount { get; set; }
        public bool? includeQuotes { get; set; }
        public string? strategy { get; set; }
        public string? interval { get; set; }
        public double? strike { get; set; }
        public string? range { get; set; }
        public string? fromDate { get; set; }
        public string? toDate { get; set; }
        public float? volatility { get; set; }
        public double? underlyingPrice { get; set; }
        public float? interestRate { get; set; }
        public int? daysToExpiration { get; set; }
        public string? expMonth { get; set; }
        public string? optionType { get; set; }
    }
}
