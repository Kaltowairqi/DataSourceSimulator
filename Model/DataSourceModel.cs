using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceSimulator
{
    class DataSourceModel
    {
        #region Propereties
        
        private CommunicationManager networkServer { get; set; }
        private PacketManager packetManager { get; set; }
        private ConfigurationManager configurationManager { get; set; }

        #endregion

        #region Constructors
        public DataSourceModel()
        {
            packetManager = new PacketManager();

            networkServer = new CommunicationManager(packetManager);

        }
        #endregion

        #region Mehtods
        internal void ConnectToRemoteEndPoint()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
