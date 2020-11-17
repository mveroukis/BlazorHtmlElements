window.debug = {
    log: async (msg) => {
        await DotNet.invokeMethodAsync("BlazorApp", "DebugLog", msg);
    }
};

window.JsGuidGenerator = {
    intervalId: null,
    start: (objRef) => {
        debug.log("Guid generation started");

        JsGuidGenerator.intervalId = setInterval(async () => {
            const guid = await objRef.invokeMethodAsync("GenerateGuid");

            debug.log(guid);
        }, 2000);
    },

    stop: () => {
        if (JsGuidGenerator.intervalId) {
            clearInterval(JsGuidGenerator.intervalId);
            JsGuidGenerator.intervalId = null;

            debug.log("Guid generation stopped");
        }
    }
};

