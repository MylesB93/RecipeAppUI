using RecipeAppUI.Core.Interfaces;
using RecipeAppUI.Core.Models;

namespace RecipeAppUI.Views;

[QueryProperty(nameof(RecipeID), "id")]
public partial class Instructions : ContentPage
{
	public string? RecipeID { get; set; }
	private readonly IRecipeService _recipeService;
	public Instructions(IRecipeService recipeService)
	{
		InitializeComponent();
		BindingContext = this;
		_recipeService = recipeService;

		GetRecipeAsync();
	}

	public async Task<Recipe> GetRecipeAsync()
	{
		return await _recipeService.GetRecipeAsync(RecipeID);
	}
}