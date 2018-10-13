using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Lib.Trading
{
    public interface ITradingDataProvider
    {
        Task<List<TradingDataResponse>> GetTradingData(string symbol);
    }
}
