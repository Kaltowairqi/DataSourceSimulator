
namespace MVVM
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Input;

    /// <summary>
    /// Base class for a View-Model in the MVVM pattern.
    /// </summary>
    public abstract class ViewModel : ObservableObject, IDataErrorInfo
    {
        public event EventHandler RequestClose;
        public event EventHandler RequestSendDialogResult;
        /// <summary>
        /// Gets the validation error for a property whose name matches the specified <see cref="columnName"/>.
        /// </summary>
        /// <param name="columnName">The name of the property to validate.</param>
        /// <returns>Returns a validation error if there is one, otherwise returns null.</returns>
        public string this[string columnName]
        {
            get { return OnValidate(columnName); }
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete]
        public string Error
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Validates a property whose name matches the specified <see cref="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to validate.</param>
        /// <returns>Returns a validation error, if any, otherwise returns null.</returns>
        protected virtual string OnValidate(string propertyName)
        {
            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };

            var results = new Collection<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (!isValid)
            {
                ValidationResult result = results.SingleOrDefault(p =>
                                                                  p.MemberNames.Any(memberName =>
                                                                                    memberName == propertyName));

                return result == null ? null : result.ErrorMessage;
            }

            return null;
        }

        public ICommand CloseViewCommand
        {
            get
            {
                return new ActionCommand(p => CloseView());
            }
        }


        protected void CloseView()
        {
            EventHandler handler = RequestClose;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public ICommand SendDialogResultCommand
        {
            get
            {
                return new ActionCommand(p => SendDialogResult());
            }
        }


        protected void SendDialogResult()
        {
            EventHandler handler = RequestSendDialogResult;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
