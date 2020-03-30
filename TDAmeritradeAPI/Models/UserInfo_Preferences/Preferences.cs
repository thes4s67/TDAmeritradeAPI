using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Models.UserInfo_Preferences
{
    public class Preferences
    {
        public bool expressTrading { get; set; }
        public bool directOptionsRouting { get; set; }
        public bool directEquityRouting { get; set; }
        public string defaultEquityOrderLegInstruction { get; set; }
        public string defaultEquityOrderType { get; set; }
        public string defaultEquityOrderPriceLinkType { get; set; }
        public string defaultEquityOrderDuration { get; set; }
        public string defaultEquityOrderMarketSession { get; set; }
        public int defaultEquityQuantity { get; set; }
        public string mutualFundTaxLotMethod { get; set; }
        public string optionTaxLotMethod { get; set; }
        public string equityTaxLotMethod { get; set; }
        public string defaultAdvancedToolLaunch { get; set; }
        public string authTokenTimeout { get; set; }
    }
}