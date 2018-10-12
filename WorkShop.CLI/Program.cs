using System;
using WorkShop.Lib;

namespace WorkShop.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            StringGreeter greeter = new StringGreeter();

            Console.WriteLine(greeter.SayHello());

            //Delay
            Console.ReadKey();
        }
    }
}
