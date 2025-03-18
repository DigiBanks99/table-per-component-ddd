using System.Text.Json;
using System.Text.Json.Serialization;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Serialization;

internal sealed class IdTypeJsonConverter : JsonConverter<IdType>
{
    public override IdType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
            return IdType.Parse(name);
        }
        catch (NotSupportedException)
        {
            throw new JsonException($"The id type '{name}' is not supported.");
        }
    }

    public override void Write(Utf8JsonWriter writer, IdType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Name);
    }
}