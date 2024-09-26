using Android.Media;
using ListViewMAUI.Service;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace ListViewMAUI
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
                });

    #if DEBUG
    	    builder.Logging.AddDebug();
    #endif
           
            
            builder.Services.AddTransient<App>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AudioInfoViewModel>();

            builder.Services.AddSingleton<IAudioPlayerService, AudioPlayerService>();

            builder.ConfigureSyncfusionCore();

            return builder.Build();
        }
    }
}
