namespace RecipeAppUI.Core.Models
{
	public class Recipe
	{
		public required string Name { get; set; }
		public required List<Ingredient> Ingredients { get; set; }
		public required List<Utensil> Utensils { get; set; }
	}
}
