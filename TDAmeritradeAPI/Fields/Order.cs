namespace TDAmeritradeAPI.Fields
{
    public static class Order
    {
        public static class Duration
        {
            public const string
                Day = "DAY",
                GTC = "GOOD_TILL_CANCEL",
                None = "None";
        }
        public static class Instruction
        {
            public const string
                Buy = "BUY",
                Sell = "SELL",
                Buy_To_Cover = "BUY_TO_COVER",
                Sell_Short = "SELL_SHORT",
                None = "NONE";
        }
        /// <summary>
        /// Used for updating preferences for a specific account
        /// </summary>
        public static class MarketSession
        {
            public const string
                AM = "AM",
                PM = "PM",
                Normal = "NORMAL",
                Seamless = "SEAMLESS",
                None = "NONE";
        }
        /// <summary>
        /// Used for updating preferences for a specific account
        /// </summary>
        public static class PriceLinkType
        {
            public const string
                Value = "VALUE",
                Percent = "PERCENT",
                None = "NONE";
        }
        public static class Status
        {
            public const string
                Awaiting_Parent_Order = "AWAITING_PARENT_ORDER",
                Awaiting_Condition = "AWAITING_CONDITION",
                Awaiting_Manual_Review = "AWAITING_MANUAL_REVIEW",
                Accepted = "ACCEPTED",
                Awaiting_Ur_Out = "AWAITING_UR_OUT",
                Pending_Activation = "PENDING_ACTIVATION",
                Queued = "QUEUED",
                Working = "WORKING",
                Rejected = "REJECTED",
                Pending_Cancel = "PENDING_CANCEL",
                Canceled = "CANCELED",
                Pending_Replace = "PENDING_REPLACE",
                Replaced = "REPLACED",
                Filled = "FILLED",
                Expired = "EXPIRED";
        }
        public static class Type
        {
            public const string
                Market = "MARKET",
                Limit = "LIMIT",
                Stop = "STOP",
                Stop_Limit = "STOP_LIMIT",
                Trailing_Stop = "TRAILING_STOP",
                Market_On_Close = "MARKET_ON_CLOSE",
                Exercise = "EXERCISE",
                Trailing_Stop_Limit = "TRAILING_STOP_LIMIT",
                Net_Debit = "NET_DEBIT",
                Net_Credit = "NET_CREDIT",
                Net_Zero = "NET_ZERO";
        }
    }
}