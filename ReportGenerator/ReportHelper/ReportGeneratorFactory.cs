using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    public class ReportGeneratorFactory
    {
        public IReportGenerator GetReportGenerator(string broker, string productType)
        {
            // TODO: other types of generator
            switch (productType.Replace(" ", "").ToLower())
            {
                case "fxforward":
                    return new FxForwardReportGenerator(broker);
                case "bondfuture":
                    return new BondFutureReportGenerator(broker);
                case "interestrateswap":
                    return new InterestRateSwapReportGenerator(broker);
                default:
                    return new ReportGenerator(broker);
            }
        }
    }
}
