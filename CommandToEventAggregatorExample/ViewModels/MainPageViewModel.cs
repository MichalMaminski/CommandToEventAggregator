using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using CommandToEventAggregator.EntityClasses;
using EventWithCommandAggergator.Commands;

namespace EventWithCommandAggergator.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public CommandBase _mouseEnterCommand;

        public CommandBase MouseEnterCommand
        {
            get { return _mouseEnterCommand; }
            set { _mouseEnterCommand = value; }
        }

        public MainPageViewModel()
        {
            _mouseEnterCommand = new CommandBase(Execute, CanExecute);

        }

        private bool CanExecute()
        {
            return true;
        }

        private void Execute(object o)
        {
            if (o is SenderRoutedEventArgsWrapper)
            {
                var senderWithArgs = o as SenderRoutedEventArgsWrapper;
                var textBox = senderWithArgs.Sender as TextBox;
                if (textBox != null) textBox.Text += "new text ";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
