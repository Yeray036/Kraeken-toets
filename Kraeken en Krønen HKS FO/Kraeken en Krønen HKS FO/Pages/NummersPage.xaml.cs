using Kraeken_en_Krønen_HKS_FO.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for NummersPage.xaml
    /// </summary>
    public partial class NummersPage : Page
    {
        SearchProgramma SearchProgramma = new SearchProgramma();

        Youtube Youtube = new Youtube();
        public NummersPage()
        {
            InitializeComponent();
            DetailedNummerGrid.Visibility = Visibility.Hidden;
        }

        private void SearchNummerBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SearchNummer.Text != String.Empty)
                {
                    Songs.AllSongsTable.Clear();
                    SearchProgramma.GetAllSongs();
                    DataView dv = Songs.AllSongsTable.DefaultView;
                    dv.RowFilter = string.Format("titel like '%" + SearchNummer.Text + "%'");
                    DetailedNummerGrid.DataContext = dv;
                    DetailedNummerGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    DetailedNummerGrid.Visibility = Visibility.Hidden;
                    Songs.AllSongsTable.Clear();
                    MessageBox.Show("Geen filter toegevoegd");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void SearchArtiestBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SearchArtiest.Text != String.Empty)
                {
                    Songs.AllSongsTable.Clear();
                    SearchProgramma.GetAllSongs();
                    DataView dv = Songs.AllSongsTable.DefaultView;
                    dv.RowFilter = string.Format("artiest like '%" + SearchArtiest.Text + "%'");
                    DetailedNummerGrid.DataContext = dv;
                    DetailedNummerGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    DetailedNummerGrid.Visibility = Visibility.Hidden;
                    Songs.AllSongsTable.Clear();
                    MessageBox.Show("Geen filter toegevoegd");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void VerwijderSongBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserCredentials.Medewerker == 0 || UserCredentials.Medewerker == 2)
                {
                    MessageBox.Show("Je hebt geen toegang om dit nummer te verwijderen");
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Wil je dit nummer verwijderen?", $"Verwijder nummer", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        DataRowView row = (DataRowView)DetailedNummerGrid.SelectedItems[0];
                        string artiest = row["artiest"].ToString();
                        string titel = row["titel"].ToString();
                        SearchProgramma.RemoveSongFromDb(artiest, titel);
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void SendNewSongBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NewArtiest.Text != string.Empty && NewTitel.Text != string.Empty && NewDuur.Text != string.Empty && playlistCombobox.SelectedValue != null)
                {
                    int playlistId = int.Parse(playlistCombobox.SelectedValue.ToString());
                    SearchProgramma.AddNewSongToDb(NewArtiest.Text, NewTitel.Text, NewDuur.Text, playlistId, YoutubeIdText.Text);
                    NewTitel.Text = "";
                    NewDuur.Text = "";
                    playlistCombobox.SelectedItem = null;
                    Songs.AllSongsTable.Clear();
                    SearchProgramma.GetAllSongs();
                    DataView dv = Songs.AllSongsTable.DefaultView;
                    dv.RowFilter = string.Format("artiest like '%" + NewArtiest.Text + "%'");
                    DetailedNummerGrid.DataContext = dv;
                    NewArtiest.Text = "";
                }
                else
                {
                    MessageBox.Show($"Zijn alle velden ingevuld? {Environment.NewLine}Artiest= {NewArtiest.Text} {Environment.NewLine}Titel= {NewTitel.Text} {Environment.NewLine}Duur= {NewDuur.Text} {Environment.NewLine}Playlist= {playlistCombobox.SelectedItem}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void FillCombobox(object sender, RoutedEventArgs e)
        {
            try
            {
                playlistCombobox.Items.Clear();
                DetailedProgramma.PlaylistInfo.Clear();
                SearchProgramma.GetPlaylist();
                playlistCombobox.ItemsSource = DetailedProgramma.PlaylistInfo.DefaultView;
                playlistCombobox.DisplayMemberPath = "naam";
                playlistCombobox.SelectedValuePath = "playlistId";
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void PlaySongBtn(object sender, RoutedEventArgs e)
        {
            string baseUrl = "https://www.youtube.com/watch?v=";
            try
            {
                DataRowView row = (DataRowView)DetailedNummerGrid.SelectedItems[0];
                string nummerNaam = row["titel"].ToString();
                string nummerArtiest = row["artiest"].ToString();
                Youtube.GetYoutubeId(nummerArtiest, nummerNaam);
                if (Youtube.YoutubeId != String.Empty)
                {
                    YoutubePlayer.Navigate(baseUrl+Youtube.YoutubeId);
                    YoutubePlayer.Visibility = Visibility.Visible;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
