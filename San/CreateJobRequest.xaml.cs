using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace San
{
    public partial class CreateJobRequest : ContentPage
    {
        // ObservableCollection to hold job categories
        public ObservableCollection<JobCategory> JobCategories { get; set; }

        // Nullable property to avoid CS8618 warning
        private JobCategory? _selectedJob;
        public JobCategory? SelectedJob
        {
            get => _selectedJob;
            set
            {
                _selectedJob = value;
                OnPropertyChanged(nameof(SelectedJob));
            }
        }

        public CreateJobRequest()
        {
            InitializeComponent();
            JobCategories = new ObservableCollection<JobCategory>
            {
                new JobCategory { JobTitle = "Carpentry Job", WorkerCount = "(0/1)", CustomerName = "John Doe", Skillset = "Woodworking", Location = "City Center", JobDescription = "Install wooden flooring", JobStatus = "Open" },
                new JobCategory { JobTitle = "Plumbing Job", WorkerCount = "(0/2)", CustomerName = "Jane Smith", Skillset = "Pipe Installation", Location = "Downtown", JobDescription = "Fix leaking pipes", JobStatus = "Open" },
                new JobCategory { JobTitle = "Electrical Job", WorkerCount = "(0/1)", CustomerName = "Mark Allen", Skillset = "Wiring & Circuits", Location = "West Side", JobDescription = "Repair house wiring", JobStatus = "Open" }
            };

            BindingContext = this;
        }

        // Event when a job category is selected
        private void OnJobSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is JobCategory job)
            {
                SelectedJob = job;
            }
        }

        // Event when Submit Job Request is clicked
        private async void OnSubmitJobClicked(object sender, EventArgs e)
        {
            if (SelectedJob != null)
            {
                await DisplayAlert("Job Request Submitted", $"You have requested the job: {SelectedJob.JobTitle}", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Please select a job first!", "OK");
            }
        }
    }

    // Job Category Model
    public class JobCategory
    {
        public string JobTitle { get; set; } = string.Empty;
        public string WorkerCount { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Skillset { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
        public string JobStatus { get; set; } = string.Empty;
    }
}
