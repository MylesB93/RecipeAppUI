using Microsoft.Extensions.Configuration;
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

			var config = new ConfigurationBuilder()
							.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
							.Build();

			var baseUrl = config["RecipeAPI:BaseUrl"] ?? throw new Exception("Base URL is missing from configuration.");

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
				BaseAddress = new Uri(baseUrl)
			});

			builder.Services.AddSingleton<IRecipeService, RecipeService>();

			return builder.Build();
		}
	}
}
