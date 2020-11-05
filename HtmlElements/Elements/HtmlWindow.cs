using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace HtmlElements.Elements
{
    public class HtmlWindow : HtmlElement
    {
        protected override string JsNamespace => "interop.window.";

        internal HtmlWindow(IJSRuntime jsRuntime) : base(jsRuntime)
        {
        }

        public async Task AlertAsync(string message)
        {
            await JsRuntime.InvokeVoidAsync(BuildJsFunctionPath("alert"), message);
        }
    }
}
