using MVVM;
using System;
using System.Net;
using System.Windows.Input;

namespace DataSourceSimulator.UserControls.ViewModels
{
    public class ConfigurationViewModel:ViewModel
    {
        #region Propereties 
        ConfigurationManager ConfigurationManager;
        #endregion

        #region Binding Propereties
        private int SizeOfPack;
        public int SizeOfPacket
        {
            get { return SizeOfPack; }
            set { SizeOfPack = value; }
        }

        private int NumOfPackPerSec;
        public int NumberOfPacketsPerSec
        {
            get { return NumOfPackPerSec; }
            set { NumOfPackPerSec = value; }
        }
        #endregion

        #region Commands
        public ICommand SaveButton
        {
            get
            {
                return new ActionCommand(p => SaveButtonMethod());
            }
        }
        #endregion

        #region Constructors
        public ConfigurationViewModel()
        {
            ConfigurationManager = ConfigurationManager.Instance;
        }
        #endregion

        #region Buttons Methods
        private void SaveButtonMethod()
        {
            ConfigurationManager.UpdateSetteings(NumberOfPacketsPerSec, SizeOfPacket);
        }
        #endregion

    }
}
