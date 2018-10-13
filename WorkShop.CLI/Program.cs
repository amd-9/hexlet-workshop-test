using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Threading.Tasks;
using WorkShop.Lib;
using WorkShop.Lib.Trading;

namespace WorkShop.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineApplication commandLineApplication = new CommandLineApplication(throwOnUnexpectedArg: false);

            CommandArgument symbol = null;

            commandLineApplication.Command("symbol",
                (target) => symbol = target.Argument(
                  "symbol",
                  "Enter stock symbol.",
                  multipleValues: false));

            commandLineApplication.HelpOption("-? | -h | --help");

            commandLineApplication.OnExecute(() =>
            {
                Console.WriteLine("value is: {0}",symbol.Value);

                if (!string.IsNullOrEmpty(symbol.Value))
                {                    
                    var tradingProvider = new IEXTradingProvider();
                    var service = new TradingDataService(tradingProvider);
                    var result = Task.Run(() => service.GetTradingDataFor(symbol.Value)).Result;

                    Console.WriteLine(result[0].date);
                }

                return 0;
            });

            commandLineApplication.Execute(args);
        }
    }
}
