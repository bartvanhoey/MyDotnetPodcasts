using Microsoft.AspNetCore.Components;

namespace MyDotnetPodcasts.MauiComponents.Events;

[EventHandler("onanimationend", typeof(EventArgs),
    enableStopPropagation: true, enablePreventDefault: false)]
public static class EventHandlers
{
}
