using BlazorApp.Models;
using BlazorApp.ModelsModels;
using BlazorApp.Service.IService;
using Models;
using Newtonsoft.Json;
using System.Text;

namespace BlazorApp.Service
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;

        public NotificationService(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }

        public async Task<NotificationReadResponse> Updatenotifications(string Id, NotificationReadResponse notifications)
        {
            var url = "https://psl-app-vm3/HotelAdminAPI/api/Notifications/updateNotification/" + Id;
            var json = JsonConvert.SerializeObject(notifications);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, data);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var hotelroom = JsonConvert.DeserializeObject<NotificationReadResponse>(content);
                
            }
            return JsonConvert.DeserializeObject<NotificationReadResponse>(json);


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
        public async Task<IEnumerable<Notifica>> getNotificationsBadge()
        {
            try
            {
                var url = "https://psl-app-vm3/HotelAdminAPI/api/Notifications";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var hotelrooms = JsonConvert.DeserializeObject<IEnumerable<Notifica>>(content);
                    return hotelrooms;
                }
                return new List<Notifica>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
