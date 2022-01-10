using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ThridTry.HubClassP;


namespace ThridTry.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class Divice : ControllerBase
    {
        public string message = " ";
        public readonly IHubContext<ParametersHub> _hub;
          private readonly TimerManager _timer;
        

        public Divice(IHubContext<ParametersHub> hub, TimerManager time)
        {
            _hub = hub;
            _timer = time;
        }

        [HttpGet]
        public IActionResult Get()
        {           
           if(!_timer.IsTimerStarted)
           {
               _timer.PrepareTimer(()=> _hub.Clients.All.SendAsync("Transport", message));
           } 

           return Ok(new {message = "stop"});             
        }

    }
}
