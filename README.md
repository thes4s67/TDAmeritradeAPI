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

/*Streamer */
var streamer = new TDStreamer(userPrincipals);

//Streamer currently has 2 request examples: login and timesales in TDClient.cs. 
See https://developer.tdameritrade.com/content/streaming-data for more endpoints.

//Create a streamer request example
 var _TIMESALE_FUTURES = new StreamerSettings.Request
            {
                service = "TIMESALE_FUTURES",
                command = "SUBS",
                requestid = "1",
                account = userPrincipals.accounts[0].accountId,
                source = userPrincipals.streamerInfo.appId,
                parameters = new StreamerSettings.Parameters
                {
                    keys = "/ES,/CL",
                    fields = "0,1,2,3,4"
                }
            };
```

Web App:
- Add a callback url that includes "?handler=Callback" to your TD app on the developer page. 
  Example: https://localhost:44361/auth?handler=Callback
- Change the clientId and redirectUri variables in the Auth folder (Index.cshtml.cs)
- You may need to enable-migrations and change the SQL server connection string in the appsettings.json file
- Launch the webapp and navigate to Authenticate page. Sign in /w your TD account
- The access token is saved in the DB for future use

