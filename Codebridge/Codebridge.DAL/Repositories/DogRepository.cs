using Codebridge.BLL.Entities;
using Codebridge.BLL.Repositories;

namespace Codebridge.DAL.Repositories;

public class DogRepository : IDogRepository
{
    public Task<IQueryable<Dog>> GetDogsAsync()
    {
        throw new NotImplementedException();
    }
}