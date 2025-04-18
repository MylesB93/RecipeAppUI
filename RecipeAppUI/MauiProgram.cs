using Microsoft.Extensions.Logging;
using RecipeAppUI.Core.Interfaces;
using RecipeAppUI.Core.Services;

namespace RecipeAppUI
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
			builder.Services.AddSingleton(new HttpClient
			{
				BaseAddress = new Uri("https://localhost:44383/")
			});

			builder.Services.AddSingleton<IRecipeService, RecipeService>();

			return builder.Build();
        }
    }
}
