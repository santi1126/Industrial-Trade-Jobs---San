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
            // Retrieve user input safely
            string email = emailEntry?.Text?.Trim() ?? string.Empty;
            string password = passwordEntry?.Text ?? string.Empty;
            string confirmPassword = confirmPasswordEntry?.Text ?? string.Empty;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                await DisplayAlert("Error", "All fields are required!", "OK");
                return;
            }

            // Validate email format using regex
            if (!IsValidEmail(email))
            {
                await DisplayAlert("Error", "Enter a valid email address!", "OK");
                return;
            }

            // Validate password strength
            if (password.Length < 6)
            {
                await DisplayAlert("Error", "Password must be at least 6 characters long!", "OK");
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match!", "OK");
                return;
            }

            // Store credentials securely (DO NOT store passwords in plain text in production)
            Preferences.Set("userEmail", email);
            Preferences.Set("userPassword", password);

            // Show success message
            await DisplayAlert("Success", "Account created successfully!", "OK");

            // Navigate to Login Page
            await Navigation.PushAsync(new LoginPage());
        }

        // Email validation function
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
