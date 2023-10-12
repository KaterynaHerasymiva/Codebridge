using System.ComponentModel.DataAnnotations;

namespace Codebridge.BLL.Entities;

public record Dog
{
    public Dog(int id, string name, string color, double tailLength, double weight)
    {
        this.Id = id;
        this.Name = name;
        this.Color = color;
        this.TailLength = tailLength;
        this.Weight = weight;
    }

    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; init; }

    [Required]
    public string Name { get; init; }

    [Required]
    public string Color { get; init; }

    [Required]
    [Range(double.Epsilon, 10000)]
    public double TailLength { get; init; }

    [Required]
    [Range(double.Epsilon, 10000)]
    public double Weight { get; init; }
}