window.interop = {
    setEventListener: (element, ref, eventName, callbackName) => {
        element.addEventListener(eventName, async e => {
            // 👇 Call the C# method from JavaScript
            await ref.invokeMethodAsync(callbackName, e);
        });
    },

    window: {
        alert: (message) => {
            alert(message);
        },

        prompt: (text, defaultText) => {
            return prompt(text, defaultText);
        }
    },

    dialog: {
        init: (dialog, ref) => {
            dialog.addEventListener("close", async e => {
                await ref.invokeMethodAsync("OnCloseAsync", dialog.returnValue);
            });
        },

        showModal: (dialog) => {
            if (!dialog.open) {
                dialog.showModal();
            }
        },

        closeModal: (dialog, returnValue) => {
            if (dialog && dialog.open) {
                dialog.returnValue = returnValue;
                dialog.close();
            }
        }
    },

    closeModel: (dialog, returnValue) => {
        if (dialog && dialog.open) {
            dialog.returnValue = returnValue;
            dialog.close();
        }
    }
}
