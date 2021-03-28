using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ActionBlazor.ChatConnectionHub.WebApi.Hubs;

namespace ActionBlazor.ChatConnectionHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {

        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationsController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] string title)
        {
            await _hubContext.Clients.All.SendAsync("notification", $"{DateTime.Now}: {title}");
            return Ok("Notification has been sent successfully!");
        }

    }
}