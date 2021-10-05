using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vejledningsbooking.Domain;

namespace Vejledningsbooking.Persistence.Mapping
{
    public class BookingMapping : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder
                .HasOne(b => b.BookingVindue)
                .WithMany(bv => bv.Bookinger);
            builder
                .HasOne(b => b.Studerende)
                .WithMany(s => s.Bookinger);
            builder
                .Property(p => p.RowVersion)
                .IsRowVersion()
                .IsRequired();
        }
    }
}