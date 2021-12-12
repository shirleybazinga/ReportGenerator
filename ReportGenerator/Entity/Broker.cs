using CsvHelper.Configuration.Attributes;

namespace ReportGenerator
{
    public class Broker
    {
        [Name("brokerId")]
        public long Id { get; set; }

        [Name("brokerName")]
        public string Name { get; set; }
    }
}
