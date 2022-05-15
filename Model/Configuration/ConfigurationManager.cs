using DataSourceSimulator.Model;
using System;

namespace DataSourceSimulator
{

    public class ConfigurationManager
    {

        #region Singleton Pattern Setup
        private static ConfigurationManager instance = null;
        public static ConfigurationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationManager();
                }
                return instance;
            }
        }

        private ConfigurationManager()
        {
            ReceiverMangaer = new ReceiverMangaer();
            UpdateSetteings("127.0.0.1", 2011, 50, 1024, "Sequential");
        }
        #endregion

        #region Propereties

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; NotifyOnchane(); }
        }

        private int lestinPort;
        public int LestiningPort
        {
            get { return lestinPort; }
            set { lestinPort = value; }
        } 

        private int SizeOfPack;
        public int SizeOfPacket
        {
            get { return SizeOfPack; }
            private set { SizeOfPack = value; }
        }

        private int NumOfPackPerSec;
        public int NumberOfPacketsPerSec
        {
            get { return NumOfPackPerSec; }
            private set { NumOfPackPerSec = value; NotifyOnchane(); }
        }

        public ReceiverMangaer ReceiverMangaer { get; private set; }


        #endregion

        #region Events
        public event EventHandler SettingsGotUpdated;
        #endregion

        #region Methods
        public void UpdateSetteings(string iPAddress, int port, int numberOfPacketsPerSec, int sizeOfPacket, string modeOfConn)
        {
   
            this.NumberOfPacketsPerSec = numberOfPacketsPerSec;
            this.SizeOfPacket = sizeOfPacket;

            SettingsGotUpdated?.Invoke(new object(), new EventArgs());
        }
        public void UpdateSetteings(int numberOfPacketsPerSec, int sizeOfPacket, string modeOfConn)
        {

        }
        public void UpdateSetteings(int numberOfPacketsPerSec, int sizeOfPacket)
        {
        }

        private void NotifyOnchane()
        {
            SettingsGotUpdated?.Invoke(new object(), new EventArgs());
        }
        #endregion
        
    }


}