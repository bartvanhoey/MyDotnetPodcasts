using Microsoft.JSInterop;

namespace MyDotnetPodcasts.MauiComponents;

public class ClipboardInterop 
{
    private readonly IJSRuntime _jsRuntime;

    public ClipboardInterop(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public ValueTask<string> ReadTextAsync()
    {
        return _jsRuntime.InvokeAsync<string>("navigator.clipboard.readText");
    }

    public ValueTask WriteTextAsync(string text)
    {
        return _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }
}