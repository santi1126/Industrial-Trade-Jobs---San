using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;

namespace San
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = emailEntry?.Text?.Trim() ?? "";
            string password = passwordEntry?.Text ?? "";

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter both email and password", "OK");
                return;
            }

            // ✅ Admin credentials
            if (email == "San" && password == "PassWord123")
            {
                await DisplayAlert("Welcome", "Logged in as Admin", "OK");
                await Navigation.PushAsync(new AdminMenuPage()); // Admin-only menu page
                return;
            }

            // ✅ Regular user credentials (from Preferences)
            string savedEmail = Preferences.Get("userEmail", string.Empty);
            string savedPassword = Preferences.Get("userPassword", string.Empty);

            if (email == savedEmail && password == savedPassword)
            {
                await DisplayAlert("Welcome", "Login successful!", "OK");
                await Navigation.PushAsync(new MenuPage()); // Redirect to your user’s main page
                return;
            }

            await DisplayAlert("Error", "Invalid email or password", "OK");
        }

        private async void NavigateToSignup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
    }
}
