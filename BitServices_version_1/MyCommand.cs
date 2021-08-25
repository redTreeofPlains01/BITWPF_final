using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BitServices_version_1
{
    public class MyCommand : ICommand
    {
        private Action _whatToExcecute;
        public event EventHandler CanExecuteChanged;
        private bool _canExecute;
        public MyCommand(Action what, bool canExecute)
        {
            _whatToExcecute = what;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        public void Execute(object parameter)
        {
            _whatToExcecute.Invoke(); //Invoke is a method
            //that just gives a call to the method and runs it
        }
    }
}
