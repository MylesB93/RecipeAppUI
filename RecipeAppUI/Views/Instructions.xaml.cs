using RecipeAppUI.Core.Interfaces;
using RecipeAppUI.Core.Models;

namespace RecipeAppUI.Views;

[QueryProperty(nameof(RecipeID), "id")]
public partial class Instructions : ContentPage
{
	public string? RecipeID { get; set; }
	private readonly IRecipeService _recipeService;
	public Recipe? Recipe { get; set; }
	private readonly InstructionsViewModel _instructionsViewModel;

	public Instructions(IRecipeService recipeService)
	{
		InitializeComponent();		
		_recipeService = recipeService;

		_instructionsViewModel = new InstructionsViewModel(_recipeService);
		BindingContext = _instructionsViewModel;
	}

	protected async override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		if (RecipeID is not null)
			await _instructionsViewModel.LoadRecipeAsync(RecipeID);
	}
}