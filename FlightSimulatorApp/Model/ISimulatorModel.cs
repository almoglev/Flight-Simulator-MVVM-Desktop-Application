using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Model
{
    public interface ISimulatorModel : INotifyPropertyChanged
    {
        // Connection to the simulator.
        void Connect(string ip, string port);
        void Disconnect();
        void Start();

        // Sensors properties.
        string Heading { set; get; }
        string VerticalSpeed { set; get; }
        string GroundSpeed { set; get; }
        string AirSpeed { set; get; }
        string GPSAltitude { set; get; }
        string Roll { set; get; }
        string Pitch { set; get; }
        string Altitude { set; get; }
        string Latitude { set; get; }
        string Longtitude { set; get; }
        string Location { set; get; }
        string WrongLocation { set; get; }
        string ConnectionStatus { set; get; }


        // Activate actuators.
        void SetJoystickSliders();
        void MoveRudder(double rudder);
        void MoveElevator(double elevator);
        void MoveAileron(double aileron);
        void MoveThrottle(double throttle);
    }
}
