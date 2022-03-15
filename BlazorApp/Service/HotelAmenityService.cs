using BlazorApp.Models;
using BlazorApp.Service.IService;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BlazorApp.Service
{
    public class HotelAmenityService : IHotelAmenityService
    {
        private readonly HttpClient _httpClient;
     

        public HotelAmenityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }
        public async Task<HttpResponseMessage> CreateHotelAmenity(HotelAmenityDT hotelAmenityDTO)
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelAmenities";
            var json = JsonConvert.SerializeObject(hotelAmenityDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, data);
            var content = await response.Content.ReadAsStringAsync();
           //_httpClient.Dispose();
            return response; 
        }

        public async Task<HotelAmenityDT> DeleteHotelAmenity(string amenityId)
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelAmenities/" + amenityId;
            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {

                var hotelAmenity = JsonConvert.DeserializeObject<HotelAmenityDT>(content);
                return hotelAmenity;
            }
            return null;
        }

        public async Task<IEnumerable<HotelAmenityDT>> GetAllHotelAmenity(string accessToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await _httpClient.GetAsync("https://psl-app-vm3/HotelAdminAPI/api/HotelAmenities");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var hotelAmenity = JsonConvert.DeserializeObject<IEnumerable<HotelAmenityDT>>(content);
                    return hotelAmenity;
                }
                return new List<HotelAmenityDT>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HotelAmenityDT> GetHotelAmenity(string amenityId)
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelAmenities/" + amenityId;
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {

                var hotelAmenity = JsonConvert.DeserializeObject<HotelAmenityDT>(content);
                return hotelAmenity;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<HotelAmenityDT> UpdateHotelAmenity(string amenityId, HotelAmenityDT hotelAmenityDTO)
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelAmenities/" + amenityId;
            var json = JsonConvert.SerializeObject(hotelAmenityDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, data);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var hotelAmenity = JsonConvert.DeserializeObject<HotelAmenityDT>(content);
                return hotelAmenity;
                
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
            return null;
        }
    }
}
