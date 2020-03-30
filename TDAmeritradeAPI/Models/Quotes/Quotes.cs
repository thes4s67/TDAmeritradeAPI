using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using TDAmeritradeAPI.Utilities;

namespace TDAmeritradeAPI.Models.Quotes
{
    [JsonConverter(typeof(QuoteConverter))]
    public class QuoteList
    {
        public List<Quote> Quotes { get; set; }
    }

    public class Quote
    {
        public string assetType { get; set; }
        public string assetMainType { get; set; }
        public string cusip { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public float bidPrice { get; set; }
        public int bidSize { get; set; }
        public string bidId { get; set; }
        public float askPrice { get; set; }
        public int askSize { get; set; }
        public string askId { get; set; }
        public float lastPrice { get; set; }
        public int lastSize { get; set; }
        public string lastId { get; set; }
        public float openPrice { get; set; }
        public float highPrice { get; set; }
        public float lowPrice { get; set; }
        public string bidTick { get; set; }
        public float closePrice { get; set; }
        public float netChange { get; set; }
        public int totalVolume { get; set; }
        public long quoteTimeInLong { get; set; }
        public long tradeTimeInLong { get; set; }
        public float mark { get; set; }
        public string exchange { get; set; }
        public string exchangeName { get; set; }
        public bool marginable { get; set; }
        public bool shortable { get; set; }
        public float volatility { get; set; }
        public int digits { get; set; }
        [JsonProperty("52WkHigh")] 
        public float _52WkHigh { get; set; }
        [JsonProperty("52WkLow")] 
        public float _52WkLow { get; set; }
        public float nAV { get; set; }
        public float peRatio { get; set; }
        public float divAmount { get; set; }
        public float divYield { get; set; }
        public string divDate { get; set; }
        public string securityStatus { get; set; }
        public float regularMarketLastPrice { get; set; }
        public int regularMarketLastSize { get; set; }
        public float regularMarketNetChange { get; set; }
        public long regularMarketTradeTimeInLong { get; set; }
        public float netPercentChangeInDouble { get; set; }
        public float markChangeInDouble { get; set; }
        public float markPercentChangeInDouble { get; set; }
        public float regularMarketPercentChangeInDouble { get; set; }
        public bool delayed { get; set; }
    }
}