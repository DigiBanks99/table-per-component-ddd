using System.Text.Json;
using System.Text.Json.Serialization;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Serialization;

internal sealed class NonEmptyStringJsonConverter : JsonConverter<NonEmptyString>
{
    public override NonEmptyString? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert != typeof(NonEmptyString))
        {
            return null;
        }

        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException($"Expected string but received a {reader.TokenType.ToString()}");
        }

        string? underlyingString = reader.GetString();
        return underlyingString is null ? null : new NonEmptyString(underlyingString);
    }

    public override void Write(Utf8JsonWriter writer, NonEmptyString value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}