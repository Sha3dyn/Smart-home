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
    /// Interaction logic for Valaistus.xaml
    /// *Switched ja dimmer muuttujat ja niiden tallennus johonkin
    /// *tietojen tallennus
    /// </summary>
 
    public partial class Valaistus : Page
    {
        Lights livingroom = new Lights();
        Lights kitchen = new Lights();

        public Valaistus()
        {
            InitializeComponent();
            SetStarterValues();
        }

        // Set default values for each room
        private void SetStarterValues()
        {
            livingroom.SwitchOnOrOff(imgOlohuoneOn, imgOlohuoneOff, sliderOlohuone, false, false); 
            kitchen.SwitchOnOrOff(imgKeittioOn, imgKeittioOff, sliderKeittio, false, false);
        }

        // Values affected by dragging slider
        private void SliderOlohuone_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtOlohuoneSliderValue.Text = sliderOlohuone.Value.ToString();
            Lights.DimmerLivingroom = sliderOlohuone.Value.ToString();
            livingroom.LightingState = true;
        }

        // Values affected by dragging slider
        private void SliderKeittio_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtKeittioSliderValue.Text = sliderKeittio.Value.ToString();
            Lights.DimmerKitchen = sliderKeittio.Value.ToString();
            kitchen.LightingState = true;
        }

        // Set relevant images and check values by pressing buttons (on or off button)

        private void ImgOlohuoneOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            livingroom.SwitchOnOrOff(imgOlohuoneOn, imgOlohuoneOff, sliderOlohuone, false, false);
            livingroom.LightingState = true;
            Lights.LivingroomLightsOn = false;
        }

        private void ImgOlohuoneOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            livingroom.SwitchOnOrOff(imgOlohuoneOff, imgOlohuoneOn, sliderOlohuone, true, true);
            livingroom.LightingState = true;
            Lights.LivingroomLightsOn = true;
        }

        private void ImgKeittioOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            kitchen.SwitchOnOrOff(imgKeittioOff, imgKeittioOn, sliderKeittio, true, true);
            kitchen.LightingState = true;
            Lights.KitchenLightsOn = true;
        }

        private void ImgKeittioOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            kitchen.SwitchOnOrOff(imgKeittioOn, imgKeittioOff, sliderKeittio, false, false);
            kitchen.LightingState = true;
            Lights.KitchenLightsOn = false;
        }
    }
}
