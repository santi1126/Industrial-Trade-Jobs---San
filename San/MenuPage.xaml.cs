using Microsoft.Maui.Controls;
using System;

namespace San
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void OnJobClicked(object sender, EventArgs e)
        {
            // Get the button that was clicked
            if (sender is Button button)
            {
                // Get the parent grid to access job details
                if (button.Parent is Grid grid && grid.Parent is Grid parentGrid)
                {
                    // Find the job title from the grid
                    var titleGrid = parentGrid.Children.FirstOrDefault(c => c is Grid && ((Grid)c).Children.Any(label => label is Label)) as Grid;
                    var titleLabel = titleGrid?.Children.FirstOrDefault(c => c is Label) as Label;
                    string jobTitle = titleLabel?.Text ?? "Job";

                    await DisplayAlert("Job Selected", $"You selected {jobTitle}", "OK");

                    // Here you would navigate to a job details page
                    // await Navigation.PushAsync(new JobDetailsPage(jobTitle));
                }
            }
        }

        private async void OnCategoryTabClicked(object sender, EventArgs e)
        {
            if (sender is Label categoryLabel)
            {
                string category = categoryLabel.Text;
                // Here you would reload jobs based on the selected category
                await DisplayAlert("Category Selected", $"Switching to {category} jobs", "OK");
            }
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            // Navigate to home or refresh current page if this is home
            await DisplayAlert("Navigation", "Home Selected", "OK");
        }

        private async void OnBrowseClicked(object sender, EventArgs e)
        {
            // Navigate to browse page
            await DisplayAlert("Navigation", "Browse Selected", "OK");
        }

        private async void OnHistoryClicked(object sender, EventArgs e)
        {
            // Navigate to history page
            await DisplayAlert("Navigation", "History Selected", "OK");
        }

        private async void OnProfileClicked(object sender, EventArgs e)
        {
            // Navigate to profile page
            await DisplayAlert("Navigation", "Profile Selected", "OK");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // You could load job data here when the page appears
        }
    }
}