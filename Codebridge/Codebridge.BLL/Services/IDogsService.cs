using Codebridge.BLL.Entities;

namespace Codebridge.BLL.Services;

public interface IDogsService
{
    IEnumerable<Dog> GetAllDogs(SortPaginationModel sortPaginationModel);
    Task<Dog> AddDog(Dog dog);
}