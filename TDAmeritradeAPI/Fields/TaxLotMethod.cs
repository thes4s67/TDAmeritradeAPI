namespace TDAmeritradeAPI.Fields
{
    /// <summary>
    /// Used for updating preferences for a specific account
    /// </summary>
    public static class TaxLotMethod
    {
        public const string
            FIFO = "FIFO",
            LIFO = "LIFO",
            High_Cost = "HIGH_COST",
            Low_Cost = "LOW_COST",
            Mimium_Tax = "MINIMUM_TAX",
            Average_Cost = "AVERAGE_COST",
            None = "NONE";
    }
}