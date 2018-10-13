using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Lib.Trading
{
    public class IEXTradingProvider : ITradingDataProvider
    {
        private readonly string _servicePath;

        public IEXTradingProvider()
        {
            _servicePath = "https://api.iextrading.com/1.0/stock/{0}/chart/1d";
        }
        public async Task<List<TradingDataResponse>> GetTradingData(string symbol)
        {
            var baseAddress = string.Format(_servicePath, symbol);

            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(baseAddress);

                HttpResponseMessage response = await client.GetAsync(baseAddress);

                if(response.IsSuccessStatusCode)
                {
                    var tradingDataList = response.Content.ReadAsAsync<List<TradingDataResponse>>();

                    return tradingDataList.Result;
                } 
                else
                {
                    return null;
                }

            }
        }
    }
}
