using RecipeAppUI.Core.Interfaces;

namespace RecipeAppUI.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage(IRecipeService recipeService)
		{
			InitializeComponent();
			BindingContext = new RecipesViewModel(recipeService);
		}

		public async void OnRecipeClicked(object sender, TappedEventArgs args)
		{
			if (sender is View view && view.GestureRecognizers.FirstOrDefault() is TapGestureRecognizer tapGesture)
			{
				var id = tapGesture.CommandParameter.ToString();
				await Shell.Current.GoToAsync($"{nameof(Instructions)}?id={id}");
			}
		}

	}

}
