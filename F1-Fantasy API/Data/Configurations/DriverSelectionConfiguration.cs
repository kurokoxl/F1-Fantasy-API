using F1_Fantasy_API.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1_Fantasy_API.Data.Configurations
{
    public class DriverSelectionConfiguration : IEntityTypeConfiguration<DriverSelection>
    {
        public void Configure(EntityTypeBuilder<DriverSelection> builder)
        {
            builder.HasKey(ds => new { ds.RaceId, ds.DriverId, ds.TeamId });

            builder.HasOne(ds => ds.Team)
                .WithMany(t => t.DriverSelections)
                .HasForeignKey(ds => ds.TeamId);

            builder.HasOne(ds => ds.Race)
                .WithMany(r => r.DriverSelections)
                .HasForeignKey(ds => ds.RaceId);

            builder.HasOne(ds => ds.Driver)
                .WithMany(d => d.DriverSelections)
                .HasForeignKey(ds => ds.DriverId);
        }
    }

}
