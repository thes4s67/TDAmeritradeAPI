namespace TDAmeritradeAPI.Models.UserInfo_Preferences
{
    public class SubscriptionKey
    {
        public Key[] keys { get; set; }

        public class Key
        {
            public string key { get; set; }
        }
    }
}