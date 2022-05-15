using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceSimulator
{
    class InformationViewModel:ViewModel
    {

        #region Propereties 
        ConfigurationManager ConfigurationManager;

        //TO-DO: Create a networkServer instance and use event StatuesChanged
        #endregion

        #region Binding Propereties
        private string sourceName;
        public string SourceName
        {
            get { return sourceName; }
            set
            {
                    sourceName = value;
                    NotifyPropertyChanged();
            }
        }


        private String lestinPort;
        public String LestiningPort
        {
            get { return lestinPort; }
            set { lestinPort = value; NotifyPropertyChanged(); }
        }


        private String statues;
        public String Statues
        {
            get { return statues; }
            set { statues = value; }
        }


        #endregion

        #region Constructors

        public InformationViewModel()
        {
            ConfigurationManager = ConfigurationManager.Instance;
            ConfigurationManager.SettingsGotUpdated += onSettingsChange;

            SourceName = "";

        }

        #endregion

        #region Methods

        private void onSettingsChange(object sender, EventArgs e)
        {
            
            SourceName = ConfigurationManager.Name;
            LestiningPort = ConfigurationManager.LestiningPort.ToString();

        }
        
        #endregion

    }
}
