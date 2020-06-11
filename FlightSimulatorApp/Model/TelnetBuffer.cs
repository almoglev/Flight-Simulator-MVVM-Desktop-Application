using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Model
{
    // Telnet Client Buffer class.
    public class TelnetBuffer
    {
        public byte[] writeBuff;
        public byte[] readBuff;
        public int usedCapacity;
    }
}
