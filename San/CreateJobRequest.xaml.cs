using Microsoft.Maui.Controls;

namespace San
{
    public partial class CreateJobRequest : ContentPage
    {
        // Constructor that accepts parameters to pre-fill job details
        public CreateJobRequest(string jobName, string description, string currency, string rate, string timePeriod, string skillset, string location)
        {
            InitializeComponent();

            JobDescriptionEntry.Text = description;
            CurrencyPicker.SelectedItem = currency;
            RateEntry.Text = rate;
            TimePeriodPicker.SelectedItem = timePeriod;
            SkillsetPicker.SelectedItem = skillset;
            LocationEntry.Text = location;
        }

        // Event handler for Publish button
        private async void OnPublishClicked(object sender, EventArgs e)
        {
            // You would typically save the data here (e.g., to a database or file)

            string description = JobDescriptionEntry.Text;
            string currency = CurrencyPicker.SelectedItem.ToString();
            string rate = RateEntry.Text;
            string timePeriod = TimePeriodPicker.SelectedItem.ToString();
            string skillset = SkillsetPicker.SelectedItem.ToString();
            string location = LocationEntry.Text;

            // Navigate back to the PublishedJobRequest page
            await Navigation.PopAsync(); // Go back to the PublishedJobRequest page
        }

        // Event handler for Cancel button
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            // Reset the form fields if needed, or just navigate away
            await Navigation.PopAsync(); // Go back to the PublishedJobRequest page without saving
        }
    }
}
