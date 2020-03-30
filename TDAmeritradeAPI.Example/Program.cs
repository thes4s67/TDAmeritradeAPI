using System;
using System.Diagnostics;
using System.Web;
using Newtonsoft.Json;
using TDAmeritradeAPI.Client;
using TDAmeritradeAPI.Fields;
using TDAmeritradeAPI.Props;
using TDAmeritradeAPI.Utilities;

namespace TDAmeritradeAPI.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientId = "";
            var redirectUri = "";

            /* Get Code */
            // This will open up Chrome browser -- login in your TD account
            // You will be redirected to your redirectUri with the code
            TDAuth.GetAuthCode(clientId, redirectUri);
            // Copy the code and paste it below
            var code = HttpUtility.UrlDecode("");
            
            /* Get AccessToken */
            var accessToken = TDAuth.GetAccessToken(clientId, code, redirectUri).access_token;
            var client = new TDClient(accessToken, clientId);

            /* Get Market Hours */
            //var hours = client.GetHoursForMultipleMarkets(new[] {MarketType.Bond, MarketType.Equity}, "2020-03-23");
            /* Get Market Hour */
            //var hour = client.GetHoursForSingleMarket(MarketType.Equity, "2020-03-23");

            /* Get Accounts */
            //var accounts = client.GetAccounts("positions").Result.Data.accounts;
            /* Get Account by AccountById */

            /* Get Orders By Path */
            //var ordersByPath = client.GetOrdersAllAccounts(10, "2020-01-01", DateTime.Today.ToString("yyyy-MM-dd"), OrderStatus.Filled);
            
            /* Get Movers */
            //var movers = client.GetMovers("$DJI", Direction.Up.ToLower(), Change.Value.ToLower());

            /* Get Price History */
            var priceHistory = new PriceHistorySettings
            {
                symbol = "ROKU",
                periodType = PeriodType.Month,
                period = 6,
                frequencyType = FrequencyType.Daily,
                frequency = 1,
                needExtendedHoursData = true
            };
            //var historicalData = client.GetPriceHistory(priceHistory).Result.Data;

            /* Get Single Quote */
            //var quote = client.GetQuote("ROKU").Result.Data;
            /* Get Multiple Quotes */
            //var quotes = client.GetQuotes(new[] {"ROKU", "AAPL", "TSLA"});

            /* Get Transactions */
            var transactionSettings = new TransactionsSettings
            {
                accountId = 0,
                symbol = "ROKU",
                startDate = "2020-01-01",
                endDate = DateTime.Today.ToString("yyyy-MM-dd"),
                type = TransactionType.All
            };
            //var transactions = client.GetTransactions(transactionSettings);
            /* Get Transaction By TransactionId */
            //var transaction = client.GetTransaction("", "");

            /* Get Preferences */
            //var pref = client.GetPreferences("");

            /* Get Streamer Sub Keys */
            //var keys = client.GetStreamerSubKeys(new[] {""});

            /* Get User Principals */
            var userPrincipals = client.GetUserPrincipals(new[] { "streamerSubscriptionKeys", "streamerConnectionInfo", "preferences", "surrogateIds" }).Result.Data;
            
            /* Steamer */
            var streamer = new TDStreamer(userPrincipals);

            /* Update Preferences */
            var updatePreferencesSettings = new UpdatePreferencesSettings
            {
                expressTrading = true,
                defaultEquityOrderLegInstruction = Order.Instruction.Buy,
                defaultEquityOrderType = Order.Type.Limit,
                defaultEquityOrderPriceLinkType = Order.PriceLinkType.None,
                defaultEquityOrderDuration = Order.Duration.Day,
                defaultEquityOrderMarketSession = Order.MarketSession.Normal,
                defaultEquityQuantity = 100,
                mutualFundTaxLotMethod = TaxLotMethod.LIFO,
                optionTaxLotMethod = TaxLotMethod.LIFO,
                equityTaxLotMethod = TaxLotMethod.LIFO,
                defaultAdvancedToolLaunch = AvancedToolLaunch.N,
                authTokenTimeout = AuthTokenTimeOut.Fifty_Five_Minutes
            };
            //var update = client.UpdatePreferences("", updatePreferencesSettings).Result.Success;

            var optionSettings = new OptionChainSettings
            {
                symbol = "ROKU",
                strikeCount = 3,
                strategy = Options.Strategy.Single
            };
            //var chain = client.GetOptionChain(optionSettings);
            
        }
    }


}
