window.debug = {
    log: async (msg) => {
        await DotNet.invokeMethodAsync("BlazorApp", "DebugLog", msg);
    }
};

window.JsGuidGenerator = {
    start: (objRef) => {
        setInterval(async () => {
            const guid = await objRef.invokeMethodAsync("GenerateGuid");

            debug.log(guid);
        }, 2000);
    }
};

