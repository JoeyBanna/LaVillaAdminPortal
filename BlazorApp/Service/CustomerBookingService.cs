using BlazorApp.Models;
using BlazorApp.Service.IService;
using Models;
using Newtonsoft.Json;

namespace BlazorApp.Service
{
    public class CustomerBookingService : ICustomerBookingService
    {
        private readonly HttpClient _httpClient;

        public CustomerBookingService(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }

        public async Task<CustomerBooking> CancelBooking(string customerBookingId)
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelBookings/CancelHotelRoom/" + customerBookingId;
            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {

                var hotelroom = JsonConvert.DeserializeObject<CustomerBooking>(content);
                return hotelroom;
            }
            return null;
        }

        public async Task<IEnumerable<CustomerBooking>> getAllBooking()
        {
            try
            {
               
                var response = await _httpClient.GetAsync("https://psl-app-vm3/HotelAdminAPI/api/HotelBookings");
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    
                    var Bookings = JsonConvert.DeserializeObject<IEnumerable<CustomerBooking>>(content);
                    return Bookings;
                }
                return new List<CustomerBooking>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<CustomerBooking> GetBooking(string bookingID)
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelBookings/" + bookingID;
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {

                var bookings = JsonConvert.DeserializeObject<CustomerBooking>(content);
                return bookings;
            }
            return null;
        }
    }
}
