namespace TablePerComponent.App.Models;

public class Owner
{
    public required NonEmptyString Name { get; init; }
    public required Address Address { get; init; }
    public required NonEmptyString PhoneNumber { get; init; }
}