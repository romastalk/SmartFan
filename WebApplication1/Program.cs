using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TroykaCap.Expander.Extensions;
using TroykaCap.Expander;
using Unosquare.WiringPi;
using Unosquare.RaspberryIO;



namespace WebApplication1
{
    public class Program
    {
        private static readonly GpioExpander Expander;
        
        static Program()
        {
            Pi.Init<BootstrapWiringPi>();

            Expander = Pi.I2C.GetGpioExpander();
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Start.");

            Console.WriteLine("Port: {0}", Expander.DigitalReadPort());

            Expander.DigitalPortHighLevel();

            Task.Delay(60000).Wait();

            Expander.DigitalPortLowLevel();

            Console.WriteLine("Port: {0}", Expander.DigitalReadPort());

            Console.WriteLine("Stop.");
        }

        private static bool Exit()
        {
            return !(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape);
        }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}