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

namespace Alytalo
{
    /// <summary>
    /// Interaction logic for Etusivu.xaml
    /// Korjaa bugi: jos vaihdetaan lämpötilaa ja hypätään muulle kuin etusivulle, päivitys ei siirry etusivulle ollenkaan!
    /// </summary>
    
    public partial class Etusivu : Page
    {
        public Etusivu()
        {
            InitializeComponent();
            SetState();
        }

        // Set current states 
        private void SetState()
        {

            if(Lights.LivingroomLightsOn || Lights.KitchenLightsOn)
            {
                SwitchedOnOrOff(imgLightsOn, imgLightsOff);
                lblLightsState.Content = "Valaistus päällä";
                PrintLightedRooms();
            }
            else
            {
                SwitchedOnOrOff(imgLightsOff, imgLightsOn);
                lblLightsState.Content = "Kaikki valot sammutettu";
            }
            
            
            if(SaunaClass.SaunaSwitched)
            {
                SwitchedOnOrOff(imgSaunaOn, imgSaunaOff);
                lblSaunaState.Content = SaunaClass.SaunaState;
            }
            else
            {
                SwitchedOnOrOff(imgSaunaOff, imgSaunaOn);

                if(SaunaClass.SaunaStateChanged)
                {
                    lblSaunaState.Content = SaunaClass.SaunaState;
                }
                else
                {
                    lblSaunaState.Content = "Sammuksissa";
                }
            }

            if (Thermostat.ChangedTemperature.ToString() != txtLampotila.Text)
            {
                txtLampotila.Text = Thermostat.Temperature.ToString();

                if(txtLampotila.Text == "0" && !Thermostat.ValueChanged)
                {
                    txtLampotila.Text = "19";
                }
            }
        }

        private void PrintLightedRooms()
        {
            if(Lights.KitchenLightsOn)
            {
                lblKitchenState.Content = "Keittiö " + Lights.DimmerKitchen + "%";
            }

            if(Lights.LivingroomLightsOn)
            {
                lblLivingroomState.Content = "Olohuone " + Lights.DimmerLivingroom + "%";
            }
        }

        // Set relevant on or off icons to show current state
        private void SwitchedOnOrOff(Image imgVisible, Image imgCollapsed)
        {
            imgVisible.Visibility = Visibility.Visible;
            imgCollapsed.Visibility = Visibility.Collapsed;
        }
    }
}
