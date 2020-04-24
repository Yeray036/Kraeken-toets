using Kraeken_en_Krønen_HKS_FO.Classes;
using Kraeken_en_Krønen_HKS_FO.Pages;
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
        MainWindow home;

        LoginPage loginPage = new LoginPage();
        NummersPage nummersPage = new NummersPage();
        public MainWindow Home { get => home; set => home = value; }

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                if (UserCredentials.UserName == String.Empty && UserCredentials.Password == String.Empty)
                {
                    LoginLabel.Content = "Login";
                }
                else
                {
                    LoginLabel.Content = UserCredentials.UserName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void OpenZendersPage(object sender, RoutedEventArgs e)
        {
            try
            {
                ZenderNames.MusicZenders.Clear();
                ZenderNames.Musicdescription.Clear();
                ZendersPage zendersPage = new ZendersPage();
                if (UserCredentials.UserName == String.Empty && UserCredentials.Password == String.Empty)
                {
                    LoginLabel.Content = "Login";
                }
                else
                {
                    LoginLabel.Content = UserCredentials.UserName;
                }
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
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void OpenHomePage(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserCredentials.UserName == String.Empty && UserCredentials.Password == String.Empty)
                {
                    LoginLabel.Content = "Login";
                }
                else
                {
                    LoginLabel.Content = UserCredentials.UserName;
                }
                pageFrame.Navigate(Home);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserCredentials.UserName == String.Empty && UserCredentials.Password == String.Empty)
                {
                    LoginLabel.Content = "Login";
                }
                else
                {
                    LoginLabel.Content = UserCredentials.UserName;
                }
                pageFrame.Navigate(loginPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void OpenProgrammaPage(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserCredentials.UserName == String.Empty && UserCredentials.Password == String.Empty)
                {
                    LoginLabel.Content = "Login";
                }
                else
                {
                    LoginLabel.Content = UserCredentials.UserName;
                }
                ProgrammasPage programmasPage = new ProgrammasPage();
                pageFrame.Navigate(programmasPage);
            }
            catch (Exception ex)
            {
               Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void OpenNummersPage(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserCredentials.UserName == String.Empty && UserCredentials.Password == String.Empty)
                {
                    LoginLabel.Content = "Login";
                }
                else
                {
                    LoginLabel.Content = UserCredentials.UserName;
                }
                pageFrame.Navigate(nummersPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
