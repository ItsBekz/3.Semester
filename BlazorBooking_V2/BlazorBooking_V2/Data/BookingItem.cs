namespace BlazorBooking_V2.Data
{
    public class BookingItem
    {
        public int id { get; set; }
        public int[] seatNumbers { get; set; }
        public bool isBooked { get; set; }
    }
}
