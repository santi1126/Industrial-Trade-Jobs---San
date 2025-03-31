using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace San
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            StartAnimation();
        }

        private async void StartAnimation()
        {
            await Task.Delay(500);
            await TitleLabel.FadeTo(1, 1000);
            await SubtitleLabel.FadeTo(1, 1000);
            await DeveloperLabel.FadeTo(1, 1000);
            await Task.Delay(2000);
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}