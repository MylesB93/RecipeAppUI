using RecipeAppUI.Core.Interfaces;

namespace RecipeAppUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IRecipeService recipeService)
        {
			InitializeComponent();
			BindingContext = new RecipeViewModel(recipeService);
		}
    }

}
