using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Lib.Trading
{
    public class TradingDataService
    {
        public readonly ITradingDataProvider _dataProvider;
        public TradingDataService(ITradingDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<List<TradingDataResponse>> GetTradingDataFor(string symbol)
        {
            return await _dataProvider.GetTradingData(symbol);
        }
    }
}
