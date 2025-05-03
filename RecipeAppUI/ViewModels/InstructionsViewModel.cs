using RecipeAppUI.Core.Interfaces;
using RecipeAppUI.Core.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class InstructionsViewModel : INotifyPropertyChanged
{
	private readonly IRecipeService _recipeService;

	private Recipe? _recipe;
	public Recipe? Recipe
	{
		get => _recipe;
		set
		{
			_recipe = value;
			OnPropertyChanged();
		}
	}

	public InstructionsViewModel(IRecipeService recipeService)
	{
		_recipeService = recipeService;
	}

	public async Task LoadRecipeAsync(string recipeId)
	{
		Recipe = await _recipeService.GetRecipeAsync(recipeId);
	}

	public event PropertyChangedEventHandler? PropertyChanged;
	protected void OnPropertyChanged([CallerMemberName] string name = "")
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
