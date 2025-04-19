using RecipeAppUI.Core.Models;

namespace RecipeAppUI.Core.Interfaces
{
	public interface IRecipeService
	{
		Task<List<Item>> GetAllRecipesAsync();
	}
}
