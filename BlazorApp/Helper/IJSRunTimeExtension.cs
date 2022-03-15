using Microsoft.JSInterop;
using System.Threading.Tasks;



namespace BlazorApp.Helper
{
    public static class IJSRunTimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message )
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "success", message);

        }
        public static async ValueTask ToastError(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "error", message);

        }
       
        public static async ValueTask SweetSuccess(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowSweet", "success", message);

        }
        public static async ValueTask SweetConfirm(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowSweet", "confirm", message);

        }
        public static async ValueTask SweetError(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowSweet", "error", message);

        }
    }
}
