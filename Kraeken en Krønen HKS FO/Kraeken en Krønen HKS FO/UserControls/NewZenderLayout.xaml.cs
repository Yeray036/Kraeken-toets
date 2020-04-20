using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

        class GridColumns
        {
            private static string programmaNaam = "";

            public static string prNaam
            {
                get { return programmaNaam; }
                set { programmaNaam = value; }
            }

            private static string programmaDatum = "";

            public static string prDatum
            {
                get { return programmaDatum; }
                set { programmaDatum = value; }
            }

            private static string programmaBegintijd = "";

            public static string prBegintijd
            {
                get { return programmaBegintijd; }
                set { programmaBegintijd = value; }
            }

            private static string programmaEindtijd = "";

            public static string prEindtijd
            {
                get { return programmaEindtijd; }
                set { programmaEindtijd = value; }
            }

            private static string programmaPresentator = "";

            public static string prPresentator
            {
                get { return programmaPresentator; }
                set { programmaPresentator = value; }
            }
        }

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
            try
            {
                FillGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ProgrammaOverzichtDialog.IsOpen = false;
            }
        }

        public void FillGrid()
        {
            try
            {
                Programmas.programmaDataTable.Clear();
                this.programmaOverzichtGrid.DataContext = null;
                int currentZenderId;
                string currentZender;
                currentZender = this.Name.Remove(0, 6);
                currentZenderId = Int32.Parse(currentZender);
                ProgrammaOverzichtDialog.IsOpen = true;
                zenderClass.GetProgrammaOverzicht(currentZenderId);
                zenderClass.CalculateTotalTime(currentZenderId, this.NewZender.Text);
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
                TotalTimeCalculator();
                this.programmaOverzichtGrid.DataContext = Programmas.programmaDataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ProgrammaOverzichtDialog.IsOpen = false;
            }
        }

        public void TotalTimeCalculator()
        {
            try
            {
                DataRow row;
                for (int i = 0; i < Programmas.beginTijd.Count; i++)
                {
                    string eind = Programmas.eindTijd[i].Replace(":", ".");
                    double eindTijd = double.Parse(eind, CultureInfo.InvariantCulture);
                    string begin = Programmas.beginTijd[i].Replace(":", ".");
                    double beginTijd = double.Parse(begin, CultureInfo.InvariantCulture);
                    double totaal = (eindTijd - beginTijd) * 60;
                    row = Programmas.programmaDataTable.Rows[i];
                    row["Duur in minuten"] = totaal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CloseDialogGrid(object sender, MouseEventArgs e)
        {
            ProgrammaOverzichtDialog.IsOpen = false;
        }

        private void UpdateProgrammaBtn(object sender, RoutedEventArgs e)
        {
            int currentZenderId;
            string currentZender;
            currentZender = this.Name.Remove(0, 6);
            currentZenderId = Int32.Parse(currentZender);
            DataRowView row = (DataRowView)programmaOverzichtGrid.SelectedItems[0];
            GridColumns.prNaam = row["naam"].ToString();
            zenderClass.GetProgrammaId(currentZenderId, GridColumns.prNaam);
            GridColumns.prDatum = row["datum"].ToString();
            GridColumns.prBegintijd = row["begin_tijd"].ToString();
            GridColumns.prEindtijd = row["eind_tijd"].ToString();
            GridColumns.prPresentator = row["presentator"].ToString();
            int currentPrId = Programmas.prId;
            Console.WriteLine(currentPrId + GridColumns.prNaam + GridColumns.prDatum + GridColumns.prBegintijd + GridColumns.prEindtijd + GridColumns.prPresentator);
            //zenderClass.UpdateProgramma(currentPrId, GridColumns.prNaam, GridColumns.prDatum, GridColumns.prBegintijd, GridColumns.prEindtijd, GridColumns.prPresentator);
        }

        private void UpdateGrid(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
