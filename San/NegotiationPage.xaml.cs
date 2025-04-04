using Microsoft.Maui.Controls;

namespace San
{
    public partial class NegotiationPage : ContentPage
    {
        public NegotiationPage()
        {
            InitializeComponent();
        }

        private void OnSendMessage(object sender, EventArgs e)
        {
            var messageText = MessageEntry.Text;

            if (!string.IsNullOrEmpty(messageText))
            {
                var viewModel = (NegotiationViewModel)BindingContext;
                viewModel.AddMessage($"You: {messageText}");
                MessageEntry.Text = string.Empty;
            }
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchQuery = e.NewTextValue.ToLower();
            var buttons = NegotiationList.Children.OfType<Button>().ToList();

            foreach (var button in buttons)
            {
                button.IsVisible = button.Text.ToLower().Contains(searchQuery);
            }
        }

        private void OnMessageTextChanged(object sender, TextChangedEventArgs e)
        {
            // You can add additional behavior when the user is typing (optional)
        }
    }
}
