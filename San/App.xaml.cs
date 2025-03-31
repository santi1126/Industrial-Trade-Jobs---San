using Microsoft.Maui.Controls;

namespace San
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SplashPage());
        }
    }
}