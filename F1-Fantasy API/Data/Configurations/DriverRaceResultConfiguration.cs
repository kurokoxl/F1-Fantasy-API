using F1_Fantasy_API.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1_Fantasy_API.Data.Configurations
{
    public class DriverRaceResultConfiguration : IEntityTypeConfiguration<DriverRaceResult>
    {
        public void Configure(EntityTypeBuilder<DriverRaceResult> builder)
        {
            builder.HasKey(dr => new { dr.DriverId, dr.RaceId });

            builder.HasOne(dr => dr.Driver)
                .WithMany(d => d.DriverRaceResults)
                .HasForeignKey(dr => dr.DriverId);

            builder.HasOne(dr => dr.Race)
                .WithMany(r => r.DriverRaceResults)
                .HasForeignKey(dr => dr.RaceId);
        }
    }

}
