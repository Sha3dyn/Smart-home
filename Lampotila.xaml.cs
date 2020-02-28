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
    /// Interaction logic for Lampotila.xaml
    /// </summary>
   
    public partial class lampotila : Page
    {


        public lampotila()
        {
            InitializeComponent();
            Thermostat.SetTemperature(txtCurrentTemp, false);
        }

        private void BtnSetTemp_Click(object sender, RoutedEventArgs e)
        {
            txtCurrentTemp.Text = txtSetTemp.Text;
            Thermostat.Temperature = Int32.Parse(txtCurrentTemp.Text);
            txtSetTemp.Clear();
        }

        private void TxtCurrentTemp_TextChanged(object sender, TextChangedEventArgs e)
        {
            Thermostat.ChangedTemperature = Int32.Parse(txtCurrentTemp.Text);
            Thermostat.ValueChanged = true;
        }
    }
}
