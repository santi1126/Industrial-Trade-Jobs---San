using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace San
{
    public partial class AddWorkers : ContentPage
    {
        private List<string> selectedSkills = new List<string>();

        public AddWorkers()
        {
            InitializeComponent();
        }

        // ✅ Navigate back to Admin Menu
        private async void OnMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMenuPage());
        }

        private void OnReportsClicked(object sender, EventArgs e)
        {
            // Future: Navigate to reports page
        }

        private void OnAccountsClicked(object sender, EventArgs e)
        {
            // Future: Navigate to accounts page
        }

        private void OnSetAvatarClicked(object sender, EventArgs e)
        {
            // Future: File picker logic for avatar selection
        }

        // ✅ Generate a visible password
        private void OnGeneratePasswordClicked(object sender, EventArgs e)
        {
            string generatedPassword = "Temp1234"; // Example
            passwordEntry.Text = generatedPassword;

            // Make sure password is visible
            passwordEntry.IsPassword = false;
        }

        private void OnAddSkillClicked(object sender, EventArgs e)
        {
            string skill = skillEntry.Text;

            if (!string.IsNullOrWhiteSpace(skill))
            {
                selectedSkills.Add(skill);
                selectedSkillsCollection.ItemsSource = null;
                selectedSkillsCollection.ItemsSource = selectedSkills;
                skillEntry.Text = string.Empty;
            }
        }

        private void OnRemoveSkillClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string skill)
            {
                selectedSkills.Remove(skill);
                selectedSkillsCollection.ItemsSource = null;
                selectedSkillsCollection.ItemsSource = selectedSkills;
            }
        }

        // ✅ Cancel button returns to AdminMenu
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMenuPage());
        }

        // ✅ Simulated create with loading overlay
        private async void OnCreateClicked(object sender, EventArgs e)
        {
            loadingOverlay.IsVisible = true;
            await Task.Delay(2000);
            loadingOverlay.IsVisible = false;

            await DisplayAlert("Success", "Worker created successfully!", "OK");
        }
    }
}
