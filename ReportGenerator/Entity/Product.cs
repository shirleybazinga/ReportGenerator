using CsvHelper.Configuration.Attributes;

namespace ReportGenerator
{
    public class Product
    {
        [Name("productId")]
        public long Id { get; set; }

        [Name("productName")]
        public string Name { get; set; }

        [Name("productType")]
        public string Type { get; set; }
    }
}
