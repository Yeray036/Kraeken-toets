using Kraeken_en_Krønen_HKS_FO.Classes;
using Kraeken_en_Krønen_HKS_FO.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace Kraeken_en_Krønen_HKS_FO.Pages
{
    /// <summary>
    /// Interaction logic for ProgrammasPage.xaml
    /// </summary>
    public partial class ProgrammasPage : Page
    {

        SearchProgramma SearchProgramma = new SearchProgramma();
        ProgrammaOverzichtLayout programmaOverzichtLayout = new ProgrammaOverzichtLayout();

        public ProgrammasPage()
        {
            InitializeComponent();
        }

        private void SearchBtn(object sender, RoutedEventArgs e)
        {
            if (SearchProgrammaTxt.Text != String.Empty)
            {
                DetailedProgrammaPanel.Children.Remove(programmaOverzichtLayout);
                GevondenProgrammaLabel.Content = $"Gevonden programma's met: {SearchProgrammaTxt.Text}";
                DetailedProgramma.programmaDataTable.Clear();
                SearchProgramma.SearchProgrammas();
                DataView dv = DetailedProgramma.programmaDataTable.DefaultView;
                dv.RowFilter = string.Format("naam like '%" + SearchProgrammaTxt.Text + "%'");
                DetailedProgrammaGrid.DataContext = dv;
            }
            else
            {
                DetailedProgrammaPanel.Children.Remove(programmaOverzichtLayout);
                DetailedProgramma.programmaDataTable.Clear();
                GevondenProgrammaLabel.Content = $"Gevonden programma's: 0";
                MessageBox.Show("Geen filter toegevoegd");
            }
        }

        private void OpenOverzichtBtn(object sender, RoutedEventArgs e)
        {
            Songs.ProgrammaSongTable.Clear();
            DetailedProgrammaPanel.Children.Remove(programmaOverzichtLayout);
            DataRowView row = (DataRowView)DetailedProgrammaGrid.SelectedItems[0];
            programmaOverzichtLayout.NaamProgramma.Content = $"Naam programma: '{row["naam"]}'";
            string prnaam = row["naam"].ToString();
            programmaOverzichtLayout.ZenderNaamProgramma.Content = $"Zender: {row["zendernaam"]}";
            SearchProgramma.GetInfoOfProgramma(prnaam);
            programmaOverzichtLayout.DatumProgramma.Content = "Datum: " + DetailedProgramma.Datum;
            programmaOverzichtLayout.BegintijdProgramma.Content = "Begintijd: " + DetailedProgramma.BeginTijd + " uur";
            programmaOverzichtLayout.EindTijdProgramma.Content = "Eindtijd: " + DetailedProgramma.EindTijd + " uur";
            programmaOverzichtLayout.PresentatorProgramma.Content = "Presentator: " + DetailedProgramma.Presentator;
            SearchProgramma.GetSongsFromProgramma(DetailedProgramma.prId, prnaam);
            programmaOverzichtLayout.PlaylistGrid.DataContext = Songs.ProgrammaSongTable.DefaultView;

            List<double> total = new List<double>();

            foreach (DataRowView item in programmaOverzichtLayout.PlaylistGrid.ItemsSource)
            {
                string tijd = item[2].ToString().Replace(":", ".");
                double Tijd = double.Parse(tijd, CultureInfo.InvariantCulture);
                total.Add(Tijd);
            }
            double ListSom = total.Sum();
            string TotalTime = ListSom.ToString().Replace(",", ":");
            programmaOverzichtLayout.TotaleTijd.Content = "Totaal: " + TotalTime;
            DetailedProgrammaPanel.Children.Add(programmaOverzichtLayout);
        }
    }
}
