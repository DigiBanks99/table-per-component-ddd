namespace TablePerComponent.App.Models;

public class NonEmptyString(string value)
{
    private readonly string _value = Validate(value);

    public static implicit operator string(NonEmptyString nonEmptyString) => nonEmptyString._value;
    public static implicit operator NonEmptyString(string value) => new(value);

    public override string ToString()
    {
        return _value;
    }

    private static string Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }

        return value;
    }
}