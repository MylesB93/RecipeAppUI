namespace RecipeAppUI.Core.Models
{
	public class Rootobject
	{
		public Item[] Items { get; set; }
	}

	public class Item
	{
		public string Name { get; set; }
		public Properties Properties { get; set; }
	}

	public class Properties
	{
		public Recipeingredient[] RecipeIngredients { get; set; }
	}

	public class Recipeingredient
	{
		public string Name { get; set; }
		public Properties1 Properties { get; set; }
	}

	public class Properties1
	{
	}
}
