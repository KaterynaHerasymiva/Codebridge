using Codebridge.BLL.Entities;
using Sieve.Models;
using System.ComponentModel.DataAnnotations;

namespace Codebridge.WebApi.Model;

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
        // TODO move to service
        var sortProperty = typeof(Dog).GetProperties().Select(t => t.Name).FirstOrDefault(t => string.Equals(t, Attribute, StringComparison.OrdinalIgnoreCase));

        if (sortProperty != null)
        {
            if (Order == SortingOrder.Desc)
            {
                sortProperty = "-" + sortProperty;
            }
        }

        return new SieveModel
        {
            Page = PageNumber,
            PageSize = PageSize,
            Sorts = sortProperty
        };
    }
}