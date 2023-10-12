using Codebridge.BLL.Entities;
using Codebridge.BLL.Repositories;

namespace Codebridge.DAL.Repositories;

public class DogRepository : IDogRepository
{
    private readonly DogsContext _dogsContext;

    public DogRepository(DogsContext dogsContext)
    {
        _dogsContext = dogsContext;
    }

    public IQueryable<Dog> GetDogs() => _dogsContext.Dogs!.AsQueryable();
}