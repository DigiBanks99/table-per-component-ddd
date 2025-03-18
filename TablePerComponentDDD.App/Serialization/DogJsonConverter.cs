using System.Text.Json;
using System.Text.Json.Serialization;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Serialization;

internal sealed class DogJsonConverter : JsonConverter<Dog>
{
    public override Dog? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        GuardSerializerUsageContract(reader, typeToConvert);

        reader.Read();

        NonEmptyString? name = null;
        NonEmptyString? breed = null;
        RichColor? color = null;
        Owner? owner = null;

        while (reader.TokenType != JsonTokenType.EndObject)
        {
            ReadProperty(ref reader, options, ref name, ref breed, ref color, ref owner);
        }

        string[] missingProperties = new []
        {
            name is null ? "name" : string.Empty,
            breed is null ? "breed" : string.Empty
        }.Where(p => !string.IsNullOrEmpty(p)).ToArray();

        if (missingProperties.Any())
        {
            throw new JsonException($"Missing required properties: {string.Join(", ", missingProperties)}");
        }

        return Dog.Create(name!, breed!, color, owner!);
    }

    public override void Write(Utf8JsonWriter writer, Dog value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WritePropertyName("name");
        JsonSerializer.Serialize(writer, value.Name, options);

        writer.WritePropertyName("breed");
        JsonSerializer.Serialize(writer, value.Breed, options);

        writer.WritePropertyName("color");
        JsonSerializer.Serialize(writer, value.Color, options);

        writer.WritePropertyName("owner");
        JsonSerializer.Serialize(writer, value.Owner, options);

        writer.WriteEndObject();
    }

    private static void ReadProperty(
        ref Utf8JsonReader reader,
        JsonSerializerOptions options,
        ref NonEmptyString? name,
        ref NonEmptyString? breed,
        ref RichColor? color,
        ref Owner? owner)
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
            case "breed":
                breed = JsonSerializer.Deserialize<NonEmptyString>(ref reader, options);
                break;
            case "color":
                color = JsonSerializer.Deserialize<RichColor>(ref reader, options);
                break;
            case "owner":
                owner = JsonSerializer.Deserialize<Owner>(ref reader, options);
                break;
            default:
                reader.Skip();
                break;
        }

        reader.Read();
    }

    private static void GuardSerializerUsageContract(Utf8JsonReader reader, Type typeToConvert)
    {
        if (typeToConvert != typeof(Dog))
        {
            throw new JsonException("Expected type to convert to be Dog");
        }

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException($"Expected StartObject but received a {reader.TokenType.ToString()}");
        }
    }
}