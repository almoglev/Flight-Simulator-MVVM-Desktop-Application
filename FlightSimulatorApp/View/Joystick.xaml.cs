#define LIMIT
#define MIN_VALUE_NORM
#define DENOMINATOR_NORM

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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulatorApp.View
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl
    {
        private Storyboard storyboard;
        private Point mousePos = new Point();

        // Ctor.
        public Joystick()
        {
            InitializeComponent();

            storyboard = Knob.FindResource("CenterKnob") as Storyboard;
        }


        // The function behind the Mouse Down event of the joystick.
        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                mousePos = e.GetPosition(this);

            storyboard.Stop(this);
            Knob.CaptureMouse();
        }

        // The function behind the Mouse Move event of the joystick.
        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                #if LIMIT
                    double LIMIT = 55;
                #endif

                #if MIN_VALUE_NORM
                    double MIN_VALUE_NORM = -113;
                #endif

                #if DENOMINATOR_NORM
                    double DENOMINATOR_NORM = 226;
                #endif

                double x = e.GetPosition(this).X - mousePos.X;
                double y = e.GetPosition(this).Y - mousePos.Y;

                if (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) < (Base.Width / 2 - LIMIT))
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;

                    double normalX = (2 * ((x - MIN_VALUE_NORM) / DENOMINATOR_NORM)) - 1;
                    double normalY = (2 * ((y - MIN_VALUE_NORM) / DENOMINATOR_NORM)) - 1;

                    normalX = (normalX > 1) ? 1 : ((normalX < -1) ? -1 : normalX);
                    normalY = (normalY > 1) ? 1 : ((normalY < -1) ? -1 : normalY);

                    string str = string.Format("{0:F2}", normalX);
                    Rudder = double.Parse(str);
                    str = string.Format("{0:F2}", normalY);
                    Elevator = double.Parse(str);
                }
            }
        }

        // The function behind the Mouse Up event of the joystick.
        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        { 
            storyboard.Begin(this, true);
            var knobElement = (UIElement)Knob;
            knobElement.ReleaseMouseCapture();
        }

        // The function behind the Mouse Leave event of the joystick.
        private void Knob_MouseLeave(object sender, MouseEventArgs e)
        {
            storyboard.Begin(this, true);
            var knobElement = (UIElement)Knob;
            knobElement.ReleaseMouseCapture();
        }

        // The function for the animation of the knob in the story board.
        private void centerKnob_Completed(object sender, EventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
            Rudder = 0;
            Elevator = 0;
        }

        // Dependency properties for the rudder and elevator.
        public static readonly DependencyProperty RudderValProperty =
            DependencyProperty.Register("Rudder", typeof(double),
            typeof(Joystick), new PropertyMetadata(default(double))
            );
        public double Rudder
        {
            get { return (double)GetValue(RudderValProperty); }
            set { SetValue(RudderValProperty, value); }
        }

        public static readonly DependencyProperty ElevatorValProperty =
            DependencyProperty.Register("Elevator", typeof(double),
            typeof(Joystick), new PropertyMetadata(default(double))
            );
        public double Elevator
        {
            get { return (double)GetValue(ElevatorValProperty); }
            set { SetValue(ElevatorValProperty, value); }
        }
    }
}
