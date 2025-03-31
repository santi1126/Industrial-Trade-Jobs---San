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
                ShowAlert("Error", "All fields are required!");
                return;
            }

            // Validate email format using regex
            if (!IsValidEmail(email))
            {
                ShowAlert("Error", "Enter a valid email address!");
                return;
            }

            // Validate password strength
            if (password.Length < 6)
            {
                ShowAlert("Error", "Password must be at least 6 characters long!");
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                ShowAlert("Error", "Passwords do not match!");
                return;
            }

            // Store credentials securely (DO NOT store passwords in plain text in production)
            Preferences.Set("userEmail", email);
            Preferences.Set("userPassword", password);

            // Show success message
            ShowAlert("Success", "Account created successfully!");

            // Navigate to Login Page
            await Navigation.PushAsync(new LoginPage());
        }

        // Show Custom Alert with message
        private void ShowAlert(string title, string message)
        {
            AlertMessageLabel.Text = $"{title}: {message}";
            AlertFrame.IsVisible = true;
        }

        // Handle OK button click on the custom alert
        private void OnAlertOkClicked(object sender, EventArgs e)
        {
            AlertFrame.IsVisible = false;
        }

        // Email validation function
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
