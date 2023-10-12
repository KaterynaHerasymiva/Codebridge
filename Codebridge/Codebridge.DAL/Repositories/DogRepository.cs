using Codebridge.BLL.Entities;
using Codebridge.BLL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Codebridge.DAL.Repositories;

public class DogRepository : IDogRepository
{
    private readonly DogsContext _dogsContext;

    public DogRepository(DogsContext dogsContext)
    {
        _dogsContext = dogsContext;
    }

    public IQueryable<Dog> GetDogsAsync() => _dogsContext.Dogs!.AsQueryable();
    public async Task<Dog> AddDogAsync(Dog dog)
    {
        _dogsContext.Dogs.Add(dog);
        await _dogsContext.SaveChangesAsync();

        return dog;
    }
}