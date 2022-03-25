using BlazorApp.ModelsModels;
using BlazorApp.Service.IService;
using Models;
using Newtonsoft.Json;

namespace BlazorApp.Service
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;

        public NotificationService(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }

        public async Task<IEnumerable<Notifications>> getNotification()
        {
            try
            {
                var url = "https://psl-app-vm3/HotelAdminAPI/api/Notifications";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var hotelrooms = JsonConvert.DeserializeObject<IEnumerable<Notifications>>(content);
                    return hotelrooms;
                }
                return new List<Notifications>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
