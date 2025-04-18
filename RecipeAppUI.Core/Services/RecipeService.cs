using RecipeAppUI.Core.Interfaces;
using RecipeAppUI.Core.Models;

namespace RecipeAppUI.Core.Services
{
	public class RecipeService : IRecipeService
	{
		private readonly HttpClient _httpClient;

		public RecipeService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public Task<List<Recipe>> GetAllRecipesAsync()
		{
			var recipes = _httpClient.GetAsync("/umbraco/delivery/api/v2/content?filter=contentType:recipe");
			return Task.FromResult(new List<Recipe>());
		}
	}
}
