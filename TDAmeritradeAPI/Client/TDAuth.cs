using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Newtonsoft.Json;
using RestSharp;
using TDAmeritradeAPI.Models.Auth;

namespace TDAmeritradeAPI.Client
{
    public static class TDAuth
    {
        private const string AuthUrl = "https://api.tdameritrade.com/v1/oauth2/token";
        /// <summary>
        /// Get code to get access token. This is for console app.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="redirectUri"></param>
        public static void GetAuthCode(string clientId, string redirectUri)
        {
            Process.Start(ChromeAppFileName, $"https://auth.tdameritrade.com/oauth?client_id={clientId}@AMER.OAUTHAP&response_type=code&redirect_uri={redirectUri}");
        }
        public static AuthToken GetAccessToken(string clientId, string code, string redirectUri)
        {
            var client = new RestClient(AuthUrl);
            var request = new RestRequest(Method.POST);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("client_id", clientId);
            request.AddParameter("access_type", "offline");
            request.AddParameter("code", code);
            request.AddParameter("redirect_uri", redirectUri);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<AuthToken>(response.Content);
        }
        /// <summary>
        /// Gets location of Chrome.exe
        /// </summary>
        private const string ChromeAppKey = @"\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";
        private static string ChromeAppFileName =>
            (string)(Registry.GetValue("HKEY_LOCAL_MACHINE" + ChromeAppKey, "", null) ??
                     Registry.GetValue("HKEY_CURRENT_USER" + ChromeAppKey, "", null));
    }
}
