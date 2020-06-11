using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Model
{
    public interface ITelnetClient
    {
        string Connect(string ip, string port);
        string Write(string command);
        string Read();
        string Disconnect();
    }
}
