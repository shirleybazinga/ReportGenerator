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
    internal class FxForwardReportGenerator : ReportGenerator
    {
        public FxForwardReportGenerator(string broker) : base(broker)
        {
        }
    }
}
