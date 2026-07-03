using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trion.Domain.CoachAggregate.ValueObjects;

namespace Trion.Infrastructure.Persistence.Converters;

public class CoachIdConverter() : ValueConverter<CoachId, Guid>(
    id => id.Value,
    id => CoachId.From(id));