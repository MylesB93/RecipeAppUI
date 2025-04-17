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
			return Task.FromResult(new List<Recipe>());
		}
	}
}
