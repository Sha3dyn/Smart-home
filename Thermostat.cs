using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Alytalo
{
    class Thermostat
    {
        public static int Temperature { get; set; }
        public static bool ValueChanged { get; set; }
        public static int ChangedTemperature { get; set; }

        public static void SetTemperature(TextBox text, bool changed)
        {
            if(!ValueChanged)
            {
                Temperature = 19;
            }

            ValueChanged = changed;
            text.Text = Temperature.ToString();
        }
    }
}
