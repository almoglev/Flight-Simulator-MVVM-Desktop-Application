using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.ViewModel
{
    public class DashboardVM : INotifyPropertyChanged
    {
        private ISimulatorModel model;

        // Ctor.
        public DashboardVM(ISimulatorModel model)
        {
            this.model = model;
            model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Notify the coresponding view model when a property changed.
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        // Sensors properties.
        public string VM_Heading
        {
            get
            {
                return model.Heading;
            }
        }

        public string VM_VerticalSpeed
        {
            get
            {
                return model.VerticalSpeed;
            }
        }

        public string VM_GroundSpeed
        {
            get
            {
                return model.GroundSpeed;
            }
        }

        public string VM_AirSpeed
        {
            get
            {
                return model.AirSpeed;
            }
        }

        public string VM_GPSAltitude
        {
            get
            {
                return model.GPSAltitude;
            }
        }

        public string VM_Roll
        {
            get
            {
                return model.Roll;
            }
        }
        public string VM_Pitch
        {
            get
            {
                return model.Pitch;
            }
        }
        public string VM_Altitude
        {
            get
            {
                return model.Altitude;
            }
        }
    }
}
