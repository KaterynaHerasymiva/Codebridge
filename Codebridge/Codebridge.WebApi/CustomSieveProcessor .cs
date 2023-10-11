using Codebridge.BLL.Entities;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Codebridge.WebApi;

public class CustomSieveProcessor : SieveProcessor
{
    public CustomSieveProcessor(
        IOptions<SieveOptions> options)
        : base(options)
    {
    }

    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
        mapper.Property<Dog>(p => p.Name)
            .CanSort();
        mapper.Property<Dog>(p => p.Color)
            .CanSort();
        mapper.Property<Dog>(p => p.TailLength)
            .CanSort();
        mapper.Property<Dog>(p => p.Weight)
            .CanSort();

        return mapper;
    }
}