using Codebridge.BLL.Entities;
using Codebridge.BLL.Repositories;

namespace Codebridge.BLL.Services;

public class DogsService : IDogsService
{
    private readonly IDogRepository _dogRepository;

    public DogsService(IDogRepository dogRepository)
    {
        _dogRepository = dogRepository;
    }

    public IQueryable<Dog> GetAllDogs()
    {
        return _dogRepository.GetDogsAsync();
    }
}