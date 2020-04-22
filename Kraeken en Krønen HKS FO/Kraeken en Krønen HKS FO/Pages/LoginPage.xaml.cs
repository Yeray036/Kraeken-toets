using Kraeken_en_Krønen_HKS_FO.Classes;
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

namespace Kraeken_en_Krønen_HKS_FO.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Login Login = new Login();

        public LoginPage()
        {
            InitializeComponent();
            LoginBtnStack.Children.Remove(UitlogBtn);
        }

        private void InloggenBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserName.Text != String.Empty && Password.Password != "")
                {
                    Login.UserLogin(UserName.Text, Password.Password);
                    if (UserCredentials.Medewerker == 1 || UserCredentials.Medewerker == 0)
                    {
                        LoginFields.Children.Remove(UserName);
                        LoginFields.Children.Remove(Password);
                        LoginBtnStack.Children.Remove(ActualBtn);
                        LoginLabel.Text = $"Welkom {UserCredentials.UserName} {UserCredentials.TussenVoegsel} {UserCredentials.Achternaam}";
                        LoginBtnStack.Children.Add(UitlogBtn);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Login velden zijn leeg");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void UitloggenBtn(object sender, RoutedEventArgs e)
        {
            LoginFields.Children.Add(UserName);
            LoginFields.Children.Add(Password);
            LoginBtnStack.Children.Add(ActualBtn);
            LoginBtnStack.Children.Remove(UitlogBtn);
            Password.Password = "";
            LoginLabel.Text = "Login";
            UserCredentials.UserName = String.Empty;
            UserCredentials.TussenVoegsel = String.Empty;
            UserCredentials.Achternaam = String.Empty;
            UserCredentials.Password = String.Empty;
            UserCredentials.Medewerker = 2;
        }
    }
}
