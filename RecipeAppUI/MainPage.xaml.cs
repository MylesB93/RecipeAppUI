using RecipeAppUI.Core.Interfaces;

namespace RecipeAppUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IRecipeService _recipeService;

        public MainPage(IRecipeService recipeService)
        {
			InitializeComponent();
			BindingContext = new MainViewModel(recipeService);
		}
    }

}
