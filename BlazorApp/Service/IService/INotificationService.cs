using BlazorApp.ModelsModels;
using Models;
using System.Collections;

namespace BlazorApp.Service.IService
{
    public interface INotificationService
    {
        public Task<IEnumerable<Notifications>> getNotification();
    }
}
