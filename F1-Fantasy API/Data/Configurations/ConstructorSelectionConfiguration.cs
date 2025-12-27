using F1_Fantasy_API.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1_Fantasy_API.Data.Configurations
{
    public class ConstructorSelectionConfiguration : IEntityTypeConfiguration<ConstructorSelection>
    {
        public void Configure(EntityTypeBuilder<ConstructorSelection> builder)
        {
            builder.HasKey(cs => new { cs.RaceId, cs.ConstructorId, cs.TeamId });

            builder.HasOne(cs => cs.Team)
                .WithMany(t => t.ConstructorSelections)
                .HasForeignKey(cs => cs.TeamId);

            builder.HasOne(cs => cs.Race)
                .WithMany(r => r.ConstructorSelections)
                .HasForeignKey(cs => cs.RaceId);

            builder.HasOne(cs => cs.Constructor)
                .WithMany(c => c.ConstructorSelections)
                .HasForeignKey(cs => cs.ConstructorId);
        }
    }

}
