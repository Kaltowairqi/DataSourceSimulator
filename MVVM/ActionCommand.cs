using System;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVM
{
	public class ActionCommand : ICommand
    {
        private readonly Action<Object> action;
        private readonly Predicate<Object> predicate;
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public ActionCommand(Action<Object> action) : this(action, null)
        {

        }

        public ActionCommand(Action<Object> action, Predicate<Object> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action", "You must specify an Action<T>");
            }

            this.action = action;
            this.predicate = predicate;
        }

        public bool CanExecute(object parameter)
        {
            if (predicate == null)
            {
                return true;
            }

            return predicate(parameter);
        }


        public void Execute(object parameter)
        {
            action(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }
    }

    public class ActionCommand<T> : ICommand where T : class
    {
        public event EventHandler CanExecuteChanged;
		private Action<T> _action;
        private Func<T, bool> canExecute;

        public ActionCommand(Action<T> action)
        {
            _action = action;
        }
        
        public ActionCommand(Action<T> action, INotifyPropertyChanged propertyChanged, Func<T, bool> _canExecute)
        {
            this._action = action;
            this.canExecute = _canExecute;

            if (this.canExecute != null)
            {
                propertyChanged.PropertyChanged += (s, a) => { OnCanExecuteChanged(); };
            }
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }

            return this.canExecute.Invoke(parameter as T);
        }

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                var castParameter = (T)Convert.ChangeType(parameter, typeof(T));
                _action(castParameter);
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}