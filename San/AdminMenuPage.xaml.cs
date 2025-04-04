using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;

namespace San;

public partial class AdminMenuPage : ContentPage
{
    public AdminMenuPage()
    {
        InitializeComponent();
    }

    private async void OnWorkerReportsTapped(object sender, EventArgs e)
    {
     
    }

    private async void OnListsOfAccountsTapped(object sender, EventArgs e)
    {
        
    }

    private async void OnAddAccountsTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddWorkers());
    }

    private async void OnJobStatusTapped(object sender, EventArgs e)
    {
        
    }

    private async void OnWorkHistoryTapped(object sender, EventArgs e)
    {
       
    }

    private async void OnReviewsTapped(object sender, EventArgs e)
    {
        
    }
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchTerm = SearchEntry.Text?.ToLower() ?? string.Empty;

        // Loop through each child in the grid of tiles
        foreach (var child in TileContainer.Children)
        {
            if (child is Frame frame)
            {
                // Find the VerticalStackLayout inside the Frame
                var verticalStackLayout = frame.Content as VerticalStackLayout;

                // Check if the VerticalStackLayout contains a Label
                var label = verticalStackLayout?.Children.OfType<Label>().FirstOrDefault();

                if (label != null && label.Text.ToLower().Contains(searchTerm))
                {
                    frame.IsVisible = true; // Show if text matches
                }
                else
                {
                    frame.IsVisible = false; // Hide if text doesn't match
                }
            }
        }
    }

}
