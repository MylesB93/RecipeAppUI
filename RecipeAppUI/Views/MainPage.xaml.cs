using RecipeAppUI.Core.Interfaces;

namespace RecipeAppUI.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IRecipeService recipeService)
        {
			InitializeComponent();
			BindingContext = new RecipeViewModel(recipeService);
		}

        public async void OnRecipeClicked(object sender, TappedEventArgs args)
        {
			await Shell.Current.GoToAsync("/Instructions");
		}

	}

}
