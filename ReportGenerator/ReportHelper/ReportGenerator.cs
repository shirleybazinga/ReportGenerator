using CsvHelper;
using System.Globalization;

namespace ReportGenerator
{
    public class ReportGenerator : IReportGenerator
    {
        public ReportGenerator(string broker)
        {
            Broker = broker;
        }

        public string Broker { get; }

        public virtual void Generate(IEnumerable<Trade> records, string path)
        {
            using (var writer = new StreamWriter(path))
            using (var csv = GetCsvWriter(writer))
            {
                csv.WriteRecords(records);
            }
        }

        public virtual CsvWriter GetCsvWriter(StreamWriter writer)
        {
            return new CsvWriter(writer, CultureInfo.InvariantCulture);
        }
    }
}
