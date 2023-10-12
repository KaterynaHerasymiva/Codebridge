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

    public async Task<Dog> AddDogAsync(Dog dog)
    {
        var createdDog = _dogsContext.Dogs?.Add(dog);
        var result = await _dogsContext.SaveChangesAsync();

        if (result == 1 && createdDog?.Entity != null)
        {
            return createdDog.Entity;
        }

        throw new InvalidOperationException("Failed to add data to DB!");
    }
}