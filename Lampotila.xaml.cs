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
        public static int Temperature { get; set; }
        public static bool ValueChanged { get; set; }

        public lampotila()
        {
            InitializeComponent();
            SetStarterValues();  
        }

        // Set default room temperature at start
        public void SetStarterValues()
        {
            int startTemp = 19;

            if(!ValueChanged)
            {
                Temperature = startTemp;
            }

            txtCurrentTemp.Text = Temperature.ToString();
        }

        // Set new room temperature
        private void BtnSetTemp_Click(object sender, RoutedEventArgs e)
        {
            txtCurrentTemp.Text = txtSetTemp.Text;
            Temperature = Int32.Parse(txtCurrentTemp.Text);
            txtSetTemp.Clear();
            ValueChanged = true;
        }
    }
}
