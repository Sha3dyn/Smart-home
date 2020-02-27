using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Alytalo
{
    class SaunaClass
    {
        public DispatcherTimer HeatingTimer = new DispatcherTimer();
        public DispatcherTimer CoolingTimer = new DispatcherTimer();
        private int currentTemp = Thermostat.Temperature;
        private int startTemp = Thermostat.Temperature;
        public static bool SaunaSwitched { get; set; }
        public static bool SaunaStateChanged { get; set; }
        public static string SaunaState { get; set; }
        public static string SaunaTemp { get; set; }

        public SaunaClass()
        {
        }

        // Start heatingtimer
        public void StartHeatingTimer()
        {
            CoolingTimer.Stop();
            SaunaSwitched = true;
            SaunaStateChanged = true;
            HeatingTimer.Tick += HeatingTimer_Tick;
            HeatingTimer.Interval = TimeSpan.FromMilliseconds(500);
            HeatingTimer.Start();
        }

        // Show current temp on every timer tick while heating up
        private void HeatingTimer_Tick(object sender, EventArgs e)
        {
            currentTemp++;
            SaunaState = "Sauna päällä";
            SaunaTemp = currentTemp.ToString();
            Sauna.PrintSaunaState(Sauna.CurrentTempText, Sauna.CurrentStateLabel);
        }

        // Start coolingtimer
        public void StartCoolingTimer()
        {
            HeatingTimer.Stop();
            SaunaSwitched = false;
            SaunaStateChanged = true;
            CoolingTimer.Tick += CoolingTimer_Tick;
            CoolingTimer.Interval = TimeSpan.FromMilliseconds(500);
            CoolingTimer.Start();
        }

        // Show current temp on every timer tick while cooling down
        private void CoolingTimer_Tick(object sender, EventArgs e)
        {
            if (currentTemp > startTemp)
            {
                currentTemp--;
                SaunaState = "Sauna jäähtyy";
                SaunaTemp = currentTemp.ToString();
                Sauna.PrintSaunaState(Sauna.CurrentTempText, Sauna.CurrentStateLabel);
            }
            else
            {
                CoolingTimer.Stop();
                SaunaState = "Sammuksissa";
                Sauna.PrintSaunaState(Sauna.CurrentTempText, Sauna.CurrentStateLabel);
            }
        }

        // Set relevant image to show current state
        public static void SwitchOnOrOff(Image imgOne, Image imgTwo)
        {
            imgOne.Visibility = Visibility.Collapsed;
            imgTwo.Visibility = Visibility.Visible;
        }
    }
}
