using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace San
{
    public partial class WorkerApplicants : ContentPage
    {
        public ObservableCollection<Applicant> ApplicantsList { get; set; }

        public WorkerApplicants()
        {
            InitializeComponent();

            // Initialize the applicants list
            ApplicantsList = new ObservableCollection<Applicant>
            {
                new Applicant
                {
                    Skillset = "Cement Specialist",
                    Name = "John Michael Satintigan",
                    Initial = "J",
                    Rate = "₱152.00 per hour",
                    Status = "Approve"
                },
                new Applicant
                {
                    Skillset = "Landscape Artist",
                    Name = "Luke Daniel Bacus",
                    Initial = "L",
                    Rate = "₱132.00 per hour",
                    Status = "Approve"
                },
                new Applicant
                {
                    Skillset = "General Carpentry",
                    Name = "Mark Lee Chou",
                    Initial = "M",
                    Rate = "₱132.00 per hour",
                    Status = "Approve"
                }
            };

            // Set the binding context
            this.BindingContext = this;
        }

        // Event handler for job selection
        private void OnJobSelected(object sender, CheckedChangedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.IsChecked)
            {
                string jobTitle = ((Label)((HorizontalStackLayout)radioButton.Content).Children[0]).Text;
                // Update the header title based on selected job
                UpdateHeaderTitle(jobTitle);
            }
        }

        // Event handler for back button
        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Navigate back or perform any necessary action
            Navigation.PopAsync();
        }

        // Event handler for approve button
        private void OnApproveClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Applicant applicant)
            {
                // Handle approval logic here
                DisplayAlert("Approval", $"{applicant.Name} has been approved!", "OK");
            }
        }

        // Event handler for details button
        private void OnDetailsClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Applicant applicant)
            {
                // Navigate to details page or show details popup
                DisplayAlert("Details", $"Viewing details for {applicant.Name}", "OK");
            }
        }

        // Update the header title based on selected job
        private void UpdateHeaderTitle(string jobTitle)
        {
            string count = "0/1"; // Default value

            switch (jobTitle)
            {
                case "Cleaning Job":
                    count = "0/2";
                    break;
                case "Interior Design Job":
                    count = "0/1";
                    break;
                default:
                    count = "0/1";
                    break;
            }

            // Update the header label
            // You would need to add x:Name to your header label in XAML to reference it here
        }

        // Event handler for add button
        private void OnAddJobClicked(object sender, EventArgs e)
        {
            // Navigate to add job page or show add job popup
            DisplayAlert("Add Job", "Feature to add a new job would open here", "OK");
        }
    }

    // Applicant model class
    public class Applicant
    {
        public string Skillset { get; set; }
        public string Name { get; set; }
        public string Initial { get; set; }
        public string Rate { get; set; }
        public string Status { get; set; }
    }
}