# TDAmeritradeAPI
TDAmeritrade client library for .NET developers. Get stock quotes, account information, post trades, connect to TD websocket endpoints for realtime data, and much more! Examples provided for console app and ASP.NET.

# Getting Started
Console App:
```
/* Get Code */
//This will open up Chrome browser -- login in your TD account
// You will be redirected to your redirectUri with the code
TDAuth.GetAuthCode(clientId, redirectUri);

/* Get AccessToken */
var accessToken = TDAuth.GetAccessToken(clientId, code, redirectUri).access_token;
var client = new TDClient(accessToken, clientId);

/* Get Historical Chart Data for ROKU */
var priceHistory = new PriceHistorySettings
{
      symbol = "ROKU",
      periodType = PeriodType.Month,
      period = 6,
      frequencyType = FrequencyType.Daily,
      frequency = 1,
      needExtendedHoursData = true
};
var historicalData = client.GetPriceHistory(priceHistory).Result.Data;
```

Web App:
Coming soon!

For TD Endpoints, see https://developer.tdameritrade.com/apis

TODO:
- Lots left to do!
- Streamer currently only logins
- Currently cannot post trades
- Most TD endpoints are functional but needs more work.
