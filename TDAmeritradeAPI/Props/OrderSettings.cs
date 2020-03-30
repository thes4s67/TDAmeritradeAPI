using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Props
{
    public class OrderSettings
    {
        public string session { get; set; }
        public string duration { get; set; }
        public string orderType { get; set; }
        public CancelTime cancelTime { get; set; }
        public class CancelTime
        {
            public string date { get; set; }
            public bool shortFormat { get; set; }
        }
        public string complexOrderStrategyType { get; set; }
        public double quantity { get; set; }
        public double remainingQuantity { get; set; }
        public string requestedDestination { get; set; }
        public string destinationLinkName { get; set; }
        public string releaseTime { get; set; }
        public double stopPrice { get; set; }
        public string stopPriceLinkBasis { get; set; }
        public string stopPriceLinkType { get; set; }
        public double stopPriceOffset { get; set; }
        public string stopType { get; set; }
        public string priceLinkBasis { get; set; }
        public string priceLinkType { get; set; }
        public double price { get; set; }
        public string taxLotMethod { get; set; }
        public OrderLegCollection[] orderLegCollection { get; set; }
        public class OrderLegCollection
        {
            public string orderLegType { get; set; }
            public long legId { get; set; }
            public Instrument instrument { get; set; }
            public class Instrument
            {
                public string assetType { get; set; }
                public string cusip { get; set; }
                public string symbol { get; set; }
                public string description { get; set; }
            }
            public string instruction { get; set; }
            public string positionEffect { get; set; }
            public double quantity { get; set; }
            public string quantityType { get; set; }
        }

        public double activationPrice { get; set; }
        public string specialInstruction { get; set; }
        public string orderStrategyType { get; set; }
        public long orderId { get; set; }
        public bool cancelable { get; set; }
        public bool editable { get; set; }
        public string status { get; set; }
        public string enteredTime { get; set; }
        public string closeTime { get; set; }
        public string tag { get; set; }
        public long accountId { get; set; }
        public OrderActivityCollection[] orderActivityCollection { get; set; }
        public class OrderActivityCollection
        {
            public string activityType { get; set; }
        }

        public ReplacingOrderCollection[] replacingOrderCollections { get; set; }
        public class ReplacingOrderCollection
        {

        }
        public ChildOrderStrategies[] childOrderStrategies { get; set; }
        public class ChildOrderStrategies
        {

        }
        public string statusDescription { get; set; }
    }
}
