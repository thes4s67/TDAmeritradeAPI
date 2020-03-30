using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Models.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthToken
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public int refresh_token_expires_in { get; set; }
    
    }
}
