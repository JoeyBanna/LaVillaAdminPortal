using BlazorApp.Service.IService;
using Models;
using Newtonsoft.Json;
using System.Text;

namespace BlazorApp.Service
{

    public class HotelImageService : IHotelRoomImageService
    {
        private readonly HttpClient _httpClient;

        public HotelImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HotelRoomImageDT> CreateHotelRoomImage(HotelRoomImageDT image)
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelRoomImages";
            var json = JsonConvert.SerializeObject(image);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, data);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var hotelroom = JsonConvert.DeserializeObject<HotelRoomImageDT>(content);
                return hotelroom;
              
            }
            return null;
        }
       


       

        public async Task<HotelRoomImageDT> DeleteHotelImageByImageURL(string imageName)
        {
            var response = await _httpClient.DeleteAsync("https://psl-app-vm3/HotelAdminAPI/api/HotelRoomImages/{hotelImageName}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var hotelroom = JsonConvert.DeserializeObject<HotelRoomImageDT>(content);
                return hotelroom;
            }
            return null;
        }

        public async Task<HotelRoomImageDT> DeleteHotelRoomImageID(string imageId)
        {
            var response = await _httpClient.DeleteAsync("https://psl-app-vm3/HotelAdminAPI/api/HotelRoomImages/{hotelRoomImageId}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var hotelroom = JsonConvert.DeserializeObject<HotelRoomImageDT>(content);
                return hotelroom;
            }
            return null;
        }

        public async Task<IEnumerable<HotelRoomImageDT>> GetHotelRoomImages(string roomId)
        {
            try
            {
                var response = await _httpClient.GetAsync("https://psl-app-vm3/HotelAdminAPI/api/HotelRoomImages/{hotelRoomImageId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var hotelrooms = JsonConvert.DeserializeObject<IEnumerable<HotelRoomImageDT>>(content);
                    return hotelrooms;
                }
                return new List<HotelRoomImageDT>();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
