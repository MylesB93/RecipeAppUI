using RecipeAppUI.Core.Interfaces;
using RecipeAppUI.Core.Models;
using System.Text.Json;

namespace RecipeAppUI.Core.Services
{
	public class RecipeService : IRecipeService
	{
		private readonly HttpClient _httpClient;

		public RecipeService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Recipe>> GetAllRecipesAsync()
		{
			var recipes = new List<Recipe>();
			var response = await _httpClient.GetAsync("/umbraco/delivery/api/v2/content?filter=contentType:recipe");

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var apiResult = JsonSerializer.Deserialize<Rootobject>(json, new JsonSerializerOptions // TODO: cache json serializer options initialisation
				{
					PropertyNameCaseInsensitive = true
				});

				recipes = apiResult?.Items
					.Select(r => new Recipe
					{
						Name = r.Name,
						Ingredients = r.Properties.RecipeIngredients.Select(i => new Ingredient { Name = i.Name }).ToList(),
						Utensils = r.Properties.RecipeUtensils.Select(u => new Utensil { Name = u.Name}).ToList(),
						Instructions = r.Properties.CookingInstructions
					})
					.ToList();
			}

			return recipes;
		}
	}
}
