using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingAPI.EntityTypeConfiguration
{
    public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasOne(b => b.User).WithMany().HasForeignKey(b => b.UserId);
            builder.HasOne(b => b.Accommodation).WithMany().HasForeignKey(b => b.AccommodationId);
            builder.Property(b => b.DateBooked).IsRequired();
        }
    }
}
