using System;
using System.Diagnostics;
using System.Web;
using Newtonsoft.Json;
using TDAmeritradeAPI.Client;
using TDAmeritradeAPI.Fields;
using TDAmeritradeAPI.Models.Accounts_Trading;
using TDAmeritradeAPI.Props;
using TDAmeritradeAPI.Utilities;

namespace TDAmeritradeAPI.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // On the first execution, it may be ideal to place a breakpoint on the TDAuth.GetAccessToken method
            // Once you get the code and get the accessToken, comment out TDAuth.GetAuthCode and the TDAuth.GetAccessToken methods so they do not run again during your test.
            // This execution flow of obtaining the accessToken may be confusing and annoying but I believe you will understand why once you get more familiar with TD's api. 
            // On the positive side, the Web example is less annoying :D
            var clientId = "";
            var redirectUri = "";

            /* Get Code */
            // This will open up Chrome browser -- login in your TD account
            // You will be redirected to your redirectUri with the code
            //TDAuth.GetAuthCode(clientId, redirectUri);
            // Copy the code and paste it below
            var code = HttpUtility.UrlDecode("CODE_FROM_REDIRECT_URL");
            
            /* Get AccessToken */ 
            var accessToken = TDAuth.GetAccessToken(clientId, code, redirectUri).access_token;
            //var accessToken = "";
            var client = new TDClient(accessToken);

            /* Get Market Hours */
            //var hours = client.GetHoursForMultipleMarkets(new[] {MarketType.Bond, MarketType.Equity}, "2020-03-23");
            /* Get Market Hour */
            //var hour = client.GetHoursForSingleMarket(MarketType.Equity, "2020-03-23");

            /* Get Accounts */
            var accounts = client.GetAccounts(new [] {"positions", "orders"}).Result.Data;
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
            //var streamer = new TDStreamer(userPrincipals);

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
            //var update = client.UpdatePreferences(accounts[0].securitiesAccount.accountId, updatePreferencesSettings).Result.Success;

            /* Option Chain */
            var optionSettings = new OptionChainSettings
            {
                symbol = "ROKU",
                strikeCount = 3,
                strategy = Options.Strategy.Single
            };
            //var chain = client.GetOptionChain(optionSettings);

            /* Place Orders */
            /* Place Single Order */
            var order = new OrderSettings
            {
                orderType = Order.Type.Limit,
                price = 200.00,
                session = Order.MarketSession.Normal,
                duration = Order.Duration.GTC,
                orderStrategyType = Order.StrategyType.Single,
                orderLegCollection = new[]
                {
                    new OrderSettings.OrderLegCollection
                    {
                        instruction = Order.Instruction.Sell,
                        quantity = 300,
                        instrument = new OrderSettings.OrderLegCollection.Instrument
                        {
                            symbol = "ROKU",
                            assetType = Order.AssetType.Equity
                        }
                    }
                }
            };
            //var orderResult = client.PlaceOrder("", order).Result.Success;

            /* Place Option Vertical Spread */
            var order2 = new OrderSettings
            {
                orderType = Order.Type.Net_Credit,
                session = Order.MarketSession.Normal,
                duration = Order.Duration.GTC,
                price = 4.50,
                orderStrategyType = Order.StrategyType.Single,
                orderLegCollection = new[]
                {
                    new OrderSettings.OrderLegCollection
                    {
                        instruction = Order.Instruction.Sell_To_Open,
                        quantity = 1,
                        instrument = new OrderSettings.OrderLegCollection.Instrument
                        {
                            symbol = "ROKU_091622C100",
                            assetType = Order.AssetType.Option
                        }
                    },
                    new OrderSettings.OrderLegCollection
                    {
                        instruction = Order.Instruction.Buy_To_Open,
                        quantity = 1,
                        instrument = new OrderSettings.OrderLegCollection.Instrument
                        {
                            symbol = "ROKU_091622C105",
                            assetType = Order.AssetType.Option
                        }
                    }
                }
            };
            //var orderResult2 = client.PlaceOrder("", order2).Result.Success;

            /* Replace Order */
            var replaceOrder = new OrderSettings()
            {
                orderType = Order.Type.Limit,
                price = 200.01,
                session = Order.MarketSession.Normal,
                duration = Order.Duration.GTC,
                orderStrategyType = Order.StrategyType.Single,
                orderLegCollection = new[]
                {
                    new OrderSettings.OrderLegCollection
                    {
                        instruction = Order.Instruction.Sell,
                        quantity = 200,
                        instrument = new OrderSettings.OrderLegCollection.Instrument
                        {
                            symbol = "ROKU",
                            assetType = Order.AssetType.Equity
                        }
                    }
                }
            };
            //var replaceOrderResult = client.ReplaceOrder("", "", replaceOrder).Result.Success;

            /* Cancel Order */
            //var cancelOrder = client.CancelOrder("", "");

        }
    }


}
