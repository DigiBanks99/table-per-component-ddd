using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using TablePerComponent.App.Models;

namespace TablePerComponent.App.Persistence.ValueConverters;

internal sealed class NonEmptyStringValueConverter() : ValueConverter<NonEmptyString, string>(
    value => value,
    dbValue => new NonEmptyString(dbValue)
);