using RecipeAppUI.Views;

namespace RecipeAppUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

			Routing.RegisterRoute("Instructions", typeof(Instructions));
		}
    }
}
