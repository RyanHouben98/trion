using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trion.Domain.AthleteAggregate;
using Trion.Infrastructure.Persistence.Converters;

namespace Trion.Infrastructure.Persistence.Configurations;

public class AthleteConfiguration : IEntityTypeConfiguration<Athlete>
{
    public void Configure(EntityTypeBuilder<Athlete> builder)
    {
        builder.ToTable("athletes");
        
        builder.HasKey(athlete => athlete.Id);
        builder.Property(athlete => athlete.Id)
            .HasConversion(new AthleteIdConverter());
        
        builder.Property(athlete => athlete.Name)
            .IsRequired();
    }
}