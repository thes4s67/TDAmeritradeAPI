using System;
using System.Collections.Generic;
using System.Text;
using TDAmeritradeAPI.Fields;

namespace TDAmeritradeAPI.Props
{
    public class PriceHistorySettings
    {
        /// <summary>
        /// Enter a valid symbol
        /// </summary>
        public string symbol { get; set; }
        /// <summary>
        /// Accepted values: PeriodType.Day, PeriodType.Month, PeriodType.Year, PeriodType.YTD
        /// </summary>
        public string periodType { get; set; }
        /// <summary>
        /// Valid periods based on PeriodType (* default):
        /// <para>- Day: 1, 2, 3, 4, 5, 10*</para>
        /// <para>- Month: 1*, 2, 3, 6</para>
        /// <para>- Year: 1*, 2, 3, 5, 10, 15, 20</para>
        /// <para>- YTD: 1*</para>
        /// </summary>
        public int period { get; set; }
        /// <summary>
        /// <para>Accepted values: FrequencyType.Minute, FrequencyType.Daily, FrequencyType.Weekly, FrequencyType.Monthly</para>
        /// <para>Valid FrequencyType based on PeriodType (* default):</para>
        /// <para>- Day: minute*</para>
        /// <para>- Month: daily, weekly*</para>
        /// <para>- Year: daily, weekly, monthly*</para>
        /// <para>- YTD: daily, weekly*</para>
        /// </summary>
        public string frequencyType { get; set; }
        /// <summary>
        /// Valid frequencies based on FrequencyType (* default):
        /// <para>- Minute: 1*, 5, 10, 15, 30</para>
        /// <para>- Daily: 1*</para>
        /// <para>- Weekly: 1*</para>
        /// <para>- Monthly: 1*</para>
        /// </summary>
        public int frequency { get; set; }
        /// <summary>
        /// End date in milliseconds since epoch. If period is provided, leave blank
        /// </summary>
        public long endDate { get; set; }
        /// <summary>
        /// Start date in milliseconds since epoch. If period is provided, leave blank
        /// </summary>
        public long startDate { get; set; }
        /// <summary>
        /// Default is set to true
        /// </summary>
        public bool needExtendedHoursData { get; set; }
    }
}
