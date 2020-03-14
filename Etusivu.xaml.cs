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
    /// </summary>
    
    public partial class Etusivu : Page
    {
        public Etusivu()
        {
            InitializeComponent();
            SetState();
            SetDataGridFields();
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

            if(Changelog.States == null)
            {
                State state = new State();
                Changelog.States = new List<State>();
                state.Time = DateTime.Now.ToShortTimeString();
                state.Lights = "Kaikki valot sammutettu";
                state.Temp = "19";
                state.SaunaStove = "Sammuksissa";
                Changelog.States.Add(state);
                PrintGridStates();
            }
            else
            {
                SaveState();
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

        // Save data changes to datagrid
        private void SaveState()
        {
            State state = new State();
            state.Time = DateTime.Now.ToShortTimeString();
            state.Lights = lblLightsState.Content.ToString();
            state.Temp = txtLampotila.Text;
            state.SaunaStove = lblSaunaState.Content.ToString();
            Changelog.States.Add(state);
            PrintGridStates();
        }

        private void PrintGridStates()
        {
            foreach(State state in Changelog.States)
            {
                dgChanges.Items.Add(state);
            }
        }

        // Set datagrid fields at start
        private void SetDataGridFields()
        {
            DataGridTextColumn columnAika = new DataGridTextColumn();
            DataGridTextColumn columnValaistus = new DataGridTextColumn();
            DataGridTextColumn columnHuonelampotila = new DataGridTextColumn();
            DataGridTextColumn columnSauna = new DataGridTextColumn();

            columnAika.Binding = new Binding("Time");
            columnValaistus.Binding = new Binding("Lights"); 
            columnHuonelampotila.Binding = new Binding("Temp");
            columnSauna.Binding = new Binding("SaunaStove");

            columnAika.Header = "Aika";
            columnValaistus.Header = "Valaistus";
            columnHuonelampotila.Header = "Lämpötila";
            columnSauna.Header = "Sauna";

            dgChanges.Columns.Add(columnAika);
            dgChanges.Columns.Add(columnValaistus);
            dgChanges.Columns.Add(columnHuonelampotila);
            dgChanges.Columns.Add(columnSauna);
        }

    }
}
