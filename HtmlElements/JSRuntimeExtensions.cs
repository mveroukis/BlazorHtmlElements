using HtmlElements.Elements;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace HtmlElements
{
    public static class JSRuntimeExtensions
    {
        public static Task<HtmlWindow> BindToWindowAsync(this IJSRuntime jsRuntime)
        {
            return Task.FromResult(new HtmlWindow(jsRuntime));
        }

        public static async Task<HtmlDialog> BindToDialogAsync(this IJSRuntime jsRuntime, ElementReference element)
        {
            var dialog = new HtmlDialog(jsRuntime, element);
            await dialog.InitializeAsync();

            return dialog;
        }
    }
}
