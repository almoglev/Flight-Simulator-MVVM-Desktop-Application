using System;
using System.Collections.Generic;
using System.Configuration;
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
using FlightSimulatorApp.ViewModel;

namespace FlightSimulatorApp.View
{
    /// <summary>
    /// Interaction logic for Connect.xaml
    /// </summary>
    public partial class Connect : UserControl
    {
        public static ConnectVM connectVM;

        // Ctor.
        public Connect()
        {
            InitializeComponent();

            IPTextBox.Text = ConfigurationManager.AppSettings.Get("ip");
            portTextBox.Text = ConfigurationManager.AppSettings.Get("port");
            disconnectB.IsEnabled = false;
        }

        // Setting the connect view model.
        public void SetConnectVM(ConnectVM newConnectVM)
        {
            connectVM = newConnectVM;
        }

        // The function behind the connect button.
        private void ConnectB_Click(object sender, RoutedEventArgs e)
        {
            connectVM.VM_Port = portTextBox.Text;
            connectVM.VM_IP = IPTextBox.Text;
            connectVM.Connect();

            if (conStatus.Text != "Status: Cannot connect (invalid ip or port)")
            {
                connectB.IsEnabled = false;
                IPTextBox.IsEnabled = false;
                portTextBox.IsEnabled = false;
                disconnectB.IsEnabled = true;
            }
        }

        // The function behind the disconnect button.
        private void DisconnectB_Click(object sender, RoutedEventArgs e)
        {
            disconnectB.IsEnabled = false;
            IPTextBox.IsEnabled = true;
            portTextBox.IsEnabled = true;
            connectB.IsEnabled = true;

            connectVM.Disconnect();
        }
    }
}
