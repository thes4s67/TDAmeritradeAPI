using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Models.Watchlist
{
    public class Watchlist
    {
        public WatchList[] watchlist { get; set; }

        public class WatchList
        {
            public string name { get; set; }
            public string watchlistId { get; set; }
            public string accountId { get; set; }
            public string status { get; set; }
            public WatchlistItem[] watchlistItems { get; set; }
        }

        public class WatchlistItem
        {
            public int sequenceId { get; set; }
            public int quantity { get; set; }
            public int averagePrice { get; set; }
            public int commission { get; set; }
            public string purchasedDate { get; set; }
            public Instrument instrument { get; set; }
            public string status { get; set; }
        }

        public class Instrument
        {
            public string symbol { get; set; }
            public string description { get; set; }
            public string assetType { get; set; }
        }

    }
}
