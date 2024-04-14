using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace TradingBotMauiBlazorHybridApp
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#else
            // Add production logging here if needed
#endif

            // Add logging services (for both DEBUG and RELEASE configurations)
            builder.Logging.AddDebug();

            // Register the HttpClient
            builder.Services.AddSingleton<HttpClient>();

            return builder.Build();
        }
    }
}
