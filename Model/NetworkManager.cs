using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DataSourceSimulator.Model
{
    class NetworkManager
    {
        #region Propereties
        UdpClient udpClient { get;  set; }

        ReceiverMangaer ReceiverMangaer { get; set; }

        IPEndPoint localEndPoint;

        #endregion

        #region Events
        public event EventHandler<ReceiverEventArgs> ReceiverArrived;

        #endregion

        #region Constructors
        public NetworkManager(ReceiverMangaer receiverMangaer ,int port)
        {
            localEndPoint = new IPEndPoint(IPAddress.Any, port);
            udpClient = new UdpClient(localEndPoint);

            ReceiverMangaer = receiverMangaer;

            udpClient.BeginReceive(new AsyncCallback(DataReceiveCallBack), udpClient);

        }

        #endregion

        private void DataReceiveCallBack(IAsyncResult async)
        {

            Task.Run(() => { 
            try
            {
                IPEndPoint remote = null;
                byte[] data = udpClient.EndReceive(async, ref remote);

                //TO-DO: date processing (check the type of the message, create the Receiver, send the Ack)
               
            }
            catch (Exception err)
            {


            }

            });

        }

        private void onReceiverArrivel(Receiver receiver)
        {
            ReceiverArrived?.Invoke(this, new ReceiverEventArgs(receiver));
        }


    }


    public class ReceiverEventArgs:EventArgs
    {
        public ReceiverEventArgs(Receiver receiver)
        {
            Receiver = receiver;
        }

        public Receiver Receiver { get; private set; }
    }



















}
