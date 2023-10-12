namespace Codebridge.BLL.Entities;

public record Dog : Entity
{
    public Dog(int id, string name, string color, double tailLength, double weight)
    {
        this.Id = id;
        this.Name = name;
        this.Color = color;
        this.TailLength = tailLength;
        this.Weight = weight;
    }

    public Dog()
    {

    }

    public string Name { get; init; }

    public string Color { get; init; }

    public double TailLength { get; init; }

    public double Weight { get; init; }
}