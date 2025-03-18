using System.Text.Json;
using System.Text.Json.Serialization;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Serialization;

internal sealed class BirdJsonConverter : JsonConverter<Bird>
{
    public override Bird? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        GuardSerializerUsageContract(reader, typeToConvert);

        reader.Read();

        NonEmptyString? name = null;
        NonEmptyString? species = null;

        while (reader.TokenType != JsonTokenType.EndObject)
        {
            ReadProperty(ref reader, options, ref name, ref species);
        }

        string[] missingProperties = new []
        {
            name is null ? "name" : string.Empty,
            species is null ? "species" : string.Empty,
        }.Where(p => !string.IsNullOrEmpty(p)).ToArray();

        if (missingProperties.Any())
        {
            throw new JsonException($"Missing required properties: {string.Join(", ", missingProperties)}");
        }

        return Bird.Create(name!, species!);
    }

    public override void Write(Utf8JsonWriter writer, Bird value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WritePropertyName("name");
        JsonSerializer.Serialize(writer, value.Name, options);

        writer.WritePropertyName("species");
        JsonSerializer.Serialize(writer, value.Species, options);

        writer.WriteEndObject();
    }

    private static void ReadProperty(
        ref Utf8JsonReader reader,
        JsonSerializerOptions options,
        ref NonEmptyString? name,
        ref NonEmptyString? species)
    {
        if (reader.TokenType != JsonTokenType.PropertyName)
        {
            throw new JsonException($"Expected PropertyName but received a {reader.TokenType.ToString()}");
        }

        string? propertyName = reader.GetString();
        if (propertyName is null)
        {
            throw new JsonException("Expected a property name but received null");
        }

        reader.Read();

        switch (propertyName)
        {
            case "name":
                name = JsonSerializer.Deserialize<NonEmptyString>(ref reader, options);
                break;
            case "species":
                species = JsonSerializer.Deserialize<NonEmptyString>(ref reader, options);
                break;
            default:
                reader.Skip();
                break;
        }

        reader.Read();
    }

    private static void GuardSerializerUsageContract(Utf8JsonReader reader, Type typeToConvert)
    {
        if (typeToConvert != typeof(Bird))
        {
            throw new JsonException("Expected type to convert to be Bird");
        }

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException($"Expected StartObject but received a {reader.TokenType.ToString()}");
        }
    }
}