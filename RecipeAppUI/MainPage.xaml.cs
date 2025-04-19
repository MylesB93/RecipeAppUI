using RecipeAppUI.Core.Interfaces;

namespace RecipeAppUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly IRecipeService _recipeService;

        public MainPage(IRecipeService recipeService)
        {
            InitializeComponent();
            _recipeService = recipeService;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var test = await _recipeService.GetAllRecipesAsync();
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
