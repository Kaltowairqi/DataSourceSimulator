using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceSimulator.Model
{
    /// <summary>
    /// Hold and maneges the receiver(e.g., perform add, delete, lookup on receievers list, turn on/off)   
    /// </summary>
    public class ReceiverMangaer
    {

        #region Propereties
        
        private HashSet<Receiver> Receivers { get; set; }

        private NetworkManager NetworkManager { get; set; }

        #endregion


        #region Constructors

        public ReceiverMangaer()
        {
            ReceiverEqualityComparer comparer = new ReceiverEqualityComparer();
            Receivers = new HashSet<Receiver>(comparer);

            NetworkManager = new NetworkManager(this, 3500);
        }
        
        #endregion


        #region Mehtods

        public bool addReciever(Receiver receiver)
        {
            return Receivers.Add(receiver);
        }


        public bool deleteReceiver(IPAddress ip)
        {
            Receiver receiver = new Receiver(ip, 3000, 5000);
            
            return Receivers.Remove(receiver);
        }


        public bool deleteReceiver(Receiver receiver)
        {
            return Receivers.Remove(receiver);
        }

        private void onReceiverArrivel(object sender, ReceiverEventArgs evntargs)
        {

        }


        #endregion

    }
}
