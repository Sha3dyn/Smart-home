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
    /// Valaistus jos jossain valot > switched = true > näytä, missä huoneessa valot. Nappi jolla sammuttaa / käynnistää kaikki valot 100% dimmer
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
            if(Valaistus.SwitchedLivingroom || Valaistus.SwitchedKitchen)
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
            
            if(Sauna.SaunaSwitched)
            {
                SwitchedOnOrOff(imgSaunaOn, imgSaunaOff);
                lblSaunaState.Content = Sauna.SaunaState;
            }
            else
            {
                SwitchedOnOrOff(imgSaunaOff, imgSaunaOn);

                if(Sauna.SaunaStateChanged)
                {
                    lblSaunaState.Content = Sauna.SaunaState;
                }
                else
                {
                    lblSaunaState.Content = "Sammuksissa";
                }
            }

            if(!lampotila.ValueChanged) 
            {
                txtLampotila.Text = "19";
            }
            else
            {
                txtLampotila.Text = lampotila.Temperature.ToString();
            }
        }

        private void PrintLightedRooms()
        {
            if(Valaistus.SwitchedKitchen)
            {
                lblKitchenState.Content = "Keittiö " + Valaistus.DimmerKitchen + "%";
            }

            if(Valaistus.SwitchedLivingroom)
            {
                lblLivingroomState.Content = "Olohuone " + Valaistus.DimmerLivingroom + "%";
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
