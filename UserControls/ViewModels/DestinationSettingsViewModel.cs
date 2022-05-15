using DataSourceSimulator.Model;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace DataSourceSimulator.UserControls.ViewModels
{
    public class DestinationSettingsViewModel:ViewModel
    {

        #region Propereties
        ReceiverMangaer ReceiverMangaer; 
        #endregion

        #region Binding Propereties
        private ObservableCollection<DestinationInfoViewModel> destinationInfoViewModels;

        public ObservableCollection<DestinationInfoViewModel> DestinationInfoViewModels
        {
            get { return destinationInfoViewModels; }
            set { destinationInfoViewModels = value; }
        }

        #endregion

        #region Constructors
        public DestinationSettingsViewModel()
        {
            ReceiverMangaer = ConfigurationManager.Instance.ReceiverMangaer;

            DestinationInfoViewModels = new ObservableCollection<DestinationInfoViewModel>() { new DestinationInfoViewModel(1) };
        }
        #endregion

        #region Commands
        public ICommand SaveDestinationsInfoCommand
        {
            get
            {
                return new ActionCommand(p => SaveButtonMethod());
            }
        }

        public ICommand AddDestinationCommand
        {
            get
            {
                return new ActionCommand(p => AddButtonMethod(),p => AddButtonCanExecute());
            }
        }

        public ICommand ResetCommand
        {
            get
            {
                return new ActionCommand(p => ResetButtonMethod(), p => ResetButtonCanExecute());
            }
        }

        #endregion

        #region Buttons Methods
        private void SaveButtonMethod()
        {
            foreach(var desVM in DestinationInfoViewModels)
            {
                ReceiverMangaer.addReciever(new Receiver(desVM.IP,desVM.portNum));
            }
        }

        private void AddButtonMethod()
        {
            DestinationInfoViewModels.Add(new DestinationInfoViewModel(DestinationInfoViewModels.Count+1));
        }

        private bool AddButtonCanExecute()
        {
            return destinationInfoViewModels.Count < 5;
        }
        
        private void ResetButtonMethod()
        {
            //TO-Do: reset the model
        }

        private bool ResetButtonCanExecute()
        {
            return true;
        }

        #endregion

    }
}
