using System.Text.Json.Serialization;

namespace Codebridge.WebApi.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortingOrder
{
    Asc = 0,
    Desc
}