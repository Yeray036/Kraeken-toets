using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Kraeken_en_Krønen_HKS_FO.UserControls
{
    /// <summary>
    /// Interaction logic for NewZenderLayout.xaml
    /// </summary>
    public partial class NewZenderLayout : UserControl
    {
        Zenders zenderClass = new Zenders();

        public NewZenderLayout()
        {
            InitializeComponent();
        }

        private void VerwijderClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int currentZenderId;
                string currentZender;
                currentZender = this.Name.Remove(0, 6);
                currentZenderId = Int32.Parse(currentZender);

                MessageBoxResult result = MessageBox.Show("Wil je deze zender verwijderen?", $"Verwijder zender: {currentZenderId}", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        zenderClass.DeleteZenderFromDb(currentZenderId, this.NewZender.Text);
                        ((Panel)this.Parent).Children.Remove(this);
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenWijzigControl(object sender, RoutedEventArgs e)
        {
            ChangeZenderTitel.Text = this.NewZender.Text;
            ChangeZenderOmschrijving.Text = this.NewOmschrijving.Text;
            ChangeZender.IsOpen = true;
        }

        private void CloseDialogBtn(object sender, RoutedEventArgs e)
        {
            ChangeZender.IsOpen = false;
        }

        private void AcceptChangeBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                int currentZenderId;
                string currentZender;
                currentZender = this.Name.Remove(0, 6);
                currentZenderId = Int32.Parse(currentZender);

                if (ChangeZenderTitel.Text != this.NewZender.Text || ChangeZenderOmschrijving.Text != this.NewOmschrijving.Text)
                {
                    MessageBoxResult result = MessageBox.Show("Wil je deze zender wijzigen?", $"Wijzig zender: {this.Tag}", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            zenderClass.ChangeZenderFromDb(ChangeZenderTitel.Text, ChangeZenderOmschrijving.Text, currentZenderId);
                            this.NewZender.Text = ChangeZenderTitel.Text;
                            this.NewOmschrijving.Text = ChangeZenderOmschrijving.Text;
                            ChangeZender.IsOpen = false;
                            break;
                        case MessageBoxResult.No:
                            ChangeZender.IsOpen = false;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Geen verandering gevonden");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenProgrammaOverzichtBtn(object sender, RoutedEventArgs e)
        {
            int currentZenderId;
            string currentZender;
            currentZender = this.Name.Remove(0, 6);
            currentZenderId = Int32.Parse(currentZender);

            ProgrammaOverzichtDialog.IsOpen = true;
            zenderClass.GetProgrammaOverzicht(currentZenderId);
            zenderClass.CalculateTotalTime(currentZenderId);
            if (Programmas.programmaDataTable.Columns.Contains("Duur in minuten"))
            {
                Console.WriteLine("Column duur in minuten bestaat al");
            }
            else
            {
                DataColumn column = new DataColumn();
                column.ColumnName = "Duur in minuten";
                Programmas.programmaDataTable.Columns.Add(column);
            }
            DataRow row;
            for (int i = 0; i < Programmas.beginTijd.Count; i++)
            {
                string eind = Programmas.eindTijd[i];
                int eindTijd = int.Parse(eind.Remove(2, 3));
                string begin = Programmas.beginTijd[i];
                int beginTijd = int.Parse(begin.Remove(2, 3));
                int totaal = (eindTijd - beginTijd) * 60;
                row = Programmas.programmaDataTable.NewRow();
                row["Duur in minuten"] = totaal;
                Programmas.programmaDataTable.Rows.InsertAt(row, i);
            }
            programmaOverzichtGrid.DataContext = Programmas.programmaDataTable;
        }
    }
}
