using Codebridge.BLL.Entities;

namespace Codebridge.BLL.Repositories;

public interface IDogRepository
{
    Task<IQueryable<Dog>> GetDogsAsync();
}