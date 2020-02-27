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
using System.Windows.Threading;

namespace Alytalo
{
    /// <summary>
    /// Interaction logic for Sauna.xaml
    /// *ajastimen nopeuden tarkistus / korjaus
    /// </summary>
  
    public partial class Sauna : Page
    {
        SaunaClass sauna;
        public static TextBox CurrentTempText { get; set; }
        public static Label CurrentStateLabel { get; set; }

        public Sauna()
        {
            InitializeComponent();
            Thermostat.SetTemperature(txtSaunaTemp, false);
            sauna = new SaunaClass();
            CurrentTempText = txtSaunaTemp;
            CurrentStateLabel = lblState;
        }

        // Start heatingtimer by switching sauna on
        public void ImgSwitchOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SaunaClass.SwitchOnOrOff(imgSwitchOff, imgSwitchOn);
            sauna.StartHeatingTimer();
        }

        // Star coolingtimer by switching sauna off
        private void ImgSwitchOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SaunaClass.SwitchOnOrOff(imgSwitchOn, imgSwitchOff);
            sauna.StartCoolingTimer();
        }

        public static void PrintSaunaState(TextBox currentTemp, Label state)
        {
            currentTemp.Text = SaunaClass.SaunaTemp;
            state.Content = SaunaClass.SaunaState;
        }
    }
}
