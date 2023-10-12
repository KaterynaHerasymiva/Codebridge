using Codebridge.BLL.Entities;
using Codebridge.WebApi.Model;

namespace Codebridge.BLL.Services;

public interface IDogsService
{
    IEnumerable<Dog> GetAllDogs(SortPaginationModel sortPaginationModel);
    Task<Dog> AddDog(Dog dog);
}