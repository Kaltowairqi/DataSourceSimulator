using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using System.Windows.Input;
using System.Net;
using System.Windows;

namespace DataSourceSimulator
{
    class DataSourceViewModel:ViewModel
    {
        #region Properties
        private DataSourceModel DataSourceModel { get; set; }
        #endregion

        #region BindingsProps
        private InformationViewModel informationViewModel;

        public InformationViewModel InfoVM
        {
            get { return informationViewModel; }
            set { informationViewModel = value; NotifyPropertyChanged(); }
        }


        #endregion

        #region Commands
        public ICommand ConnectButton
        {
            get
            {
                return new ActionCommand(p => ConnectButtonMethod());
            }
        }


        public ICommand OpenSettingsButton
        {
            get
            {
                return new ActionCommand(p => OpenSettingsButtonMethod());
            }
        }
        #endregion

        #region Constructors
        public DataSourceViewModel()
        {
            InfoVM = new InformationViewModel();
        }
        #endregion

        #region Methods
        protected override string OnValidate(string propertyName)
        {
            if (propertyName == "IPAddress")
            {
              
            }

            if (propertyName == "Port")
            {
                
            }

            return "";
        }
        #endregion

        #region Buttons Methods
        private void ConnectButtonMethod()
        {
            DataSourceModel.ConnectToRemoteEndPoint();
        }

        private void OpenSettingsButtonMethod()
        {
            SettingsView settingsView = new SettingsView();
            settingsView.ShowDialog();

        }

        #endregion

        #region EventHandlers

        #endregion

    }
}
