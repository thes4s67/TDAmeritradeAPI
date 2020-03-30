using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Models.Accounts_Trading
{
    public class Accounts
    {
        public TDAccounts[] accounts { get; set; }

        public class TDAccounts
        {
            public SecuritiesAccount securitiesAccount { get; set; }
        }

        public class SecuritiesAccount
        {
            public string type { get; set; }
            public string accountId { get; set; }
            public int roundTrips { get; set; }
            public bool isDayTrader { get; set; }
            public bool isClosingOnlyRestricted { get; set; }
            public Position[] positions { get; set; }
            public InitialBalances initialBalances { get; set; }
            public CurrentBalances currentBalances { get; set; }
            public ProjectedBalances projectedBalances { get; set; }
        }

        public class InitialBalances
        {
            public float accruedInterest { get; set; }
            public float availableFundsNonMarginableTrade { get; set; }
            public float bondValue { get; set; }
            public float buyingPower { get; set; }
            public float cashBalance { get; set; }
            public float cashAvailableForTrading { get; set; }
            public float cashReceipts { get; set; }
            public float dayTradingBuyingPower { get; set; }
            public float dayTradingBuyingPowerCall { get; set; }
            public float dayTradingEquityCall { get; set; }
            public float equity { get; set; }
            public float equityPercentage { get; set; }
            public float liquidationValue { get; set; }
            public float longMarginValue { get; set; }
            public float longOptionMarketValue { get; set; }
            public float longStockValue { get; set; }
            public float maintenanceCall { get; set; }
            public float maintenanceRequirement { get; set; }
            public float margin { get; set; }
            public float marginEquity { get; set; }
            public float moneyMarketFund { get; set; }
            public float mutualFundValue { get; set; }
            public float regTCall { get; set; }
            public float shortMarginValue { get; set; }
            public float shortOptionMarketValue { get; set; }
            public float shortStockValue { get; set; }
            public float totalCash { get; set; }
            public bool isInCall { get; set; }
            public float pendingDeposits { get; set; }
            public float marginBalance { get; set; }
            public float shortBalance { get; set; }
            public float accountValue { get; set; }
        }

        public class CurrentBalances
        {
            public float accruedInterest { get; set; }
            public float cashBalance { get; set; }
            public float cashReceipts { get; set; }
            public float longOptionMarketValue { get; set; }
            public float liquidationValue { get; set; }
            public float longMarketValue { get; set; }
            public float moneyMarketFund { get; set; }
            public float savings { get; set; }
            public float shortMarketValue { get; set; }
            public float pendingDeposits { get; set; }
            public float availableFunds { get; set; }
            public float availableFundsNonMarginableTrade { get; set; }
            public float buyingPower { get; set; }
            public float buyingPowerNonMarginableTrade { get; set; }
            public float dayTradingBuyingPower { get; set; }
            public float equity { get; set; }
            public float equityPercentage { get; set; }
            public float longMarginValue { get; set; }
            public float maintenanceCall { get; set; }
            public float maintenanceRequirement { get; set; }
            public float marginBalance { get; set; }
            public float regTCall { get; set; }
            public float shortBalance { get; set; }
            public float shortMarginValue { get; set; }
            public float shortOptionMarketValue { get; set; }
            public float sma { get; set; }
            public float mutualFundValue { get; set; }
            public float bondValue { get; set; }
        }

        public class ProjectedBalances
        {
            public float availableFunds { get; set; }
            public float availableFundsNonMarginableTrade { get; set; }
            public float buyingPower { get; set; }
            public float dayTradingBuyingPower { get; set; }
            public float dayTradingBuyingPowerCall { get; set; }
            public float maintenanceCall { get; set; }
            public float regTCall { get; set; }
            public bool isInCall { get; set; }
            public float stockBuyingPower { get; set; }
        }

        public class Position
        {
            public float shortQuantity { get; set; }
            public float averagePrice { get; set; }
            public float currentDayProfitLoss { get; set; }
            public float currentDayProfitLossPercentage { get; set; }
            public float longQuantity { get; set; }
            public float settledLongQuantity { get; set; }
            public float settledShortQuantity { get; set; }
            public Instrument instrument { get; set; }
            public float marketValue { get; set; }
            public float maintenanceRequirement { get; set; }
        }

        public class Instrument
        {
            public string assetType { get; set; }
            public string cusip { get; set; }
            public string symbol { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public string putCall { get; set; }
            public string underlyingSymbol { get; set; }
        }

    }
}
