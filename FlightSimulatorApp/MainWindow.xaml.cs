using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Ctor.
        public MainWindow()
        {
            InitializeComponent();

            // Binding between the view to it's suitable view model.
            myConnect.DataContext = (Application.Current as App).ConnectVM;
            myConnect.SetConnectVM((Application.Current as App).ConnectVM);
            myControlBoard.DataContext = (Application.Current as App).ControlBoardVM;
            myControlBoard.SetControlBoardVM((Application.Current as App).ControlBoardVM);
            myDashBoard.DataContext = (Application.Current as App).DashboardVM;
            myMap.DataContext = (Application.Current as App).MapVM;
        }
    }
}
