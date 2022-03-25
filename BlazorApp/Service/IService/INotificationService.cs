using BlazorApp.ModelsModels;
using Models;
using System.Collections;

namespace BlazorApp.Service.IService
{
    public interface INotificationService
    {
        public Task<IEnumerable<Notifications>> getNotification();
        public Task<IEnumerable<Notifica>> getNotificationsBadge();
        public Task<Notifications> Updatenotifications(string Id, Notifications notifications);
    }
}
