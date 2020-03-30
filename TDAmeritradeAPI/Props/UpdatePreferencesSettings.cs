using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Props
{
    /// <summary>
    /// Used for updating preferences for a specific account
    /// </summary>
    public class UpdatePreferencesSettings
    {
        public bool expressTrading { get; set; }
        /// <summary>
        /// Please note that the directOptionsRouting and directEquityRouting values cannot be modified via this operation.
        /// </summary>
        //public bool directOptionsRouting { get; } = false;
        /// <summary>
        /// Please note that the directOptionsRouting and directEquityRouting values cannot be modified via this operation.
        /// </summary>
        //public bool directEquityRouting { get; } = false;
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
