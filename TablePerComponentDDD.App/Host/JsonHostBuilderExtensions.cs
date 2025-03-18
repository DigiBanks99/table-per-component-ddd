using TablePerComponent.App.Serialization;

namespace TablePerComponent.App.Host;

internal static class JsonHostBuilderExtensions
{
    public static void ConfigureSerialization(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpJsonOptions(jsonOptions => {
            jsonOptions.SerializerOptions.Converters.Add(new NonEmptyStringJsonConverter());
        });
    }
}