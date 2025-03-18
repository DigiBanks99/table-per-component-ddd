using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Persistence.ValueConverters;

internal sealed class IdTypeValueConverter() : ValueConverter<IdType, string>(
    value => value.Name,
    dbValue => IdType.Parse(dbValue));