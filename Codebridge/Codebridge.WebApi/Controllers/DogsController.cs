using AutoMapper;
using Codebridge.BLL.Entities;
using Codebridge.BLL.Services;
using Codebridge.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Codebridge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableRateLimiting("fixed")]
    public class DogsController : ControllerBase
    {
        private readonly IDogsService _dogsService;
        private readonly IMapper _mapper;
        private readonly ILogger<DogsController> _logger;

        public DogsController(ILogger<DogsController> logger, IDogsService dogsService, IMapper mapper)
        {
            _dogsService = dogsService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(Name = "dogs")]
        public IEnumerable<DogDto> Get([FromQuery] SortPaginationModel sortPaginationModel)
        {
            try
            {
                return _dogsService.GetAllDogs(sortPaginationModel).Select(t => _mapper.Map<DogDto>(t));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal server error.");
                throw;
            }
        }
    }
}