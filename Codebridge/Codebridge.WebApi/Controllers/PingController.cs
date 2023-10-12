using Codebridge.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Codebridge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableRateLimiting("fixed")]
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