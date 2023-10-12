using System.ComponentModel.DataAnnotations;

namespace Codebridge.WebApi.Model;

public record DogDto
{
    public DogDto(string name, string color, double tailLength, double weight)
    {
        this.Name = name;
        this.Color = color;
        this.TailLength = tailLength;
        this.Weight = weight;
    }

    [Required]
    public string Name { get; init; }

    [Required]
    public string Color { get; init; }

    [Range(double.Epsilon, 10000)]
    public double TailLength { get; init; }

    [Range(double.Epsilon, 10000)]
    public double Weight { get; init; }
}