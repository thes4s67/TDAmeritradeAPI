using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace TDAmeritradeAPI.Fields
{
    /// <summary>
    /// Used to get Top 10 (up or down) movers by value or percent for a particular market
    /// </summary>
    public static class Change
    {
        public const string
            Percent = "percent",
            Value = "value";
    }
}