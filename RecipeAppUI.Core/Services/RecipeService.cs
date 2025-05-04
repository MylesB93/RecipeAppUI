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

				recipes = apiResult?.Items?
					.Select(r => new Recipe
					{
						Name = r?.Name ?? "",
						Ingredients = r?.Properties?.RecipeIngredients?.Select(i => new Ingredient { Name = i?.Name ?? "" })?.ToList() ?? new List<Ingredient>(),
						Utensils = r?.Properties?.RecipeUtensils?.Select(u => new Utensil { Name = u?.Name ?? ""})?.ToList() ?? new List<Utensil>(),
						Instructions = r?.Properties?.CookingInstructions ?? Array.Empty<string>(),
						Id = r?.Id ?? ""
					})
					.ToList();
			}

			return recipes ?? new List<Recipe>();
		}

		public async Task<Recipe> GetRecipeAsync(string id)
		{
			var response = await _httpClient.GetAsync($"/umbraco/delivery/api/v2/content/item/{id}");
			if (response.IsSuccessStatusCode)
			{
				//TODO: Repeated code
				var json = await response.Content.ReadAsStringAsync();
				var apiResult = JsonSerializer.Deserialize<Item>(json, new JsonSerializerOptions // TODO: cache json serializer options initialisation
				{
					PropertyNameCaseInsensitive = true
				});

				return new Recipe() { Id = apiResult?.Id ?? "", Name = apiResult?.Name ?? "", Ingredients = new List<Ingredient>(), Utensils = new List<Utensil>(), Instructions = apiResult?.Properties?.CookingInstructions ?? Array.Empty<string>() }; // TODO: Populate fields properly
			}
			else
			{
				return new Recipe() { Id = "", Name = "", Ingredients = new List<Ingredient>(), Utensils = new List<Utensil>(), Instructions = Array.Empty<string>() };
			}
		}
	}
}
