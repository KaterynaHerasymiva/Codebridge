using Codebridge.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Codebridge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;

        public PingController(ILogger<PingController> logger, DogsContext dogsContext) // Remove
        {
            _logger = logger;
        }

        [HttpGet(Name = "Ping")]
        public string Get()
        {
            return "Dogshouseservice.Version1.0.1"; // Add service
        }
    }
}