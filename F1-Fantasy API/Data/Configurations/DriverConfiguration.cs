using F1_Fantasy_API.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1_Fantasy_API.Data.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasOne(d => d.Constructor)
                .WithMany(c => c.Drivers)
                .HasForeignKey(d => d.ConstructorId);
        }
    }
}
