using Codebridge.WebApi.Model;
using Sieve.Models;
using System.ComponentModel.DataAnnotations;

namespace Codebridge.BLL.Entities;

public record SortPaginationModel
{
    public string? Attribute { get; set; }

    public SortingOrder Order { get; set; }

    [Range(1, int.MaxValue)]
    public int? PageNumber { get; set; }

    [Range(1, int.MaxValue)]
    public int? PageSize { get; set; }

    public SieveModel ToSieveModel()
    {
        var sortProperty = typeof(Dog).GetProperties().Select(t => t.Name).FirstOrDefault(t => string.Equals(t, Attribute, StringComparison.OrdinalIgnoreCase));

        if (sortProperty != null)
        {
            if (Order == SortingOrder.Desc)
            {
                sortProperty = "-" + sortProperty;
            }
        }

        if (PageNumber < 1)
        {
            throw new ArgumentException(nameof(PageNumber));
        }

        if (PageSize < 1)
        {
            throw new ArgumentException(nameof(PageSize));
        }

        return new SieveModel
        {
            Page = PageNumber,
            PageSize = PageSize,
            Sorts = sortProperty
        };
    }
}