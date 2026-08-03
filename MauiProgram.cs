using Microsoft.Extensions.Logging;
using Reflections.ViewModels;
using Reflections.Views;

namespace Reflections;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomeViewModel>();

        builder.Services.AddTransient<NewEntryPage>();
        builder.Services.AddTransient<NewEntryViewModel>();

        builder.Services.AddTransient<EntryDetailPage>();
        builder.Services.AddTransient<EntryDetailViewModel>();

        builder.Services.AddSingleton<SettingsPage>();
        builder.Services.AddSingleton<SettingsViewModel>();

        return builder.Build();
    }
}