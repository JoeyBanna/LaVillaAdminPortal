using BlazorApp.Models;

namespace BlazorApp.Service.IService
{
    public interface IHotelAmenityService
    {
        public Task<HttpResponseMessage> CreateHotelAmenity(HotelAmenityDT hotelAmenityDTO);
        public Task<HotelAmenityDT> UpdateHotelAmenity(string amenityId, HotelAmenityDT hotelAmenityDTO);
        public Task<HotelAmenityDT> GetHotelAmenity(string amenityId);
        public Task<IEnumerable<HotelAmenityDT>> GetAllHotelAmenity(string accessToken);
        public Task<HotelAmenityDT> DeleteHotelAmenity(string amenityId = null);
    }
}
