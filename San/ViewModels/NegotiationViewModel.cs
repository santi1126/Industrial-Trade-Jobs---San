using System.Collections.ObjectModel;

namespace San
{
    public class NegotiationViewModel
    {
        public ObservableCollection<Message> Messages { get; set; }

        public NegotiationViewModel()
        {
            Messages = new ObservableCollection<Message>
            {
                new Message { Text = "John: Are you interested in this job?" },
                new Message { Text = "You: Yes, I am interested in this job. What is the rate?" },
                new Message { Text = "John: The rate is $20 per hour." }
            };
        }

        public void AddMessage(string text)
        {
            Messages.Add(new Message { Text = text });
        }
    }

    public class Message
    {
        public string Text { get; set; }
    }
}
