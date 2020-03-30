using System;
using System.Collections.Generic;
using System.Text;

namespace TDAmeritradeAPI.Props
{
    public class TransactionsSettings
    {
        public long accountId { get; set; }
        public string type { get; set; }
        public string symbol { get; set; }
        /// <summary>
        /// Valid format: yyyy-MM-dd
        /// </summary>
        public string startDate { get; set; }
        /// <summary>
        /// Valid format: yyyy-MM-dd
        /// </summary>
        public string endDate { get; set; }
    }
}
