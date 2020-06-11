using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.ViewModel
{
    public class MapVM : INotifyPropertyChanged
    {
        private ISimulatorModel model;

        // Ctor.
        public MapVM(ISimulatorModel model)
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
        public string VM_Latitude
        {
            get
            {
                return model.Latitude;
            }
        }
        public string VM_Longtitude
        {
            get
            {
                return model.Longtitude;
            }
        }
        public string VM_Location
        {
            get
            {
                return model.Location;
            }
        }
        public string VM_WrongLocation
        {
            get
            {
                return model.WrongLocation;
            }
        }
    }
}
