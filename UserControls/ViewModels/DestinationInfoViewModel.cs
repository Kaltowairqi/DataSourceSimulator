using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceSimulator.UserControls.ViewModels
{
    public class DestinationInfoViewModel:ViewModel
    {

        #region Propereties
        #endregion

        #region Binding Propereties

        public IPAddress IP;
        private string IpAddress;
        public string IPAddress
        {
            get { return IP?.ToString(); }
            set
            {
                if (isIpValid(value))
                {
                    IpAddress = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private int port;
        public string Port
        {
            get { return port.ToString(); }
            set
            {
                if (isPortValid(value))
                {
                    port = Convert.ToInt32(value); NotifyPropertyChanged();
                }
            }
        }
        public int portNum
        {
            get { return port; }
        }


        private int order;
        public int ViewModelOrder
        {
            get { return order; }
            set { order = value; NotifyPropertyChanged(); }
        }

        #endregion

        #region Constructors
        public DestinationInfoViewModel()
        {

        }

        public DestinationInfoViewModel(int viewModelOrder)
        {
            ViewModelOrder = viewModelOrder;
        }

        #endregion

        #region Mehods
        protected override string OnValidate(string propertyName)
        {
            if (propertyName == "IPAddress")
            {
                if (!System.Net.IPAddress.TryParse(IPAddress, out IP))
                {
                    return "Please, enter an appropriate IP Adress";
                }
            }

            if (propertyName == "Port")
            {
                if (Convert.ToInt32(Port) < 1024 || Convert.ToInt32(Port) > 64999)
                {
                    return "Please, enter an appropriate port number";
                }
            }

            return null;
        }

        private bool isIpValid(string IpValue)
        {
            if (System.Net.IPAddress.TryParse(IpValue, out this.IP))
            {
                return true;
            }

            return false;
        }

        private bool isPortValid(string portNum)
        {
            return int.TryParse(portNum, out _);
        }
        #endregion

    }
}
