using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.ViewModel
{
    public class ConnectVM : INotifyPropertyChanged
    {
        public ISimulatorModel model;
        public string port;
        public string ip;
        public string connectionStatus;

        public event PropertyChangedEventHandler PropertyChanged;

        // Ctor.
        public ConnectVM(ISimulatorModel newModel)
        {
            this.model = newModel;

            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        // Notify the coresponding view model when a property changed.
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        // Sensors properties.
        public string VM_IP
        {
            get { return ip; }
            set
            {
                ip = value;
            }
        }

        public string VM_Port
        {
            get { return port; }
            set
            {
                port = value;
            }
        }

        public string VM_ConnectionStatus
        {
            get { return model.ConnectionStatus; }
        }

        // Connect to the simulator via the model.
        public void Connect()
        {
            this.model.Connect(this.ip, this.port);
        }

        // Disonnect from the simulator via the model.
        public void Disconnect()
        {
            this.model.Disconnect();
        }
    }
}
