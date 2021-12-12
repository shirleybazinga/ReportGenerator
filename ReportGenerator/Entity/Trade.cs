using CsvHelper.Configuration.Attributes;

namespace ReportGenerator
{
    public enum BuySell
    {
        B,
        S,
    }

    public class Trade
    {
        [Name("tradeRef")]
        public string Ref { get; set; }

        public Product Product { get; set; }

        public Broker Broker { get; set; }

        [Name("tradeDate")]
        [Format("yyyyMMdd")]
        public DateTime Date { get; set; }

        [Name("qty")]
        public long Quantity { get; set; }

        [Name("buySell")]
        public BuySell BuySell { get; set; }

        [Name("price")]
        public decimal Price { get; set; }
    }
}
