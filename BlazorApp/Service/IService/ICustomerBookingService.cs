using BlazorApp.Models;
using Models;

namespace BlazorApp.Service.IService
{
    public interface ICustomerBookingService
    {
        public Task<IEnumerable<CustomerBooking>> getAllBooking();

        public Task <CustomerBooking> CancelBooking(string bookingId);
        public Task<CustomerBooking> GetBooking(string bookingID);
        
    }
}
