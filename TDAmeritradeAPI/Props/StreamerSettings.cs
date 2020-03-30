using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace TDAmeritradeAPI.Props
{
    public class StreamerSettings
    {
        public class Requests
        {
            public Request[] requests { get; set; }
        }
        public class Request
        {
            public string service { get; set; }
            public string command { get; set; }
            public int requestid { get; set; }
            public string account { get; set; }
            public string source { get; set; }
            public Parameters parameters { get; set; }
        }

        public class Parameters
        {
            public string credential { get; set; }
            public string token { get; set; }
            public string version { get; set; } = "1.0";
            public string keys { get; set; }
            public string fields { get; set; }
            public int qoslevel { get; set; }
        }
        public class Credentials
        {
            public string userId { get; set; }
            public string token { get; set; }
            public string company { get; set; }
            public string segment { get; set; }
            public string cddomain { get; set; }
            public string usergroup { get; set; }
            public string accesslevel { get; set; }
            public string authorized { get; set; }
            public double timestamp { get; set; }
            public string appid { get; set; }
            public string acl { get; set; }
        }
    }
}
