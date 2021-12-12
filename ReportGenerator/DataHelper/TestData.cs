using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    public class TestData : IData
    {
        List<Trade> trades = new();

        public TestData()
        {
            var testDataPath = Path.Combine(Directory.GetCurrentDirectory(), "DataStub.csv");
            using (var reader = new StreamReader(testDataPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                trades = csv.GetRecords<Trade>().ToList();
            }
        }

        public List<Trade> Trades { get { return trades; } }
    }
}
