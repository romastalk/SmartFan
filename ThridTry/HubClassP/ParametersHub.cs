using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ThridTry.Data;

namespace ThridTry.HubClassP
{
    public class ParametersHub : Hub
    {

        private string mes; 
        private readonly RandomCount _random;
        private readonly ILogger<ParametersHub> _logger;

        public ParametersHub(ILogger<ParametersHub> logger, RandomCount random)
        {
            this._logger = logger;
            this._random = random;       
        }

        Fan fan = new Fan();

        public async Task Send(string message) // double count
        {
            while (true)
            {
                //var data = GetData();
                // await Clients.All.SendAsync("Message", data);
                // this._logger.LogInformation(message);
                // передача в rasbery
                // SendVent(count)
                //await Task.Delay(500);
                fan.SendVent(50);
            }


        }

        public static List<Parameters> GetData()
         {
             var r = new Random();

            //перевод значений в СИ

            return new List<Parameters>()
            {
                new Parameters {Message = "Hello", V = Convert.ToString(r.Next(1,100)), Pa = Convert.ToString(r.Next(1,300)) },           
            };
        }

    }
}
