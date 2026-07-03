using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trion.Domain.AthleteAggregate.ValueObjects;

namespace Trion.Infrastructure.Persistence.Converters;

public class AthleteIdConverter() : ValueConverter<AthleteId, Guid>(
    id => id.Value,
    value => AthleteId.From(value));