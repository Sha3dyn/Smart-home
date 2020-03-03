using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Alytalo
{
    class Lights
    {
        public static bool Switched { get; set; }
        public bool LightingState { get; set; }
        public static bool LightingStateChanged { get; set; }
        public static bool KitchenLightsOn { get; set; }
        public static bool LivingroomLightsOn { get; set; }
        public static string DimmerKitchen { get; set; }
        public static string DimmerLivingroom { get; set; }

        // Set relevat images and slider properties to show current state
        public void SwitchOnOrOff(Image imgCollapsed, Image imgVisible, Slider sliderset, bool enabled, bool switched)
        {
            imgCollapsed.Visibility = Visibility.Collapsed;
            imgVisible.Visibility = Visibility.Visible;

            // Check if state is changed
            if(switched != LightingState)
            {
                LightingStateChanged = true;
            }

            Switched = switched;

            sliderset.IsEnabled = enabled;

            if (enabled)
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
