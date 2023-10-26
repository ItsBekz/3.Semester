namespace BlazorServerAppBooking.Data
{
    public class Seat
    {
        public int id { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public bool isBooked { get; set; }
        public string state { get; set; }
    }
}
