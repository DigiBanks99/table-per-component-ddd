namespace TablePerComponent.App.Models;

public class Address
{
    public required NonEmptyString Line1 { get; init; }
    public NonEmptyString? Line2 { get; init; }
    public required NonEmptyString City { get; init; }
    public required NonEmptyString Province { get; init; }
    public required NonEmptyString PostalCode { get; init; }
}