using Codebridge.BLL.Entities;
using Codebridge.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codebridge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogsController : ControllerBase
    {
        private readonly IDogsService _dogsService;

        public DogsController(ILogger<DogsController> logger, IDogsService dogsService)
        {
            _dogsService = dogsService;
        }

        [HttpGet(Name = "dogs")]
        public IEnumerable<Dog> Get()
        {
            return _dogsService.GetAllDogs().ToArray();
        }
    }
}