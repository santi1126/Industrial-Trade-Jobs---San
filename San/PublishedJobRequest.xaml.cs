using Microsoft.Maui.Controls;

namespace San
{
    public partial class PublishedJobRequest : ContentPage
    {
        public PublishedJobRequest()
        {
            InitializeComponent();
        }

        // Event handler for the Edit button
        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            // Replace the hardcoded data with the actual job request details
            string jobName = "Carpentry Job";  // Replace with dynamic data
            string description = "Build a new wooden shelf.";  // Replace with dynamic data
            string currency = "USD ($)";  // Replace with dynamic data
            string rate = "15";  // Replace with dynamic data
            string timePeriod = "Per Hour";  // Replace with dynamic data
            string skillset = "Carpentry";  // Replace with dynamic data
            string location = "Downtown";  // Replace with dynamic data

            // Navigate to the CreateJobRequest page and pass the job details to the new page
            await Navigation.PushAsync(new CreateJobRequest(jobName, description, currency, rate, timePeriod, skillset, location));
        }

        // Event handler for the Delete button (optional)
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            // Implement delete logic here
            DisplayAlert("Delete", "Job Request Deleted!", "OK");
        }
    }
}
