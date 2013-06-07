using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using CommandToEventAggregator.EntityClasses;

namespace EventWithCommandAggergator.Converters
{
    public class EventCommandToEventCommandWrapperConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var eventCommandWrapper = new RoutedEventAndCommandWrapper();

            foreach (var value in values)
            {
                if (value is RoutedEvent)
                {
                    eventCommandWrapper.RoutedEvent = value as RoutedEvent;
                }
                else if (value is ICommand)
                {
                    eventCommandWrapper.Command = value as ICommand;
                }
            }

            return eventCommandWrapper;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
