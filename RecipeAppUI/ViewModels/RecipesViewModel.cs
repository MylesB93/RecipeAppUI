using RecipeAppUI.Core.Interfaces;
using RecipeAppUI.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class RecipesViewModel : INotifyPropertyChanged
{
	private readonly IRecipeService _recipeService;

	public ObservableCollection<Recipe> Recipes { get; set; } = new();

	public RecipesViewModel(IRecipeService recipeService)
	{
		_recipeService = recipeService;
		LoadRecipes();
	}

	private async void LoadRecipes()
	{
		var recipes = await _recipeService.GetAllRecipesAsync();
		foreach (var recipe in recipes)
		{
			Recipes.Add(recipe);
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string name = null!) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
