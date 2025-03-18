namespace TablePerComponent.App.Models;

public class Owner
{
    public required NonEmptyString Name { get; init; }
    public required Address Address { get; init; }
    public required NonEmptyString PhoneNumber { get; init; }
    public required IdType IdType { get; init; }
    public NonEmptyString? IdNumber { get; init; }
    public NonEmptyString? PassportNumber { get; init; }
}