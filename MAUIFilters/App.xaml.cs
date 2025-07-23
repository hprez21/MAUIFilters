using MAUIFilters.Views;

namespace MAUIFilters
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MauiFiltersView();
        }
    }
}
