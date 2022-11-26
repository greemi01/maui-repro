using Microsoft.Maui.LifecycleEvents;

namespace MauiApp1
{
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
                })
                ;


#if WINDOWS
        // See https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/app-lifecycle?view=net-maui-7.0
        // for a list of events.
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(win => win
            .OnWindowCreated((window) => MauiApp1.WinUI.App.WindowCreated(window))
                             );
        });
#endif // WINDOWS

            return builder.Build();
        }
    }
}