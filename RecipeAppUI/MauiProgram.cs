using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
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
							.AddUserSecrets<App>()
							.Build();

			var baseUrl = config["RecipeAPI:BaseUrl"] ?? throw new Exception("Base URL is missing from configuration.");

			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif
			var client = new HttpClient
			{
				BaseAddress = new Uri(baseUrl)
			};
			client.DefaultRequestHeaders.Add("X-Api-Key", config["RecipeApp:APIKey"]);

			builder.Services.AddSingleton(client);

			builder.Services.AddSingleton<IRecipeService, RecipeService>();

			return builder.Build();
		}
	}
}
