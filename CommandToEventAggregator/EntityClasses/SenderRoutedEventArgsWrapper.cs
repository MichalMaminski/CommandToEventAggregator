using System.Windows;

namespace CommandToEventAggregator.EntityClasses
{
    public class SenderRoutedEventArgsWrapper
    {
        public object Sender { get; set; }
        public RoutedEventArgs EventArgs
        {
            get;
            set;
        }
    }
}
