using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Lib.Trading;

namespace WorkShop.Tests
{
    [TestFixture]
    public class TradingDataService_Should
    {
        private readonly TradingDataService _dataService;
        public TradingDataService_Should()
        {
            var mock = new Mock<ITradingDataProvider>();
            mock.Setup(client => client.GetTradingData(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<TradingDataResponse>()
                { new TradingDataResponse
                        {
                            date = "2018-09-12",
                            open = 111.43,
                            high = 111.85
                        }
                }

            ));
            _dataService = new TradingDataService(mock.Object);
        }

        [Test]
        public async Task ReturnStockDate()
        {
            var tradingData = await _dataService.GetTradingDataFor("msft");

            Assert.IsTrue(tradingData.Exists(t => t.date == "2018-09-12"));
        }

        [Test]
        public async Task ReturnOpenValue()
        {
            var tradingData = await _dataService.GetTradingDataFor("msft");

            Assert.IsTrue(tradingData.Exists(t => t.open == 111.43));
        }

        [Test]
        public async Task ReturnHighValue()
        {
            var tradingData = await _dataService.GetTradingDataFor("msft");

            Assert.IsTrue(tradingData.Exists(t => t.high == 111.85));
        }
    }
}
