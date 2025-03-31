using Microsoft.Maui.Controls;
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

            string storedEmail = Preferences.Get("userEmail", string.Empty);
            string storedPassword = Preferences.Get("userPassword", string.Empty);

            if (email == storedEmail && password == storedPassword)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
                await Navigation.PushAsync(new CreateJobRequest());
            }
            else
            {
                await DisplayAlert("Error", "Invalid email or password", "OK");
            }
        }

        private async void NavigateToSignup(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());
        }
    }
}
