using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSourceSimulator.UserControls.ViewModels
{
    class SourceSettingsViewModel:ViewModel
    {

        #region Propereties
        ConfigurationManager ConfigurationManager;
        #endregion

        #region Binding Propereties

        private String name;
        public String Name
        {
            get { return name; }
            set { if (isNameValid(value)){ name = value; NotifyPropertyChanged(); } }
        }


        private int port;
        public string Port
        {
            get { return port.ToString(); }
            set
            {
                if (isPortValid(value))
                {
                    port = Convert.ToInt32(value); NotifyPropertyChanged();
                }
            }
        }
        
        #endregion

        #region Constructors
        public SourceSettingsViewModel()
        {
            ConfigurationManager = ConfigurationManager.Instance;
        }
        #endregion

        #region Commands

        public ICommand SaveSourceSettings
        {
            get { return new ActionCommand(p => SaveSourceSettingsMethods()); }
        }

        #endregion

        #region methods
        protected override string OnValidate(string propertyName)
        {
            if (propertyName == "Name")
            {
                if (isNameValid(this.Name))
                {
                    return "Please, enter an appropriate name";
                }
            }

            if (propertyName == "Port")
            {
                var port = Convert.ToInt32(Port);

                if (port < 1024 || port > 64999)
                {
                    return "Please, enter an appropriate port number";
                }
            }

            return null;
        }

        private bool isPortValid(string portNum)
        {
            return int.TryParse(portNum, out _);
        }

        private bool isNameValid(string name)
        {
            return name.Length < 25;
        }
        #endregion

        #region Buttons Methods
        private void SaveSourceSettingsMethods()
        {
            ConfigurationManager.Name = Name;
            ConfigurationManager.LestiningPort = port;
        }
        #endregion

    }

}
