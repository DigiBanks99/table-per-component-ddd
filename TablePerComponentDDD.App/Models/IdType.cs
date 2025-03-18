namespace TablePerComponent.App.Models;

public record IdType(string Name, NonEmptyString Description)
{
    public static readonly IdType IdentityDocument = new("ID", "An ID document");
    public static readonly IdType Passport = new("Passport", "A passport");

    public static IdType Parse(string name)
    {
        return name switch
        {
            "ID" => IdentityDocument,
            "Passport" => Passport,
            _ => throw new NotSupportedException($"{name} is not a supported ID type")
        };
    }
}