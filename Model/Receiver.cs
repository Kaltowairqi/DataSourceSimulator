using System;
using System.Net;
using System.Net.Sockets;

namespace DataSourceSimulator.Model
{
    /// <summary>
    /// Encapsulate data for remote destination and opereation on it 
    /// </summary>
    public class Receiver
    {

        #region Properties

        public IPAddress IP { get; private set; }

        private UdpClient UdpSocket { get; set; }

        public int LocalPort { get; private set; }

        private int DestinationPort { get; set; }

        public bool sendingStatues  { get; private set; }

        public bool receiveingStatues { get; private set; }

        public RandomDate Random { get; set; }

        #endregion


        #region Constuctors 

        public Receiver(IPAddress IP, int localPort, int destinationPort, UdpClient UdpSocket)
        {
            LocalPort = localPort;
            DestinationPort = destinationPort;
            this.UdpSocket = UdpSocket;
            this.IP = IP;
        }


        public Receiver(IPAddress IP, int localPort, int destinationPort)
        {
            LocalPort = localPort;
            DestinationPort = destinationPort;
            this.IP = IP;
        }


        public Receiver(IPAddress IP, int destinationPort)
        {
            DestinationPort = destinationPort;
            this.IP = IP;
        }


        #endregion

        #region Methods

        public void BeginSending()
        {
            if (sendingStatues == true)
            {
                var x = Random.GenerateByteDate();
                UdpSocket.BeginSend(x, x.Length, new AsyncCallback(BeginSendingCallBack), new object());
            }
        }

        public void BeginSendingCallBack(IAsyncResult asyncResult)
        {
            if (sendingStatues == true)
            {
                var x = Random.GenerateByteDate();
                UdpSocket.BeginSend(x, x.Length, new AsyncCallback(BeginSendingCallBack), new object());
            }
        }

        #endregion



    }
}
