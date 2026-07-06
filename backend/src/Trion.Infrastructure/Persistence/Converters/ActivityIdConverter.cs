using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trion.Domain.ActivityAggregate.ValueObjects;

namespace Trion.Infrastructure.Persistence.Converters;

public class ActivityIdConverter() : ValueConverter<ActivityId, Guid>(
    id => id.Value,
    value => ActivityId.From(value));