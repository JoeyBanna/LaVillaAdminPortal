using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Service.IService
{
    public interface IFileUpload
    {
        Task<string> uploadFile(IBrowserFile file);
        bool DeleteFile(string fileName);

    }
}
