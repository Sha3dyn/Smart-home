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
    /// Interaction logic for MainWindow.xaml
    /// Lisää nappi, jota painamalla ohjelma kertoo ääneen tilan
    /// Tallenna lokiin
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Etusivu etusivu;
        lampotila lampo;
        Sauna sauna;
        Valaistus valo;

        public MainWindow()
        {
            InitializeComponent();
            frame.Content = new Etusivu();
        }
        

        // Enable window moving by dragging
        private void BrdrTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // Application shutdown by pressing X button
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Load pages by pressing relevant button

        private void BtnEtusivu_Click(object sender, RoutedEventArgs e)
        {
            // Update etusivu if values are changed
            if(etusivu == null || SaunaClass.SaunaStateChanged || Thermostat.ValueChanged || Lights.LightingStateChanged
                || etusivu.txtLampotila.Text != Thermostat.ChangedTemperature.ToString()) 
            {
                etusivu = new Etusivu();
            }

            frame.Content = etusivu;
        }

        private void BtnValaistus_Click(object sender, RoutedEventArgs e)
        {
            if(valo == null)
            {
                valo = new Valaistus();
            }

            frame.Content = valo;
        }

        private void BtnLampotila_Click(object sender, RoutedEventArgs e)
        {
            if(lampo == null)
            {
                lampo = new lampotila();
            }

            frame.Content = lampo;
        }

        private void BtnSauna_Click(object sender, RoutedEventArgs e)
        {
            // Update values to Sauna if lampotila value is changed
            if(sauna == null || Thermostat.ValueChanged)
            {
                sauna = new Sauna();
            }

            frame.Content = sauna;
        }

    }
}
