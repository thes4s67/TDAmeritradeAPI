using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Models.Transaction_History
{
    public class Transactions
    {
        public Transaction[] transactions { get; set; }
        public class Transaction
        {
            public string type { get; set; }
            public string subAccount { get; set; }
            public string settlementDate { get; set; }
            public string orderId { get; set; }
            public float netAmount { get; set; }
            public DateTime transactionDate { get; set; }
            public DateTime orderDate { get; set; }
            public string transactionSubType { get; set; }
            public long transactionId { get; set; }
            public bool cashBalanceEffectFlag { get; set; }
            public string description { get; set; }
            public Fees fees { get; set; }
            public TransactionItem transactionItem { get; set; }
        }

        public class Fees
        {
            public float rFee { get; set; }
            public float additionalFee { get; set; }
            public float cdscFee { get; set; }
            public float regFee { get; set; }
            public float otherCharges { get; set; }
            public float commission { get; set; }
            public float optRegFee { get; set; }
            public float secFee { get; set; }
        }

        public class TransactionItem
        {
            public int accountId { get; set; }
            public float amount { get; set; }
            public float price { get; set; }
            public float cost { get; set; }
            public string instruction { get; set; }
            public string positionEffect { get; set; }
            public Instrument instrument { get; set; }
        }

        public class Instrument
        {
            public string symbol { get; set; }
            public string underlyingSymbol { get; set; }
            public DateTime optionExpirationDate { get; set; }
            public string putCall { get; set; }
            public string cusip { get; set; }
            public string description { get; set; }
            public string assetType { get; set; }
        }

    }
}
