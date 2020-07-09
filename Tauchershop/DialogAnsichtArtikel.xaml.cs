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
using System.Windows.Shapes;

namespace Tauchershop
{
    /// <summary>
    /// Interaction logic for DialogAnsichtArtikel.xaml
    /// </summary>
    public partial class DialogAnsichtArtikel : Window
    {
        public DialogAnsichtArtikel()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this, DataGridTabelle);
            ButtonErster_Click(null, null);
        }
        private void ButtonErster_Click(object sender, RoutedEventArgs e)
        {
            DataGridTabelle.SelectedIndex = 0;
            AktualisiereAnsicht();
        }
        private void ButtonVoriger_Click(object sender, RoutedEventArgs e)
        {
            DataGridTabelle.SelectedIndex--;
            AktualisiereAnsicht();
        }
        private void ButtonNaechster_Click(object sender, RoutedEventArgs e)
        {
            DataGridTabelle.SelectedIndex++;
            AktualisiereAnsicht();
        }
        private void ButtonLetzter_Click(object sender, RoutedEventArgs e)
        {
            DataGridTabelle.SelectedIndex = DataGridTabelle.Items.Count - 1;
            AktualisiereAnsicht();
        }
        private void SetzeNavigationsButton(Button NavigationsButton, bool Aktiv)
        {
            NavigationsButton.IsEnabled = Aktiv;
            if (Aktiv)
            {
                ((Image)(NavigationsButton.Content)).Opacity = 1.0;
            }
            else
            {
                ((Image)(NavigationsButton.Content)).Opacity = 0.5;
            }
        }
        private void AktualisiereAnsicht()
        {
            int Index;
            Index = DataGridTabelle.SelectedIndex;

            FocusManager.SetFocusedElement(this, DataGridTabelle);

            DataGridTabelle.ScrollIntoView(DataGridTabelle.SelectedItem);

            SetzeNavigationsButton(ButtonErster, DataGridTabelle.SelectedIndex > 0);
            SetzeNavigationsButton(ButtonVoriger, DataGridTabelle.SelectedIndex > 0);
            SetzeNavigationsButton(ButtonNaechster, DataGridTabelle.SelectedIndex < DataGridTabelle.Items.Count - 1);
            SetzeNavigationsButton(ButtonLetzter, DataGridTabelle.SelectedIndex < DataGridTabelle.Items.Count - 1);

            LabelDatensatz.Content = "Datensatz " + (DataGridTabelle.SelectedIndex + 1).ToString() + " von " + DataGridTabelle.Items.Count.ToString();
        }
        private void DataGridTabelle_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            AktualisiereAnsicht();
        }
    }
}
