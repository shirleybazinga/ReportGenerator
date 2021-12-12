using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    internal class BondFutureReportGenerator : ReportGenerator
    {
        const string SKIP_BROKER = "Broker-A"; // TODO: config

        public BondFutureReportGenerator(string broker) : base(broker)
        {
        }

        public override void Generate(IEnumerable<Trade> records, string path)
        {
            //var fileName = Path.GetFileNameWithoutExtension(path);
            //var newPath = path.Replace(fileName, $"{fileName}-{Broker}");

            using (var writer = new StreamWriter(path))
            using (var csv = GetCsvWriter(writer))
            {
                if (string.Compare(Broker, SKIP_BROKER, true) == 0)
                {
                    csv.Context.RegisterClassMap<TradeMap>();
                }
                csv.WriteRecords(records);
            }
        }

        public sealed class TradeMap : ClassMap<Trade>
        {
            public TradeMap()
            {
                AutoMap(CultureInfo.InvariantCulture);
                Map(m => m.Broker.Id).Ignore();
                Map(m => m.Broker.Name).Ignore();
                Map(m => m.Product.Type).Ignore();
            }
        }
    }
}
