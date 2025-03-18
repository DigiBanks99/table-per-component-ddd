using System.Text.Json;
using System.Text.Json.Serialization;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Serialization;

internal sealed class RichColorJsonConverter : JsonConverter<RichColor>
{
    public override RichColor? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        string? name = reader.GetString();
        if (name is null)
        {
            throw new JsonException("Expected a string value.");
        }

        try
        {
            return RichColor.Parse(name);
        }
        catch (NotSupportedException)
        {
            throw new JsonException($"The color '{name}' is not supported.");
        }
    }

    public override void Write(Utf8JsonWriter writer, RichColor value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Name);
    }
}