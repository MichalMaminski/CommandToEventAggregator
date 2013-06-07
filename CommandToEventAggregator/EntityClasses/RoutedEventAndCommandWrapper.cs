using System.Windows;
using System.Windows.Input;

namespace CommandToEventAggregator.EntityClasses
{
    public class RoutedEventAndCommandWrapper
    {
        public RoutedEvent RoutedEvent { get; set; }
        public ICommand Command { get; set; }
    }
}
