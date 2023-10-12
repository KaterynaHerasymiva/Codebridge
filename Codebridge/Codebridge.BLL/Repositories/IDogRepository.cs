using Codebridge.BLL.Entities;

namespace Codebridge.BLL.Repositories;

public interface IDogRepository
{
    IQueryable<Dog> GetDogsAsync();
    Task<Dog> AddDogAsync(Dog dog);
}