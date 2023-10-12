using Codebridge.BLL.Entities;
using Codebridge.BLL.Repositories;

namespace Codebridge.Tests;

public class DogsTestRepository : IDogRepository
{
    private readonly List<Dog> Dogs = new()
    {
        new Dog(1, "Neo", "red&amber", 22, 32),
        new Dog(2, "Jessy", "black&white", 7, 14),
        new Dog(3, "Vetka", "white", 30, 10),
        new Dog(4, "Carat", "black", 15, 35)
    };

    public IQueryable<Dog> GetDogs()
    {
        return Dogs.AsQueryable();
    }
}