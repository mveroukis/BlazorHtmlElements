﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HtmlElements.Elements
{
    public class HtmlDialog : HtmlElement, IAsyncInitialize
    {
        private Func<string, Task> _asyncOnCloseAction = null;

        internal HtmlDialog(IJSRuntime jsRuntime, ElementReference element) : base(jsRuntime, element)
        {
        }

        protected override string JsNamespace => "interop.dialog.";

        public async Task InitializeAsync()
        {
            await JsRuntime.InvokeVoidAsync(BuildJsFunctionPath("init"), ElementRef, ObjectRef);
        }


        public HtmlDialog SetAsyncOnCloseAction(Func<string, Task> action)
        {
            _asyncOnCloseAction = action;

            return this;
        }

        public async Task ShowModalAsync()
        {
            await JsRuntime.InvokeVoidAsync(BuildJsFunctionPath("showModal"), ElementRef);
        }


        public async Task CloseModalAsync(string returnValue = null)
        {
            await JsRuntime.InvokeVoidAsync(BuildJsFunctionPath("closeModal"), ElementRef, returnValue);
        }

        [JSInvokable]
        public async Task OnCloseAsync(string returnValue)
        {
            await _asyncOnCloseAction?.Invoke(returnValue);

            Debug.WriteLine($"Called from JS: {returnValue}");
        }
    }
}