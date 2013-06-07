using System.Windows;
using CommandToEventAggregator.EntityClasses;

namespace CommandToEventAggregator
{
    public class CommandToEventAggergator
    {
        public static readonly DependencyProperty CommandToEventProperty =
                DependencyProperty.RegisterAttached("CommandToEventProperty", typeof(RoutedEventAndCommandWrapper), typeof(CommandToEventAggergator), new PropertyMetadata(null, EventPropertyChangedCallback));

        private static void EventPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (dependencyObject is UIElement)
            {
                var sender = dependencyObject as UIElement;

                if (dependencyPropertyChangedEventArgs.OldValue != null)
                {
                    if (dependencyPropertyChangedEventArgs.OldValue is RoutedEventAndCommandWrapper)
                    {
                        var routedProperty = (dependencyPropertyChangedEventArgs.OldValue as RoutedEventAndCommandWrapper).RoutedEvent;
                        sender.RemoveHandler(routedProperty, new RoutedEventHandler(RaiseCommand));
                    }
                }
                if (dependencyPropertyChangedEventArgs.NewValue != null)
                {
                    if (dependencyPropertyChangedEventArgs.NewValue is RoutedEventAndCommandWrapper)
                    {
                        var routedProperty = (dependencyPropertyChangedEventArgs.NewValue as RoutedEventAndCommandWrapper).RoutedEvent;
                        sender.AddHandler(routedProperty, new RoutedEventHandler(RaiseCommand));
                    }
                }

            }
        }

        private static void RaiseCommand(object sender, RoutedEventArgs routedEventArgs)
        {
            if (sender is DependencyObject)
            {
                var commandProperty = (sender as DependencyObject).GetValue(CommandToEventProperty) as RoutedEventAndCommandWrapper;
                if (commandProperty == null) return;

                var senderEventArgsWrapper = new SenderRoutedEventArgsWrapper()
                                                 {
                                                     Sender = sender,
                                                     EventArgs = routedEventArgs
                                                 };

                if (commandProperty.Command.CanExecute(senderEventArgsWrapper))
                {
                    commandProperty.Command.Execute(senderEventArgsWrapper);
                }
            }
        }

        public static void SetCommandToEventProperty(DependencyObject dependencyObject, RoutedEventAndCommandWrapper commandToEvent)
        {
            dependencyObject.SetValue(CommandToEventProperty, commandToEvent);
        }

        public static RoutedEventAndCommandWrapper GetCommandToEventProperty(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(CommandToEventProperty) as RoutedEventAndCommandWrapper;
        }
    }
}
