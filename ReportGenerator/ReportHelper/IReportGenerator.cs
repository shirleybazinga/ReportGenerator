using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    public interface IReportGenerator
    {
        public void Generate(IEnumerable<Trade> records, string path);
    }
}
