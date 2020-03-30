using System.Runtime.CompilerServices;

namespace TDAmeritradeAPI.Fields
{
    public class Options
    {
        public static class Type
        {
            public const string
                Standard = "S",
                Non_Standard = "NS",
                All = "ALL";
        }
        public static class ContractType
        {
            public const string
                Call = "CALL",
                Put = "PUT",
                All = "ALL";
        }
        public static class Range
        {
            public const string
                In_The_Money = "ITM",
                Near_The_Money = "NTM",
                Out_Of_The_Money = "OTM",
                Strikes_Above_Market = "SAK",
                Strikes_Below_Market = "SBK",
                Strikes_Near_Market = "SNK",
                ALL = "ALL";
        }

        public static class Strategy
        {
            public const string
                Single = "SINGLE",
                Analytical = "ANALYTICAL",
                Covered = "COVERED",
                Vertical = "VERTICAL",
                Calendar = "CALENDAR",
                Strangle = "STRANGLE",
                Straddle = "STRADDLE",
                Butterfly = "BUTTERFLY",
                Condor = "CONDOR",
                Diagonal = "DIAGONAL",
                Collar = "COLLAR",
                Roll = "ROLL";
        }

        public static class ExpMonth
        {
            public const string
                JAN = "JAN",
                FEB = "FEB",
                MAR = "MAR",
                APR = "APR",
                MAY = "MAY",
                JUN = "JUN",
                JUL = "JUL",
                AUG = "AUG",
                SEP = "SEP",
                OCT = "OCT",
                NOV = "NOV",
                DEC = "DEC";
        }
    }
    
}