using AutoMapper;
using Codebridge.BLL.Entities;
using Codebridge.WebApi.Model;

namespace Codebridge.WebApi.Mapper;

public class DogsProfile : Profile
{
    public DogsProfile()
    {
        CreateMap<Dog, DogDto>();
        CreateMap<DogDto, Dog>();
    }
}