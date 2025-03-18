using TablePerComponent.App.Serialization;

namespace TablePerComponent.App.Host;

internal static class JsonHostBuilderExtensions
{
    public static void ConfigureSerialization(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpJsonOptions(jsonOptions => {
            jsonOptions.SerializerOptions.Converters.Add(new NonEmptyStringJsonConverter());
            jsonOptions.SerializerOptions.Converters.Add(new RichColorJsonConverter());
            jsonOptions.SerializerOptions.Converters.Add(new BirdJsonConverter());
            jsonOptions.SerializerOptions.Converters.Add(new CatJsonConverter());
            jsonOptions.SerializerOptions.Converters.Add(new DogJsonConverter());
        });
    }
}