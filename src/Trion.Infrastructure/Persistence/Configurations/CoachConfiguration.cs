using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trion.Domain.CoachAggregate;
using Trion.Infrastructure.Persistence.Converters;

namespace Trion.Infrastructure.Persistence.Configurations;

public class CoachConfiguration : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        builder.ToTable("coaches");

        builder.HasKey(coach => coach.Id);
        builder.Property(coach => coach.Id)
            .HasConversion(new CoachIdConverter());

        builder.Property(coach => coach.Name)
            .IsRequired();
    }
}