using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence.Mapping
{
    public class KalenderMapping : IEntityTypeConfiguration<Kalender>
    {
        public void Configure(EntityTypeBuilder<Kalender> builder)
        {
            builder
                .HasOne(k => k.Hold)
                .WithMany(h => h.Kalendere);
            builder
                .HasOne(k => k.Underviser)
                .WithMany(u => u.Kalendere);
        }
    }
}