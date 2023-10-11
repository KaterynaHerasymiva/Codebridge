using AutoMapper;
using Codebridge.BLL.Services;
using Codebridge.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Sieve.Services;

namespace Codebridge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogsController : ControllerBase
    {
        private readonly IDogsService _dogsService;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly IMapper _mapper;
        private readonly ILogger<DogsController> _logger;

        public DogsController(ILogger<DogsController> logger, IDogsService dogsService, ISieveProcessor sieveProcessor, IMapper mapper)
        {
            _dogsService = dogsService;
            _sieveProcessor = sieveProcessor;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(Name = "dogs")]
        public IEnumerable<DogDto> Get([FromQuery] SortPaginationModel sortPaginationModel)
        {
            try
            {
                var dogs = _dogsService.GetAllDogs();
                return _sieveProcessor.Apply(sortPaginationModel.ToSieveModel(), dogs).Select(t => _mapper.Map<DogDto>(t));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal server error.");
                throw;
            }
        }
    }
}