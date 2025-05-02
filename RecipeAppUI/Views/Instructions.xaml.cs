using RecipeAppUI.Core.Interfaces;
using RecipeAppUI.Core.Models;

namespace RecipeAppUI.Views;

[QueryProperty(nameof(RecipeID), "id")]
public partial class Instructions : ContentPage
{
	public string? RecipeID { get; set; }
	private readonly IRecipeService _recipeService;
	public Recipe Recipe { get; set; }

	public Instructions(IRecipeService recipeService)
	{
		InitializeComponent();
		BindingContext = Recipe;
		_recipeService = recipeService;
	}

	protected async override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		Recipe = await GetRecipeAsync();
	}

	public async Task<Recipe> GetRecipeAsync()
	{
		return await _recipeService.GetRecipeAsync(RecipeID);
	}
}