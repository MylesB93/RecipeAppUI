using System.Web;

namespace RecipeAppUI.Core.Models
{
	public class Rootobject
	{
		public Item[]? Items { get; set; }
	}

	public class Item
	{
		public string? Name { get; set; }
		public Properties? Properties { get; set; }
		public string? Id { get; set; }
	}

	public class Properties
	{
		public Recipeingredient[]? RecipeIngredients { get; set; }
		public List<RecipeUtensil>? RecipeUtensils { get; set; }
		public string[]? CookingInstructions { get; set; }
	}

	public class Recipeingredient
	{
		public string? Name { get; set; }
		public Properties1? Properties { get; set; }
	}

	public class RecipeUtensil
	{
		public string? Name { get; set; }
	}

	public class Properties1
	{
	}
}
