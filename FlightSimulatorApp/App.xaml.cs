using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FlightSimulatorApp.Model;
using FlightSimulatorApp.ViewModel;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ConnectVM ConnectVM { get; internal set; }
        public DashboardVM DashboardVM { get; internal set; }
        public ControlBoardVM ControlBoardVM { get; internal set; }
        public MapVM MapVM { get; internal set; }


        // Initializing the simulator model and all the view models.
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ISimulatorModel simulatorModel = new SimulatorModel(new MyTelnetClient());
            ConnectVM = new ConnectVM(simulatorModel);
            DashboardVM = new DashboardVM(simulatorModel);
            ControlBoardVM = new ControlBoardVM(simulatorModel);
            MapVM = new MapVM(simulatorModel);
        }
    }
}
