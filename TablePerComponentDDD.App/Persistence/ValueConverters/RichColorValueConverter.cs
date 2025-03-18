using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Persistence.ValueConverters;

internal sealed class RichColorValueConverter() : ValueConverter<RichColor, string>(
    value => value.Name,
    dbValue => RichColor.Parse(dbValue));