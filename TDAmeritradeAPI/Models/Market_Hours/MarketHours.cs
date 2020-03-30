using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Models.Market_Hours
{
    public class MarketHours
    {
        //TODO: Need to work on this to deserealize
        public string category { get; set; }
        public string date { get; set; }
        public string exchange { get; set; }
        public bool isOpen { get; set; }
        public string marketType { get; set; }
        public string product { get; set; }
        public string productName { get; set; }
        public object sessionHours { get; set; }
    }
}
