using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkeyFinder.ViewModel
{
    public class CommandDemoViewModel : INotifyPropertyChanged
    {
        double number = 1;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand MultiplyBy2Command { get; private set; }
        public ICommand DivideBy2Command { get; private set; }

        public CommandDemoViewModel()
        {
            MultiplyBy2Command = new Command(
                execute: () =>
                {
                    Number *= 2;
                    RefreshCanExecute();
                },
                canExecute: () => Number < Math.Pow(2, 10)

            );

            DivideBy2Command = new Command(
                execute: () =>
                {
                    Number /= 2;
                    RefreshCanExecute();
                },
                canExecute: () => Number > Math.Pow(2, -10)
            );
        }

        void RefreshCanExecute()
        {
            ((Command)MultiplyBy2Command).ChangeCanExecute();
            ((Command)DivideBy2Command).ChangeCanExecute();
        }

        public double Number
        {
            get
            {
                return number;
            }
            set
            {
                if (number != value)
                {
                    number = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number)));
                }
            }
        }

    }
}
