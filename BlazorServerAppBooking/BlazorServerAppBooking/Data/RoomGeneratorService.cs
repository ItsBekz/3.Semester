namespace BlazorServerAppBooking.Data
{
    public class RoomGeneratorService
    {
        public Task<Seat[]> GetSeatsAsync(int numberOfSeats)
        {
            return Task.FromResult(Enumerable.Range(1, numberOfSeats).Select(index => new Seat
            {
                id = index,
                row = index,
                column = index,
                isBooked = false,
                state = "free"
            }).ToArray());
        }
    }
}
