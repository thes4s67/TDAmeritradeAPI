using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Models.Accounts_Trading
{
    public class Orders
    {
        public Order[] orders { get; set; }
        public class Order
        {
            public string session { get; set; }
            public string duration { get; set; }
            public string orderType { get; set; }
            public string complexOrderStrategyType { get; set; }
            public float quantity { get; set; }
            public float filledQuantity { get; set; }
            public float remainingQuantity { get; set; }
            public string requestedDestination { get; set; }
            public string destinationLinkName { get; set; }
            public float price { get; set; }
            public OrderLegCollection[] orderLegCollection { get; set; }
            public string orderStrategyType { get; set; }
            public int orderId { get; set; }
            public bool cancelable { get; set; }
            public bool editable { get; set; }
            public string status { get; set; }
            public DateTime enteredTime { get; set; }
            public DateTime closeTime { get; set; }
            public string tag { get; set; }
            public int accountId { get; set; }
            public OrderActivityCollection[] orderActivityCollection { get; set; }
        }

        public class OrderLegCollection
        {
            public string orderLegType { get; set; }
            public int legId { get; set; }
            public Instrument instrument { get; set; }
            public string instruction { get; set; }
            public string positionEffect { get; set; }
            public float quantity { get; set; }
        }

        public class Instrument
        {
            public string assetType { get; set; }
            public string cusip { get; set; }
            public string symbol { get; set; }
            public string description { get; set; }
            public string underlyingSymbol { get; set; }
        }

        public class OrderActivityCollection
        {
            public string activityType { get; set; }
            public string executionType { get; set; }
            public float quantity { get; set; }
            public float orderRemainingQuantity { get; set; }
            public ExecutionLeg[] executionLegs { get; set; }
        }

        public class ExecutionLeg
        {
            public int legId { get; set; }
            public float quantity { get; set; }
            public float mismarkedQuantity { get; set; }
            public float price { get; set; }
            public DateTime time { get; set; }
        }

    }
}
