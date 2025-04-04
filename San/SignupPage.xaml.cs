using Microsoft.Maui.Controls;
using System;
using System.Text.RegularExpressions;

namespace San
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void OnSignupClicked(object sender, EventArgs e)
        {
            string email = emailEntry?.Text?.Trim() ?? string.Empty;
            string password = passwordEntry?.Text ?? string.Empty;
            string confirmPassword = confirmPasswordEntry?.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                await ShowAlert("Error", "All fields are required!");
                return;
            }

            if (!IsValidEmail(email))
            {
                await ShowAlert("Error", "Enter a valid email address!");
                return;
            }

            if (password.Length < 6)
            {
                await ShowAlert("Error", "Password must be at least 6 characters!");
                return;
            }

            if (password != confirmPassword)
            {
                await ShowAlert("Error", "Passwords do not match!");
                return;
            }

            // ✅ Save account to Preferences for login use
            Preferences.Set("userEmail", email);
            Preferences.Set("userPassword", password);

            await ShowAlert("Success", "Account created successfully!");

            // 🔄 Navigate to Login Page (you could auto-login instead)
            await Navigation.PushAsync(new LoginPage());
        }

        private async Task ShowAlert(string title, string message)
        {
            await DisplayAlert(title, message, "OK");
        }

        private void OnAlertOkClicked(object sender, EventArgs e) { }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
