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
        public DispatcherTimer SaunanAjastin = new DispatcherTimer();
        public DispatcherTimer JaahdytysAjastin = new DispatcherTimer();
        private int currentTemp;
        public static bool SaunaSwitched { get; set; }
        public static bool SaunaStateChanged { get; set; }
        public static string SaunaState { get; set; }
        public int SaunaTemp { get; set; }

        public Sauna()
        {
            InitializeComponent();
            currentTemp = SetCurrentTemperature();
            txtSaunaTemp.Text = currentTemp.ToString();
        }

        // Set default value to room temperature value
        private int SetCurrentTemperature()
        {
            int temp;

            if(lampotila.ValueChanged == false)
            {
                temp = 19;
            }
            else
            {
                temp = lampotila.Temperature;
            }

            return temp;
        }

        // Start heatingtimer by switching sauna on
        private void ImgSwitchOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchOnOrOff(imgSwitchOff, imgSwitchOn);
            StartTimer();
        }

        // Star coolingtimer by switching sauna off
        private void ImgSwitchOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchOnOrOff(imgSwitchOn, imgSwitchOff);
            StopTimer();
        }

        // Set relevant image to show current state
        private void SwitchOnOrOff(Image imgOne, Image imgTwo)
        {
            imgOne.Visibility = Visibility.Collapsed;
            imgTwo.Visibility = Visibility.Visible;
        }

        // Timer starter method to start heating
        private void StartTimer()
        {
            JaahdytysAjastin.Stop();
            SaunaSwitched = true;
            SaunaStateChanged = true;
            SaunanAjastin.Tick += SaunanAjastin_Tick;
            SaunanAjastin.Interval = TimeSpan.FromMilliseconds(500);
            SaunanAjastin.Start();
        }

        // Show current temp on every timer tick while heating up
        private void SaunanAjastin_Tick(object sender, EventArgs e)
        {
            currentTemp++;
            txtSaunaTemp.Text = currentTemp.ToString();
            lblState.Content = "Sauna päällä";
            SaunaState = lblState.Content.ToString();
        }

        // Stop timer method to stop heating and start cooling down
        private void StopTimer()
        {
            SaunanAjastin.Stop();
            SaunaSwitched = false;
            SaunaStateChanged = true;
            JaahdytysAjastin.Tick += JaahdytysAjastin_Tick;
            JaahdytysAjastin.Interval = TimeSpan.FromMilliseconds(500);
            JaahdytysAjastin.Start();
        }

        // Show current temp on every timer tick while cooling down
        private void JaahdytysAjastin_Tick(object sender, EventArgs e)
        {
            int startTemp = SetCurrentTemperature();

            if(currentTemp > startTemp)
            {
                currentTemp--;
                txtSaunaTemp.Text = currentTemp.ToString();
                lblState.Content = "Sauna jäähtyy";
                SaunaState = lblState.Content.ToString();
            }
            else
            {
                JaahdytysAjastin.Stop();
                lblState.Content = "Sammuksissa";
                SaunaState = lblState.Content.ToString();
            }
        }
    }
}
