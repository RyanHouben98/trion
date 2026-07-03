using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trion.Domain.ActivityAggregate;
using Trion.Infrastructure.Persistence.Converters;

namespace Trion.Infrastructure.Persistence.Configurations;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable("activities");
        
        builder.HasKey(activity => activity.Id);
        builder.Property(activity => activity.Id)
            .HasConversion(new ActivityIdConverter());
    }
}