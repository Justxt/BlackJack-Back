using AppBlackJack.Services;
using Microsoft.Extensions.Logging;

namespace AppBlackJack
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
                    fonts.AddFont("Norican-Regular.ttf", "NoricanRegular");
                    fonts.AddFont("Rye-Regular.ttf", "RyeRegular");
                    fonts.AddFont("LibreBarcode-Regular.ttf", "LibreBarcode");
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
