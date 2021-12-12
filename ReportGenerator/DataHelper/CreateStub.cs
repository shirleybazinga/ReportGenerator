using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    public class CreateStub : IData
    {
        readonly List<Broker> brokers = new();
        readonly List<Product> products = new();
        readonly List<Trade> trades = new();

        Dictionary<int, Tuple<string, string>> productTypeMapping = new Dictionary<int, Tuple<string, string>>()
        {
            { 0, Tuple.Create("Fx Forward", "FWD") },
            { 1, Tuple.Create("Bond Future", "BF") },
            { 2, Tuple.Create("Interest Rate Swap", "IRS") },
            { 3, Tuple.Create("Others", "OTH") },
        };

        public CreateStub(DateTime date)
        {
            for (int i = 0; i < 10; i++)
            {
                brokers.Add((Broker)GetDummyObject(typeof(Broker), null, i));
            }

            for (int i = 0; i < 20; i++)
            {
                products.Add((Product)GetDummyObject(typeof(Product)));
            }

            for (int i = 0; i < 500; i++)
            {
                trades.Add((Trade)GetDummyObject(typeof(Trade), date));
            }
        }

        public List <Trade> Trades { get { return trades; } }

        public object GetDummyObject(Type type, DateTime? date = null, int brokerId = 0, int prdTypeId = -1)
        {
            var obj = type.GetConstructor(new Type[0]).Invoke(null);

            foreach (var prop in type.GetProperties())
            {
                object value = null;

                if (prop.PropertyType == typeof(long))
                {
                    if (type == typeof(Broker))
                    {
                        value = brokerId;
                    }
                    else
                    {
                        value = new Random().NextInt64(1000000000);
                    }
                }
                else if (prop.PropertyType == typeof(decimal))
                {
                    value = (decimal)new Random().NextDouble();
                }
                else if (prop.PropertyType == typeof(string))
                {
                    if (type == typeof(Trade) && prop.Name == "Ref" || type == typeof(Product) && prop.Name == "Type")
                    {
                        prdTypeId = prdTypeId < 0 ? new Random().Next(4) : prdTypeId;
                        var prdType = productTypeMapping[prdTypeId];
                        value = type == typeof(Product) && prop.Name == "Type" ? prdType.Item1 : $"T-{prdType.Item2}-{new Random().Next(1000)}";
                    }
                    else if (type == typeof(Broker) && prop.Name == "Name")
                    {
                        value = $"{type.Name}-{(char)(brokerId + 65)}";
                    }
                    else
                    {
                        value = $"{type.Name}-{prop.Name}-{new Random().Next(1000)}";
                    }
                }
                else if (prop.PropertyType == typeof(BuySell))
                {
                    value = new Random().Next(100) > 50 ? BuySell.B : BuySell.S;
                }
                else if (prop.PropertyType == typeof(DateTime))
                {
                    var today = DateTime.Today;
                    DateTime start = date?.AddDays(-3) ?? today.AddDays(-6);
                    DateTime randomDate = start.AddDays(new Random().Next(6));
                    value = randomDate > today ? today : randomDate;
                }
                else if (prop.PropertyType == typeof(Product))
                {
                    value = GetDummyObject(typeof(Product), null, 0, prdTypeId);

                    if (!products.Any(it => it.Id == ((Product)value).Id))
                    {
                        products.Add((Product)value);
                    }
                }
                else if (prop.PropertyType == typeof(Broker))
                {
                    value = brokers.FirstOrDefault(it => it.Id == new Random().Next(10)) ?? new Broker { Id = 3, Name = "Broker-D"};
                }

                prop.SetValue(obj, value);
            }

            return obj;
        }
    }
}
