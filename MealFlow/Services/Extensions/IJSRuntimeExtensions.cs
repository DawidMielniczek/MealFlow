using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.JSInterop;

namespace MealFlow.Services.Extensions
{
    public static class IJSRuntimeExtensions
    {
        public static async Task ToastSuccess(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("ShowToastr","success", message); 
        }
        public static async Task Toast(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("ShowToastr","error", message);
        }
    }
}
