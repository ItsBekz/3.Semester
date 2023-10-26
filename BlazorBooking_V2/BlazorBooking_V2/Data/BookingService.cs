using ServiceReference1;

namespace BlazorBooking_V2.Data
{
    public class BookingService
    {
        private readonly Service1Client _client;

        public BookingService(Service1Client client)
        {
            _client = client;
        }

        public async Task<bool> CreateBookingNumber(int numberOfSeats)
        {
            int bookingNumber = GenerateBookingNumber();
            return await _client.CreateBookingNumberAsync(bookingNumber, numberOfSeats);
        }

        public async Task<bool> DeleteBookingNumber(int bookingNumber)
        {
            return await _client.DeleteBookingNumberAsync(bookingNumber);
        }

        public async Task<bool> SetBookingItems(int bookingNumber, BookingItem[] bookings)
        {
            return await _client.SetBookingItemsAsync(bookingNumber, bookings);
        }

    }
}
