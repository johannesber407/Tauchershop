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
    /// Interaction logic for DialogAnsichtAuftraege.xaml
    /// </summary>
    public partial class DialogAnsichtAuftraege : Window
    {
        public DialogAnsichtAuftraege()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this, DataGridAuftraege);
            ButtonErster_Click(null, null);
        }

        private void DataGridAuftraege_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ObjectDataProvider PositionenProvider;
            PositionenProvider = (ObjectDataProvider)(FindResource("PositionenSource"));
            PositionenProvider.MethodParameters[0] = DataGridAuftraege.SelectedValue;
            //AktualisiereAnsicht();
        }

        private void ButtonErster_Click(object sender, RoutedEventArgs e)
        {
            DataGridAuftraege.SelectedIndex = 0;
            AktualisiereAnsicht();
        }

        private void ButtonVoriger_Click(object sender, RoutedEventArgs e)
        {
            DataGridAuftraege.SelectedIndex--;
            AktualisiereAnsicht();
        }

        private void ButtonNaechster_Click(object sender, RoutedEventArgs e)
        {
            DataGridAuftraege.SelectedIndex++;
            AktualisiereAnsicht();
        }

        private void ButtonLetzter_Click(object sender, RoutedEventArgs e)
        {
            DataGridAuftraege.SelectedIndex = DataGridAuftraege.Items.Count - 1;
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
            Index = DataGridAuftraege.SelectedIndex;

            FocusManager.SetFocusedElement(this, DataGridAuftraege);

            DataGridAuftraege.ScrollIntoView(DataGridAuftraege.SelectedItem);

            SetzeNavigationsButton(ButtonErster, DataGridAuftraege.SelectedIndex > 0);
            SetzeNavigationsButton(ButtonVoriger, DataGridAuftraege.SelectedIndex > 0);
            SetzeNavigationsButton(ButtonNaechster, DataGridAuftraege.SelectedIndex < DataGridAuftraege.Items.Count - 1);
            SetzeNavigationsButton(ButtonLetzter, DataGridAuftraege.SelectedIndex < DataGridAuftraege.Items.Count - 1);

            LabelDatensatz.Content = "Datensatz " + (DataGridAuftraege.SelectedIndex + 1).ToString() + " von " + DataGridAuftraege.Items.Count.ToString();
        }

        private void ButtonRechnung_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridPositionen_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
