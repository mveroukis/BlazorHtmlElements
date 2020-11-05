using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HtmlElements.Elements
{
    public abstract class HtmlElement
    {
        protected IJSRuntime JsRuntime { get; private set; }
        protected ElementReference ElementRef { get; private set; }
        protected DotNetObjectReference<HtmlElement> ObjectRef { get; private set; }

        protected abstract string JsNamespace { get; }


        internal HtmlElement(IJSRuntime jsRuntime)
        {
            JsRuntime = jsRuntime;
            ElementRef = default;

            ObjectRef = DotNetObjectReference.Create(this);
        }

        internal HtmlElement(IJSRuntime jsRuntime, ElementReference element)
        {
            JsRuntime = jsRuntime;
            ElementRef = element;

            ObjectRef = DotNetObjectReference.Create(this);
        }


        protected string BuildJsFunctionPath(string function)
        {
            return $"{JsNamespace}{function}";
        }
    }
}
