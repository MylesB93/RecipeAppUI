using RecipeAppUI.Core.Interfaces;
using RecipeAppUI.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

public class RecipesViewModel : INotifyPropertyChanged
{
	private readonly IRecipeService _recipeService;

	public ObservableCollection<Recipe> Recipes { get; set; } = new();
	public ObservableCollection<Recipe> FilteredRecipes { get; set; } = new();

	private string _searchText = string.Empty;
	public string SearchText
	{
		get => _searchText;
		set
		{
			if (_searchText != value)
			{
				_searchText = value;
				OnPropertyChanged();
				FilterRecipes();
			}
		}
	}

	public RecipesViewModel(IRecipeService recipeService)
	{
		_recipeService = recipeService;
		LoadRecipes();
	}

	private async void LoadRecipes()
	{
		var recipes = await _recipeService.GetAllRecipesAsync();
		Recipes.Clear();
		foreach (var recipe in recipes)
		{
			Recipes.Add(recipe);
		}
		FilterRecipes();
	}

	private void FilterRecipes()
	{
		FilteredRecipes.Clear();
		var filtered = string.IsNullOrWhiteSpace(SearchText)
			? Recipes
			: Recipes.Where(r => r.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
		foreach (var recipe in filtered)
		{
			FilteredRecipes.Add(recipe);
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string name = null!) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
