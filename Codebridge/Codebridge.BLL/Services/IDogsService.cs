using Codebridge.BLL.Entities;

namespace Codebridge.BLL.Services;

public interface IDogsService
{
    IQueryable<Dog> GetAllDogs();
}