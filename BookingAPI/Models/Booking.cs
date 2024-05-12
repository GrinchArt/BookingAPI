namespace BookingAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }       
        public int AccommodationId { get; set; }
        public DateTime DateBooked { get; set; }

        //
        public User User { get; set; }
        public Accommodation Accommodation { get; set; }
    }
}
