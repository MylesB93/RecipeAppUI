using RecipeAppUI.Core.Models;

namespace RecipeAppUI.Core.Interfaces
{
	public interface IRecipeService
	{
		Task<List<Recipe>> GetAllRecipesAsync();
		Task<Recipe> GetRecipeAsync(string id);
	}
}
