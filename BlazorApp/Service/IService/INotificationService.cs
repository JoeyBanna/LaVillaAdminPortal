using BlazorApp.Models;
using BlazorApp.ModelsModels;
using Models;
using System.Collections;

namespace BlazorApp.Service.IService
{
    public interface INotificationService
    {
        public Task<IEnumerable<Notifications>> getNotification();
        public Task<IEnumerable<Notifica>> getNotificationsBadge();
        public Task<NotificationReadResponse> Updatenotifications(string Id, NotificationReadResponse notifications);
    }
}
