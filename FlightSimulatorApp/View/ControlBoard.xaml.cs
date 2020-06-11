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
using FlightSimulatorApp.ViewModel;

namespace FlightSimulatorApp.View
{
    /// <summary>
    /// Interaction logic for ControlBoard.xaml
    /// </summary>
    public partial class ControlBoard : UserControl
    {
        private ControlBoardVM controlBoardVM;

        // Ctor.
        public ControlBoard()
        {
            InitializeComponent();
        }

        // The function behind the aileron slider.
        private void AileronSlider_MouseMove(object sender, MouseEventArgs e)
        {
            AileronVal.Content = string.Format("{0:F2}", AileronSlider.Value);
            this.controlBoardVM.VM_Ailerron = AileronSlider.Value;
        }

        // The function behind the throttle slider.
        private void ThrottleSlider_MouseMove(object sender, MouseEventArgs e)
        {
            //double normalVal = ThrottleSlider.Value / 10;
            ThrotVal.Content = string.Format("{0:F2}", ThrottleSlider.Value);
            this.controlBoardVM.VM_Throttle = ThrottleSlider.Value;
        }


        // Setting the control board view model.
        public void SetControlBoardVM(ControlBoardVM controlBoard_VM)
        {
            this.controlBoardVM = controlBoard_VM;
        }
    }
}
