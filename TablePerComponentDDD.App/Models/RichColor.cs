namespace TablePerComponent.App.Models;

public record RichColor(string Name, NonEmptyString Description)
{
    public static readonly RichColor Blue = new("Blue", "The color of the sky and the sea");
    public static readonly RichColor Red = new("Red", "The color of the sky and the sea");
    public static readonly RichColor Grey = new("Grey", "The color of stones and rocks");
    public static readonly RichColor Brown = new("Brown", "The other color of stones and rocks");
    public static readonly RichColor White = new("White", "The color of snow and milk");

    public static RichColor Parse(string name)
    {
        return name switch
        {
            "Blue" => Blue,
            "Red" => Red,
            "Grey" => Grey,
            "Brown" => Brown,
            "White" => White,
            _ => throw new NotSupportedException($"{name} is not a supported color")
        };
    }
}