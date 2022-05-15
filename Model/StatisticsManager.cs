using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceSimulator.Model
{
    class StatisticsManager
    {

        #region Singelton Patteren Setup

        private static StatisticsManager instance = null;
        public static StatisticsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StatisticsManager();
                }
                return instance;
            }
        }

        private StatisticsManager()
        {

        }

        #endregion

        #region Propereties

        public int NumberOfSentPackets { get; private set; }

        public int ByetsSent { get; private set; }

        public int NumberOfReceivedAcks { get; private set; }

        public int AverageOfDelay { get; private set; }

        #endregion

        #region Events

        public event EventHandler StatisticUpdated;

        #endregion

        #region Methods

        #endregion

    }
}
