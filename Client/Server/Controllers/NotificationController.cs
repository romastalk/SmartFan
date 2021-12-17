using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<Hubs.MessageHub> _hubContext;

        public NotificationController(IHubContext<Hubs.MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string title)
        {
            await _hubContext.Clients.All.SendAsync("SendMessage", $"{DateTime.Now}:{title}");
            return Ok("Ok!");
        }
    }
}
