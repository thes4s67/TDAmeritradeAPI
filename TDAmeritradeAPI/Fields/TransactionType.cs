using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Fields
{
    /// <summary>
    /// Used for getting transactions
    /// </summary>
    public static class TransactionType
    {
        public const string
            All = "ALL",
            Trade = "TRADE",
            Buy_Only = "BUY_ONLY",
            Sell_Only = "SELL_ONLY",
            Cash_In_Or_Cash_Out = "CASH_IN_OR_CASH_OUT",
            Checking = "CHECKING",
            Dividend = "DIVIDEND",
            Interest = "INTEREST",
            Other = "OTHER",
            Advisor_Fees = "ADIVISOR_FEES";
    }
}
