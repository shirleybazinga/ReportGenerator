using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    internal class DataAccess
    {
        private IData myData;

        public DataAccess(IData data) 
        {
            myData = data; 
        }

        public IEnumerable<Trade> GetTrades(string broker, string productType, DateTime date)
        {
            var result = myData.Trades.Where(it => string.Compare(it.Broker.Name, broker, true) == 0
                && string.Compare(it.Product.Type.Replace(" ", ""), productType.Replace(" ", ""), true) == 0
                && it.Date.Date == date.Date);
            return result;
        }
    }
}
