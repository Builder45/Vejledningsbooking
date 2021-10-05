using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence.Mapping
{
    public class BookingVindueMapping : IEntityTypeConfiguration<BookingVindue>
    {
        public void Configure(EntityTypeBuilder<BookingVindue> builder)
        {
            builder
                .HasOne(bv => bv.Kalender)
                .WithMany(b => b.BookingVinduer);
            builder
                .HasOne(bv => bv.Underviser)
                .WithMany(u => u.BookingVinduer);
        }
    }
}