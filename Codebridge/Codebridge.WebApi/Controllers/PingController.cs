using Codebridge.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codebridge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly IPingService _pingService;

        public PingController(IPingService pingService)
        {
            _pingService = pingService;
        }

        [HttpGet(Name = "ping")]
        public string Get() => _pingService.GetVersion();
    }
}