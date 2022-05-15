using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSourceSimulator.Model;
using MVVM;



namespace DataSourceSimulator.UserControls.ViewModels
{
    class StatisticsViewModel:ViewModel
    {
        #region Propereties
        private StatisticsManager statisticsManager;
        #endregion

        #region Binding Propereties 

        private int numberOfSentPackts;
        public int NumberOfSentPackts
        {
            get { return numberOfSentPackts; }
            set { numberOfSentPackts = value; NotifyPropertyChanged(); }
        }


        private int numberOfReceivedAKCs;
        public int NumberOfReceivedAKCs
        {
            get { return numberOfReceivedAKCs; }
            set { numberOfReceivedAKCs = value; NotifyPropertyChanged(); }
        }


        private int byetsSent;
        public int ByetsSent
        {
            get { return byetsSent; }
            set { byetsSent = value; NotifyPropertyChanged(); }
        }


        private int averageOfDelay;
        public int AverageOfDelay
        {
            get { return averageOfDelay; }
            set { averageOfDelay = value; NotifyPropertyChanged(); }
        }

        #endregion

        #region Constructors
        public StatisticsViewModel()
        {
            statisticsManager =StatisticsManager.Instance;
            statisticsManager.StatisticUpdated += OnStatisticUpdated;

            NumberOfReceivedAKCs = 0;
            NumberOfSentPackts = 0;
            ByetsSent = 0;
            AverageOfDelay = 0;
        }
        #endregion

        #region Methods
        private void OnStatisticUpdated(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
