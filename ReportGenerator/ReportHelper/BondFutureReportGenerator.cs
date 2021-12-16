using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    internal class BondFutureReportGenerator : ReportGenerator
    {
        // TODO: config
        const string BROKER_A = "Broker-A";
        const string BROKER_C = "Broker-C";

        static readonly Dictionary<string, Action<ClassMap<Trade>>> BrokerColMap = new Dictionary<string, Action<ClassMap<Trade>>>
        {
            { BROKER_A, (ClassMap<Trade> classMap) =>
                {
                    classMap.AutoMap(CultureInfo.InvariantCulture);
                    classMap.Map(m => m.Broker.Id).Ignore();
                    classMap.Map(m => m.Broker.Name).Ignore();
                    classMap.Map(m => m.Product.Type).Ignore();
                }
            },
            { BROKER_C, (ClassMap<Trade> classMap) =>
                {
                    classMap.Map(m => m.Ref).Name("tradeRef");
                    classMap.Map(m => m.Product.Id).Name("productId");
                    classMap.Map(m => m.Product.Name).Name("productName");
                }
            },
        };

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
                if (BrokerColMap.ContainsKey(Broker))
                {
                    //csv.Context.RegisterClassMap<TradeMap>();
                    csv.Context.RegisterClassMap(new TradeMap(BrokerColMap[Broker]));
                }
                csv.WriteRecords(records);
            }
        }

        public sealed class TradeMap : ClassMap<Trade>
        {
            public TradeMap(Action<ClassMap<Trade>> action)
            {
                action?.Invoke(this);
            }
        }
    }
}
