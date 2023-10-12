using Codebridge.BLL.Entities;
using Codebridge.BLL.Repositories;
using Sieve.Services;

namespace Codebridge.BLL.Services;

public class DogsService : IDogsService
{
    private readonly IDogRepository _dogRepository;
    private readonly ISieveProcessor _sieveProcessor;

    public DogsService(IDogRepository dogRepository, ISieveProcessor sieveProcessor)
    {
        _dogRepository = dogRepository;
        _sieveProcessor = sieveProcessor;
    }

    public IEnumerable<Dog> GetAllDogs(SortPaginationModel sortPaginationModel)
    {
        var dogs = _dogRepository.GetDogs();
        return _sieveProcessor.Apply(sortPaginationModel.ToSieveModel(), dogs).ToArray();
    }
}