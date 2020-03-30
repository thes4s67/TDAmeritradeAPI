using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TDAmeritradeAPI.Models.Options
{
    public class OptionChain
    {

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("underlying")]
        public Underlying underlying { get; set; }

        [JsonProperty("strategy")]
        public string Strategy { get; set; }

        [JsonProperty("interval")]
        public object Interval { get; set; }

        [JsonProperty("isDelayed")]
        public bool IsDelayed { get; set; }

        [JsonProperty("isIndex")]
        public bool IsIndex { get; set; }

        [JsonProperty("interestRate")]
        public double InterestRate { get; set; }

        [JsonProperty("underlyingPrice")]
        public double UnderlyingPrice { get; set; }

        [JsonProperty("volatility")]
        public long Volatility { get; set; }

        [JsonProperty("daysToExpiration")]
        public long DaysToExpiration { get; set; }

        [JsonProperty("numberOfContracts")]
        public long numberOfContracts { get; set; }
        public float[] intervals { get; set; }
        public MonthlyStrategyList[] monthlyStrategyList { get; set; }

        [JsonProperty("callExpDateMap")]
        public Dictionary<string, Dictionary<string, ExpDateMap[]>> CallExpDateMap { get; set; }

        [JsonProperty("putExpDateMap")]
        public Dictionary<string, Dictionary<string, ExpDateMap[]>> PutExpDateMap { get; set; }

        public class ExpDateMap
        {
            [JsonProperty("putCall")]
            public string PutCall { get; set; }

            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("exchangeName")]
            public string ExchangeName { get; set; }

            [JsonProperty("bid")]
            public double Bid { get; set; }

            [JsonProperty("ask")]
            public double Ask { get; set; }

            [JsonProperty("last")]
            public double Last { get; set; }

            [JsonProperty("mark")]
            public double Mark { get; set; }

            [JsonProperty("bidSize")]
            public long BidSize { get; set; }

            [JsonProperty("askSize")]
            public long AskSize { get; set; }

            [JsonProperty("lastSize")]
            public long LastSize { get; set; }

            [JsonProperty("highPrice")]
            public double HighPrice { get; set; }

            [JsonProperty("lowPrice")]
            public double LowPrice { get; set; }

            [JsonProperty("openPrice")]
            public long OpenPrice { get; set; }

            [JsonProperty("closePrice")]
            public double ClosePrice { get; set; }

            [JsonProperty("totalVolume")]
            public long TotalVolume { get; set; }

            [JsonProperty("tradeDate")]
            public object TradeDate { get; set; }

            [JsonProperty("tradeTimeInLong")]
            public long TradeTimeInLong { get; set; }

            [JsonProperty("quoteTimeInLong")]
            public long QuoteTimeInLong { get; set; }

            [JsonProperty("netChange")]
            public double NetChange { get; set; }

            [JsonProperty("volatility")]
            public double Volatility { get; set; }

            [JsonProperty("delta")]
            public double Delta { get; set; }

            [JsonProperty("gamma")]
            public double Gamma { get; set; }

            [JsonProperty("theta")]
            public double Theta { get; set; }

            [JsonProperty("vega")]
            public double Vega { get; set; }

            [JsonProperty("rho")]
            public double Rho { get; set; }

            [JsonProperty("openInterest")]
            public long OpenInterest { get; set; }

            [JsonProperty("timeValue")]
            public double TimeValue { get; set; }

            [JsonProperty("theoreticalOptionValue")]
            public double TheoreticalOptionValue { get; set; }

            [JsonProperty("theoreticalVolatility")]
            public long TheoreticalVolatility { get; set; }

            [JsonProperty("optionDeliverablesList")]
            public object OptionDeliverablesList { get; set; }

            [JsonProperty("strikePrice")]
            public double StrikePrice { get; set; }

            [JsonProperty("expirationDate")]
            public long ExpirationDate { get; set; }

            [JsonProperty("daysToExpiration")]
            public long DaysToExpiration { get; set; }

            [JsonProperty("expirationType")]
            public string ExpirationType { get; set; }

            [JsonProperty("lastTradingDay")]
            public long LastTradingDay { get; set; }

            [JsonProperty("multiplier")]
            public long Multiplier { get; set; }

            [JsonProperty("settlementType")]
            public string SettlementType { get; set; }

            [JsonProperty("deliverableNote")]
            public string DeliverableNote { get; set; }

            [JsonProperty("isIndexOption")]
            public object IsIndexOption { get; set; }

            [JsonProperty("percentChange")]
            public double PercentChange { get; set; }

            [JsonProperty("markChange")]
            public double MarkChange { get; set; }

            [JsonProperty("markPercentChange")]
            public double MarkPercentChange { get; set; }

            [JsonProperty("nonStandard")]
            public bool NonStandard { get; set; }

            [JsonProperty("inTheMoney")]
            public bool InTheMoney { get; set; }

            [JsonProperty("mini")]
            public bool Mini { get; set; }
        }

        public class MonthlyStrategyList
        {
            public string month { get; set; }
            public int year { get; set; }
            public int day { get; set; }
            public int daysToExp { get; set; }
            public string secondaryMonth { get; set; }
            public int secondaryYear { get; set; }
            public int secondaryDay { get; set; }
            public int secondaryDaysToExp { get; set; }
            public string type { get; set; }
            public string secondaryType { get; set; }
            public bool leap { get; set; }
            public OptionStrategyList[] optionStrategyList { get; set; }
            public bool secondaryLeap { get; set; }
        }

        public class OptionStrategyList
        {
            public PrimaryLeg primaryLeg { get; set; }
            public SecondaryLeg secondaryLeg { get; set; }
            public string strategyStrike { get; set; }
            public float strategyBid { get; set; }
            public float strategyAsk { get; set; }
        }

        public class PrimaryLeg
        {
            public string symbol { get; set; }
            public string putCallInd { get; set; }
            public string description { get; set; }
            public float bid { get; set; }
            public float ask { get; set; }
            public string range { get; set; }
            public float strikePrice { get; set; }
            public float totalVolume { get; set; }
        }

        public class SecondaryLeg
        {
            public string symbol { get; set; }
            public string putCallInd { get; set; }
            public string description { get; set; }
            public float bid { get; set; }
            public float ask { get; set; }
            public string range { get; set; }
            public float strikePrice { get; set; }
            public float totalVolume { get; set; }
        }

        public class Underlying
        {
            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("change")]
            public long Change { get; set; }

            [JsonProperty("percentChange")]
            public long PercentChange { get; set; }

            [JsonProperty("close")]
            public double Close { get; set; }

            [JsonProperty("quoteTime")]
            public long QuoteTime { get; set; }

            [JsonProperty("tradeTime")]
            public long TradeTime { get; set; }

            [JsonProperty("bid")]
            public double Bid { get; set; }

            [JsonProperty("ask")]
            public double Ask { get; set; }

            [JsonProperty("last")]
            public double Last { get; set; }

            [JsonProperty("mark")]
            public double Mark { get; set; }

            [JsonProperty("markChange")]
            public long MarkChange { get; set; }

            [JsonProperty("markPercentChange")]
            public long MarkPercentChange { get; set; }

            [JsonProperty("bidSize")]
            public long BidSize { get; set; }

            [JsonProperty("askSize")]
            public long AskSize { get; set; }

            [JsonProperty("highPrice")]
            public double HighPrice { get; set; }

            [JsonProperty("lowPrice")]
            public double LowPrice { get; set; }

            [JsonProperty("openPrice")]
            public double OpenPrice { get; set; }

            [JsonProperty("totalVolume")]
            public long TotalVolume { get; set; }

            [JsonProperty("exchangeName")]
            public string ExchangeName { get; set; }

            [JsonProperty("fiftyTwoWeekHigh")]
            public double FiftyTwoWeekHigh { get; set; }

            [JsonProperty("fiftyTwoWeekLow")]
            public double FiftyTwoWeekLow { get; set; }

            [JsonProperty("delayed")]
            public bool Delayed { get; set; }
        }
    }
}
