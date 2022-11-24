using Microsoft.Maui.Hosting;
using Microsoft.Maui.LifecycleEvents;

namespace WebviewMinimal;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


#if WINDOWS
        builder.UseMauiApp<App>()
        .ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(win => win
            .OnWindowCreated(WebviewMinimal.WinUI.App.WindowCreated)
                             );
        });
#endif

        return builder.Build();
    }
}
