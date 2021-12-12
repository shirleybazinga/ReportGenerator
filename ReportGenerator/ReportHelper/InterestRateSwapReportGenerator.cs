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
    internal class InterestRateSwapReportGenerator : ReportGenerator
    {
        public InterestRateSwapReportGenerator(string broker) : base(broker)
        {
        }

        public override CsvWriter GetCsvWriter(StreamWriter writer)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "\t",
            };
            return new CsvWriter(writer, config);
        }
    }
}
