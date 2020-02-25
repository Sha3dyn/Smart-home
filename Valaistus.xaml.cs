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
        public static bool SwitchedKitchen { get; set; }
        public static bool SwitchedLivingroom { get; set; }
        public static string DimmerKitchen { get; set; }
        public static string DimmerLivingroom { get; set; }
        public static bool LightingState { get; set; }

        public Valaistus()
        {
            InitializeComponent();
            SetStarterValues();
        }

        // Set default values for each room
        private void SetStarterValues()
        {
            SwitchOnOrOff(imgOlohuoneOn, imgOlohuoneOff, sliderOlohuone, false); 
            SwitchOnOrOff(imgKeittioOn, imgKeittioOff, sliderKeittio, false);
        }

        // Values affected by dragging slider
        private void SliderOlohuone_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtOlohuoneSliderValue.Text = sliderOlohuone.Value.ToString();
            DimmerLivingroom = sliderOlohuone.Value.ToString();
            LightingState = true;
        }

        // Values affected by dragging slider
        private void SliderKeittio_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtKeittioSliderValue.Text = sliderKeittio.Value.ToString();
            DimmerKitchen = sliderKeittio.Value.ToString();
            LightingState = true;
        }

        // Set relevant images by pressing buttons (on or off button)

        private void ImgOlohuoneOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchOnOrOff(imgOlohuoneOn, imgOlohuoneOff, sliderOlohuone, false);
            SwitchedLivingroom = false;
            LightingState = true;
        }

        private void ImgOlohuoneOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchOnOrOff(imgOlohuoneOff, imgOlohuoneOn, sliderOlohuone, true);
            SwitchedLivingroom = true;
            LightingState = true;
        }

        private void ImgKeittioOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchOnOrOff(imgKeittioOff, imgKeittioOn, sliderKeittio, true);
            SwitchedKitchen = true;
            LightingState = true;
        }

        private void ImgKeittioOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchOnOrOff(imgKeittioOn, imgKeittioOff, sliderKeittio, false);
            SwitchedKitchen = false;
            LightingState = true;
        }

        // Set relevat images and slider properties to show current state
        private void SwitchOnOrOff(Image imgCollapsed, Image imgVisible, Slider sliderset, bool enabled)
        {
            imgCollapsed.Visibility = Visibility.Collapsed;
            imgVisible.Visibility = Visibility.Visible;
            sliderset.IsEnabled = enabled;

            if(enabled)
            {
                sliderset.Opacity = 100;
            }
            else
            {
                sliderset.Opacity = 0.5;
                sliderset.Value = 0;
            }
        }
    }
}
