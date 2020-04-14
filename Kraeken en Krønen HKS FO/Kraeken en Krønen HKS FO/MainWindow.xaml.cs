using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Kraeken_en_Krønen_HKS_FO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zenders zenders = new Zenders();
        MainWindow home;

        public MainWindow Home { get => home; set => home = value; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenZendersPage(object sender, RoutedEventArgs e)
        {
            ZenderNames.MusicZenders.Clear();
            ZendersPage zendersPage = new ZendersPage();
            try
            {
                if (ZenderNames.MusicZenders.Count != ZenderNames.MusicZenders.Count)
                {
                    zendersPage.ExtraZender.Children.Clear();
                    zendersPage.ExtraZender1.Children.Clear();
                    zendersPage.ExtraZender2.Children.Clear();
                    zendersPage.ExtraZender3.Children.Clear();
                    zendersPage.ExtraZender4.Children.Clear();
                    zendersPage.ExtraZender5.Children.Clear();
                    zendersPage.PlaceZendersInGrid();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            pageFrame.Navigate(zendersPage);
        }

        private void OpenHomePage(object sender, RoutedEventArgs e)
        {
            pageFrame.Navigate(Home);
        }
    }
}
