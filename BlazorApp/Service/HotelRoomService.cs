using BlazorApp.Data;
using BlazorApp.Models;
using Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BlazorApp.Service
{
    public class HotelRoomService : IHotelRoomService
    {
        private readonly HttpClient _httpClient;

        public HotelRoomService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HotelRoomDT> GetHotelRoomById(string hotelRoomId)
        {
            var url = "httpS://psl-app-vm3/HotelAdminAPI/api/HotelRooms/" + hotelRoomId;
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                
                var hotelroom = JsonConvert.DeserializeObject<HotelRoomDT>(content);
                return hotelroom;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

     

        public async Task<IEnumerable<HotelRoomDT>> GetHotelRoomsFromApi(string accessToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.GetAsync("https://psl-app-vm3/HotelAdminAPI/api/HotelRooms");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var hotelrooms = JsonConvert.DeserializeObject<IEnumerable<HotelRoomDT>>(content);
                    return hotelrooms;
                }
                return new List<HotelRoomDT>();
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        public async Task<HotelRoomDT> DeleteHotelRoom(string hotelRoomId)
        {


            var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelRooms/DeleteHotelRoom/" + hotelRoomId;
            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                
                var hotelroom = JsonConvert.DeserializeObject<HotelRoomDT>(content);
                return hotelroom;
            }
            return null;
            



        }
         public async Task<HotelRoomDT> CreateHotelRoom(HotelRoomDT hotelRoomDTO)
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelRooms/";
            var json = JsonConvert.SerializeObject(hotelRoomDTO);
            var data = new StringContent(json,Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, data);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var hotelroom = JsonConvert.DeserializeObject<HotelRoomDT>(content);
                return hotelroom;
            }
       
            return null;

            
        }
        public async Task<HotelRoomDT> UpdateHotelRoom(string hotelRoomId , CreateHotelRoomModel hotelRoomDTO)
        {
            try
            {
                var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelRooms/UpdateHotelRoom/" + hotelRoomId;

                var json = JsonConvert.SerializeObject(hotelRoomDTO);

                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(url, data);
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var hotelroom = JsonConvert.DeserializeObject<HotelRoomDT>(content);

                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public  async Task<HotelRoomDT> CreateHotelRoomModel(CreateHotelRoomModel hotelRoomDTO)
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/HotelRooms/";
            var json = JsonConvert.SerializeObject(hotelRoomDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, data);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var hotelroom = JsonConvert.DeserializeObject<HotelRoomDT>(content);
                return hotelroom;
            }

            return null;
        }
        public async Task<IEnumerable<RoomTypes>> GetRoomTypes()
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/Codes/GetCodesByType/HOTRT";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {

                var hotelroom = JsonConvert.DeserializeObject<IEnumerable<RoomTypes>>(content);
                return hotelroom;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }

        }

       
    }
}
