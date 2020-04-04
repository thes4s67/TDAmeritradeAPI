using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TDAmeritradeAPI.Models.UserInfo_Preferences;
using TDAmeritradeAPI.Props;
using Websocket.Client;

namespace TDAmeritradeAPI.Client
{
    public class TDStreamer
    {
        private StreamerSettings.Credentials _credentials;
        private StreamerSettings.Request _loginRequest;
        private StreamerSettings.Request _TIMESALE_FUTURES;
        private WebsocketClient _ws;
        public TDStreamer(UserPrincipals userPrincipals)
        {
            _credentials = new StreamerSettings.Credentials
            {
                userid = userPrincipals.accounts[0].accountId,
                token = userPrincipals.streamerInfo.token,
                company = userPrincipals.accounts[0].company,
                segment = userPrincipals.accounts[0].segment,
                cddomain = userPrincipals.accounts[0].accountCdDomainId,
                usergroup = userPrincipals.streamerInfo.userGroup,
                accesslevel = userPrincipals.streamerInfo.accessLevel,
                authorized = "Y",
                timestamp = Convert.ToInt64(ConvertToUnixTimestamp(Convert.ToDateTime(userPrincipals.streamerInfo.tokenTimestamp))),
                appid = userPrincipals.streamerInfo.appId,
                acl = userPrincipals.streamerInfo.acl
            };

            //Convert credentials to dictionary
            var cred = _credentials.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(p => p.Name, p => p.GetValue(_credentials, null));

            var _reqs = new List<StreamerSettings.Request>();

            _loginRequest = new StreamerSettings.Request
            {
                service = "ADMIN",
                command = "LOGOUT",
                requestid = "0",
                account = userPrincipals.accounts[0].accountId,
                source = userPrincipals.streamerInfo.appId,
                parameters = new StreamerSettings.Parameters
                {
                    credential = ToQueryString(cred),
                    token = userPrincipals.streamerInfo.token,
                    version = "1.0"
                }
            };
     
            _reqs.Add(_loginRequest);

            /*_TIMESALE_FUTURES = new StreamerSettings.Request
            {
                service = "TIMESALE_FUTURES",
                command = "SUBS",
                requestid = "2",
                account = userPrincipals.accounts[0].accountId,
                source = userPrincipals.streamerInfo.appId,
                parameters = new StreamerSettings.Parameters
                {
                    keys = "/ES",
                    fields = "0,1,2,3,4"
                }
            };*/
            //_reqs.Add(_TIMESALE_FUTURES);

            var request = new StreamerSettings.Requests()
            {
                requests = _reqs.ToArray()
            };

            
            var exitEvent = new ManualResetEvent(false);

            var url = new Uri($"wss://{userPrincipals.streamerInfo.streamerSocketUrl}/ws");
            using (var client = new WebsocketClient(url))
            {
                client.ReconnectTimeout = TimeSpan.FromSeconds(30);
                client.ReconnectionHappened.Subscribe(info =>
                    Console.WriteLine($"Reconnection happened, type: {info.Type}"));

                client.MessageReceived.Subscribe(msg => Console.WriteLine($"Message received: {msg}"));
                client.Start();

                var req = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore});
                Task.Run(() => client.Send(JsonConvert.SerializeObject(req)));
                exitEvent.WaitOne();
            }


            Console.ReadLine();
        }

        private static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalMilliseconds);
        }

        public static string ToQueryString(Dictionary<string, object> dict)
        {
            if (dict.Count == 0) return string.Empty;

            var buffer = new StringBuilder();
            int count = 0;
            bool end = false;

            foreach (var key in dict.Keys)
            {
                if (count == dict.Count - 1) end = true;

                if (end)
                    buffer.AppendFormat("{0}={1}", key, dict[key]);
                else
                    buffer.AppendFormat("{0}={1}&", key, dict[key]);

                count++;
            }

            return buffer.ToString();
        }
    }
}
