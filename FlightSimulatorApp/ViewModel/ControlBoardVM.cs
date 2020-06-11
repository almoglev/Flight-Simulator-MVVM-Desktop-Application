using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.ViewModel
{
    public class ControlBoardVM : INotifyPropertyChanged
    {
        private ISimulatorModel model;

        private double rudder;
        private double throttle;
        private double aileron;
        private double elevator;

        public event PropertyChangedEventHandler PropertyChanged;

        // Ctor.
        public ControlBoardVM(ISimulatorModel model)
        {
            this.model = model;
            model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
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
        public double VM_Rudder
        {
            get { return rudder; }
            set
            {
                if (rudder != value)
                {
                    rudder = value;
                    model.MoveRudder(rudder);
                }
            }
        }

        public double VM_Throttle
        {
            get { return throttle; }
            set
            {
                if (throttle != value)
                {
                    throttle = value;
                    model.MoveThrottle(throttle);
                }
            }
        }

        public double VM_Ailerron
        {
            get { return aileron; }
            set
            {
                if (aileron != value)
                {
                    aileron = value;
                    model.MoveAileron(aileron);
                }
            }
        }

        public double VM_Elevator
        {
            get { return elevator; }
            set
            {
                if (elevator != value)
                {
                    elevator = value;
                    model.MoveElevator(elevator);
                }
            }
        }
    }
}
