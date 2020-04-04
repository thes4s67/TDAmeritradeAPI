using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TDAmeritradeAPI.Fields;
using TDAmeritradeAPI.Models.Accounts_Trading;
using TDAmeritradeAPI.Models.Auth;
using TDAmeritradeAPI.Models.Instruments;
using TDAmeritradeAPI.Models.Market_Hours;
using TDAmeritradeAPI.Models.Movers;
using TDAmeritradeAPI.Models.Options;
using TDAmeritradeAPI.Models.Price_History;
using TDAmeritradeAPI.Models.Quotes;
using TDAmeritradeAPI.Models.Transaction_History;
using TDAmeritradeAPI.Models.UserInfo_Preferences;
using TDAmeritradeAPI.Props;

namespace TDAmeritradeAPI.Client
{
    public partial class TDClient
    {
        /// <summary>
        ///  TD API Endpoints   
        /// </summary>
        private string
            MultipleMarketHours = "https://api.tdameritrade.com/v1/marketdata/hours",
            SingleMarketHours = "https://api.tdameritrade.com/v1/marketdata/{market}/hours",
            Accounts = "https://api.tdameritrade.com/v1/accounts",
            AccountById = "https://api.tdameritrade.com/v1/accounts/{accountId}",
            _CancelOrder = "https://api.tdameritrade.com/v1/accounts/{accountId}/orders/{orderId}",
            _GetOrder = "https://api.tdameritrade.com/v1/accounts/{accountId}/orders/{orderId}",
            _GetOrdersByPath = "https://api.tdameritrade.com/v1/accounts/{accountId}/orders",
            _GetOrdersByQuery = "https://api.tdameritrade.com/v1/orders",
            _PlaceOrder = "https://api.tdameritrade.com/v1/accounts/{accountId}/orders",
            _ReplaceOrder = "https://api.tdameritrade.com/v1/accounts/{accountId}/orders/{orderId}",
            _SavedOrder = "https://api.tdameritrade.com/v1/accounts/{accountId}/savedorders",
            //a few more order apis to add
            _GetMovers = "https://api.tdameritrade.com/v1/marketdata/{index}/movers",
            _GetPriceHistory = "https://api.tdameritrade.com/v1/marketdata/{symbol}/pricehistory",
            _GetQuote = "https://api.tdameritrade.com/v1/marketdata/{symbol}/quotes",
            _GetQuotes = "https://api.tdameritrade.com/v1/marketdata/quotes",
            _GetTransactions = "https://api.tdameritrade.com/v1/accounts/{accountId}/transactions",
            _GetTransaction = "https://api.tdameritrade.com/v1/accounts/{accountId}/transactions/{transactionId}",
            _GetPreferences = "https://api.tdameritrade.com/v1/accounts/{accountId}/preferences",
            _GetStreamerSubKeys = "https://api.tdameritrade.com/v1/userprincipals/streamersubscriptionkeys",
            _GetUserPrincipals = "https://api.tdameritrade.com/v1/userprincipals",
            _UpdatePreferences = "https://api.tdameritrade.com/v1/accounts/{accountId}/preferences",
            _GetOptionChain = "https://api.tdameritrade.com/v1/marketdata/chains";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="markets">Valid Markets: EQUITY, OPTION, FUTURE, BOND, or FOREX</param>
        /// <param name="date">Valid Formats yyyy-MM-dd or yyyy-MM-dd'T'HH:mm:ssz</param>
        /// <returns></returns>
        public async Task<TDResponse<MarketHours>> GetHoursForMultipleMarkets(string[] markets, string date)
        {
            var requestParams = new Dictionary<string, object>
            {
                //This will return delayed data
                //{"client_id", clientId},
                {"markets", string.Join(',', markets)},
                {"date", date}
            };
            return await ExecuteEndPoint<MarketHours>(MultipleMarketHours, requestParams, Method.GET);
        }

        public async Task<TDResponse<MarketHours>> GetHoursForSingleMarket(string market, string date)
        {
            var requestParams = new Dictionary<string, object>
            {
                //This will return delayed data
                //{"client_id", clientId},
                {"date", date}
            };
            return await ExecuteEndPoint<MarketHours>(SingleMarketHours.Replace("{market}", market), requestParams, Method.GET);
        }

        #region Accounts & Trading
        /// <summary>
        /// Get Account balances, positions, and orders for all linked accounts.
        /// </summary>
        /// <param name="fields">Valid Fields: Positions and/or Orders</param>
        /// <returns></returns>
        public async Task<TDResponse<Accounts[]>> GetAccounts(string[] fields)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"fields", string.Join(',', fields)}
            };
            return await ExecuteEndPoint<Accounts[]>(Accounts, requestParams, Method.GET);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<TDResponse<Accounts>> GetAccountById(string field, string accountId)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"fields", field}
            };
            return await ExecuteEndPoint<Accounts>(AccountById.Replace("{accountId}", accountId), requestParams, Method.GET);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<TDResponse<Accounts>> GetAccountById(string[] fields, string accountId)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"fields", string.Join(',', fields)}
            };
            return await ExecuteEndPoint<Accounts>(AccountById.Replace("{accountId}", accountId), requestParams, Method.GET);
        }
        /// <summary>
        /// Cancel a specific order for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<TDResponse<Accounts>> CancelOrder(string accountId, string orderId)
        {
            _CancelOrder = _CancelOrder.Replace("{accountId}", accountId);
            _CancelOrder = _CancelOrder.Replace("{orderId}", orderId);
            return await ExecuteEndPoint<Accounts>(_CancelOrder, null, Method.DELETE);
        }
        /// <summary>
        /// Get a specific order for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<TDResponse<Orders>> GetOrder(string accountId, string orderId)
        {
            _GetOrder = _GetOrder.Replace("{accountId}", accountId);
            _GetOrder = _GetOrder.Replace("{orderId}", orderId);
            return await ExecuteEndPoint<Orders>(_GetOrder, null, Method.GET);
        }
        /// <summary>
        /// Get all orders for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="maxResults"></param>
        /// <param name="fromEnteredTime"></param>
        /// <param name="toEnteredTime"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public async Task<TDResponse<Orders>> GetOrdersSingleAccount(string accountId, int maxResults, string fromEnteredTime, string toEnteredTime, string orderStatus)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"maxResults", maxResults},
                {"fromEnteredTime", fromEnteredTime},
                {"toEnteredTime", toEnteredTime},
                {"status", orderStatus}
            };
            _GetOrdersByPath = _GetOrdersByPath.Replace("{accountId}", accountId);
            return await ExecuteEndPoint<Orders>(_GetOrdersByPath, requestParams, Method.GET);
        }
        /// <summary>
        /// Get all orders for all linked accounts
        /// </summary>
        /// <param name="maxResults"></param>
        /// <param name="fromEnteredTime"></param>
        /// <param name="toEnteredTime"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public async Task<TDResponse<Orders>> GetOrdersAllAccounts(int maxResults, string fromEnteredTime, string toEnteredTime, string orderStatus)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"maxResults", maxResults},
                {"fromEnteredTime", fromEnteredTime},
                {"toEnteredTime", toEnteredTime},
                {"status", orderStatus}
            };
            return await ExecuteEndPoint<Orders>(_GetOrdersByQuery, requestParams, Method.GET);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="placeOrder"></param>
        /// <returns></returns>
        public async Task<TDResponse<Orders>> PlaceOrder(string accountId, OrderSettings placeOrder)
        {
            return await ExecuteEndPoint<Orders>(_PlaceOrder.Replace("{accountId}", accountId), placeOrder, Method.POST);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="replaceOrder"></param>
        /// <returns></returns>
        public async Task<TDResponse<Orders>> ReplaceOrder(string accountId, string orderId, OrderSettings replaceOrder)
        {
            _ReplaceOrder = _ReplaceOrder.Replace("{accountId}", accountId);
            _ReplaceOrder = _ReplaceOrder.Replace("{orderId}", orderId);
            return await ExecuteEndPoint<Orders>(_ReplaceOrder, replaceOrder, Method.PUT);
        }
        /// <summary>
        /// Save an order for a specific account.
        /// </summary>
        /// <param name="saveOrder"></param>
        /// <returns></returns>
        public async Task<TDResponse<Orders>> SaveOrder(string accountId, OrderSettings saveOrder)
        {
            _SavedOrder = _SavedOrder.Replace("{accountId}", accountId);
            return await ExecuteEndPoint<Orders>(_SavedOrder, saveOrder, Method.POST);
        }
        #endregion

        #region Get Movers
        /// <summary>
        /// Get Top 10 (up or down) movers by value or percent for a particular market
        /// </summary>
        /// <param name="index">The index symbol to get movers from. Can be $COMPX, $DJI, or $SPX.X.</param>
        /// <param name="direction"></param>
        /// <param name="changeType"></param>
        /// <returns></returns>
        public async Task<TDResponse<Mover>> GetMovers(string index, string direction, string changeType)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"direction", direction},
                {"change", changeType}
            };
            return await ExecuteEndPoint<Mover>(_GetMovers.Replace("{index}", index), requestParams, Method.GET);
        }
        #endregion

        #region Get Price History
        public async Task<TDResponse<PriceHistory>> GetPriceHistory(PriceHistorySettings priceHistory)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"periodType", priceHistory.periodType},
                {"period", priceHistory.period},
                {"frequencyType", priceHistory.frequencyType},
                {"frequency", priceHistory.frequency},
                //{"endDate", priceHistory.endDate},
                //{"startDate", priceHistory.startDate},
                {"needExtendedHoursData", priceHistory.needExtendedHoursData},
            };
            return await ExecuteEndPoint<PriceHistory>(_GetPriceHistory.Replace("{symbol}", priceHistory.symbol), requestParams, Method.GET);
        }
        #endregion

        #region Get Quotes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<TDResponse<QuoteList>> GetQuote(string symbol)
        {
            return await ExecuteEndPoint<QuoteList>(_GetQuote.Replace("{symbol}", symbol), null, Method.GET);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        public async Task<TDResponse<QuoteList>> GetQuotes(string[] symbols)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"symbol", string.Join(',', symbols)}
            };
            return await ExecuteEndPoint<QuoteList>(_GetQuotes, requestParams, Method.GET);
        }
        #endregion

        #region Transactions
        /// <summary>
        /// Get transactions for a specific account.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task<TDResponse<Transactions>> GetTransactions(TransactionsSettings settings)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"type", settings.type},
                {"symbol", settings.symbol},
                {"startDate", settings.startDate},
                {"endDate", settings.endDate},
            };
            return await ExecuteEndPoint<Transactions>(_GetTransactions.Replace("{accountId}", settings.accountId.ToString()), requestParams, Method.GET);
        }
        public async Task<TDResponse<Transactions>> GetTransaction(string accountId, string transactionId)
        {
            //TODO: This throws a not found when executing
            _GetTransaction = _GetTransaction.Replace("{accountId}", accountId);
            _GetTransaction = _GetTransaction.Replace("{transactionId}", transactionId);
            return await ExecuteEndPoint<Transactions>(_GetTransaction, null, Method.GET);
        }
        #endregion

        #region UserInfo and Preferences
        public async Task<TDResponse<Preferences>> GetPreferences(string accountId)
        {
            _GetPreferences = _GetPreferences.Replace("{accountId}", accountId);
            return await ExecuteEndPoint<Preferences>(_GetPreferences, null, Method.GET);
        }
        public async Task<TDResponse<SubscriptionKey>> GetStreamerSubKeys(string[] accountIds)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"accountIds", string.Join(',', accountIds)},
            };
            return await ExecuteEndPoint<SubscriptionKey>(_GetStreamerSubKeys, requestParams, Method.GET);
        }
        public async Task<TDResponse<UserPrincipals>> GetUserPrincipals(string[] fields)
        {
            var requestParams = new Dictionary<string, object>
            {
                {"fields", string.Join(',', fields)},
            };
            return await ExecuteEndPoint<UserPrincipals>(_GetUserPrincipals, requestParams, Method.GET);
        }
        public async Task<TDResponse<UserPrincipals>> UpdatePreferences(string accountId, UpdatePreferencesSettings settings)
        {
            return await ExecuteEndPoint<UserPrincipals>(_UpdatePreferences.Replace("{accountId}", accountId), settings, Method.PUT);
        }
        #endregion

        #region OptionChain
        public async Task<TDResponse<OptionChain>> GetOptionChain(OptionChainSettings settings)
        {
            var requestParams = settings.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(p => p.Name, p => p.GetValue(settings, null));
            return await ExecuteEndPoint<OptionChain>(_GetOptionChain, requestParams, Method.GET);
        }

        #endregion
        public async Task<TDResponse<Instrument>> SearchInstruments(string symbol, Instruments projection)
        {
            return null;
        }
    }
}
