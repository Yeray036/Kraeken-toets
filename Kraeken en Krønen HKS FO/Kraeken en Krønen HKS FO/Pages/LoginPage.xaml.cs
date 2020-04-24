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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Login Login = new Login();

        public LoginPage()
        {
            InitializeComponent();
            try
            {
                LoginBtnStack.Children.Remove(UitlogBtn);
                LoginFields.Children.Remove(Tussenvoegsel);
                LoginFields.Children.Remove(Achternaam);
                LoginBtnStack.Children.Remove(Aanmaken);
                LoginBtnStack.Children.Remove(Terug);
                LoginBtnStack.Children.Remove(NieuweMedewerker);
                LoginBtnStack.Children.Remove(AddNewMedewerker);
                AllMedewerkers.Children.Remove(AllMedewerkersGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}" );
            }
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
                        LoginBtnStack.Children.Remove(Register);
                        LoginBtnStack.Children.Remove(NieuweMedewerker);
                        LoginLabel.Text = $"Welkom {UserCredentials.UserName} {UserCredentials.TussenVoegsel} {UserCredentials.Achternaam}";
                        LoginBtnStack.Children.Add(UitlogBtn);
                        if (UserCredentials.Medewerker == 1)
                        {
                            LoginBtnStack.Children.Add(NieuweMedewerker);
                            Login.GetAllMedewerkersFromDb();
                            AllMedewerkersGrid.DataContext = Medewerkers.MedewerkersNameTable.DefaultView;
                            AllMedewerkers.Children.Add(AllMedewerkersGrid);
                        }
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
            try
            {
                LoginFields.Children.Add(UserName);
                LoginFields.Children.Add(Password);
                LoginBtnStack.Children.Add(ActualBtn);
                LoginBtnStack.Children.Add(Register);
                LoginBtnStack.Children.Remove(UitlogBtn);
                LoginBtnStack.Children.Remove(NieuweMedewerker);
                AllMedewerkers.Children.Remove(AllMedewerkersGrid);
                UserName.Text = "";
                Tussenvoegsel.Text = "";
                Achternaam.Text = "";
                Password.Password = "";
                LoginLabel.Text = "Login";
                UserCredentials.UserName = String.Empty;
                UserCredentials.TussenVoegsel = String.Empty;
                UserCredentials.Achternaam = String.Empty;
                UserCredentials.Password = String.Empty;
                UserCredentials.Medewerker = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void RegisterBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginLabel.Text = "Registreren";
                UserName.Text = "";
                Tussenvoegsel.Text = "";
                Achternaam.Text = "";
                Password.Password = "";
                LoginFields.Children.Remove(UserName);
                LoginFields.Children.Remove(Password);
                LoginFields.Children.Add(UserName);
                LoginFields.Children.Add(Tussenvoegsel);
                LoginFields.Children.Add(Achternaam);
                LoginFields.Children.Add(Password);
                LoginBtnStack.Children.Add(Aanmaken);
                LoginBtnStack.Children.Add(Terug);
                LoginBtnStack.Children.Remove(ActualBtn);
                LoginBtnStack.Children.Remove(Register);
                LoginBtnStack.Children.Remove(NieuweMedewerker);
                AllMedewerkers.Children.Remove(AllMedewerkersGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void GebruikerAanmakenBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserName.Text != string.Empty && Achternaam.Text != string.Empty && Password.Password != string.Empty)
                {
                    Login.AddNewGebruiker(UserName.Text, Tussenvoegsel.Text, Achternaam.Text, Password.Password);
                    if (UserCredentials.Medewerker == 0)
                    {
                        LoginLabel.Text = "Login";
                        LoginBtnStack.Children.Remove(Aanmaken);
                        LoginBtnStack.Children.Remove(Terug);
                        LoginFields.Children.Remove(Tussenvoegsel);
                        LoginFields.Children.Remove(Achternaam);
                        LoginBtnStack.Children.Add(ActualBtn);
                        LoginBtnStack.Children.Add(Register);
                        LoginBtnStack.Children.Remove(NieuweMedewerker); 
                        AllMedewerkers.Children.Remove(AllMedewerkersGrid);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Kan je niet toevoegen omdat verplichte velden leeg zijn");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void TerugBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserCredentials.Medewerker != 1)
                {
                    LoginLabel.Text = "Login";
                    UserName.Text = "";
                    Tussenvoegsel.Text = "";
                    Achternaam.Text = "";
                    Password.Password = "";
                    LoginFields.Children.Remove(UserName);
                    LoginFields.Children.Remove(Password);
                    LoginFields.Children.Add(UserName);
                    LoginFields.Children.Remove(Tussenvoegsel);
                    LoginFields.Children.Remove(Achternaam);
                    LoginFields.Children.Add(Password);
                    AllMedewerkers.Children.Remove(AllMedewerkersGrid);
                    LoginBtnStack.Children.Remove(Aanmaken);
                    LoginBtnStack.Children.Remove(Terug);
                    LoginBtnStack.Children.Add(ActualBtn);
                    LoginBtnStack.Children.Add(Register);
                }
                else
                {
                    LoginLabel.Text = $"Welkom {UserCredentials.UserName} {UserCredentials.TussenVoegsel} {UserCredentials.Achternaam}";
                    UserName.Text = "";
                    Tussenvoegsel.Text = "";
                    Achternaam.Text = "";
                    Password.Password = "";
                    LoginBtnStack.Children.Remove(Terug);
                    LoginBtnStack.Children.Remove(AddNewMedewerker);
                    LoginFields.Children.Remove(UserName);
                    LoginFields.Children.Remove(Tussenvoegsel);
                    LoginFields.Children.Remove(Achternaam);
                    LoginFields.Children.Remove(Password);
                    AllMedewerkers.Children.Remove(AllMedewerkersGrid);
                    Login.GetAllMedewerkersFromDb();
                    AllMedewerkersGrid.DataContext = Medewerkers.MedewerkersNameTable.DefaultView;
                    AllMedewerkers.Children.Add(AllMedewerkersGrid);
                    LoginBtnStack.Children.Add(UitlogBtn);
                    LoginBtnStack.Children.Add(NieuweMedewerker);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void NieuweMedewerkerBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginLabel.Text = "Registreer nieuwe medewerker";
                UserName.Text = "";
                Tussenvoegsel.Text = "";
                Achternaam.Text = "";
                Password.Password = "";
                LoginBtnStack.Children.Remove(UitlogBtn);
                LoginBtnStack.Children.Remove(NieuweMedewerker);
                AllMedewerkers.Children.Remove(AllMedewerkersGrid);
                LoginFields.Children.Add(UserName);
                LoginFields.Children.Add(Tussenvoegsel);
                LoginFields.Children.Add(Achternaam);
                LoginFields.Children.Add(Password);
                LoginBtnStack.Children.Add(AddNewMedewerker);
                LoginBtnStack.Children.Add(Terug);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void AddNewMedewerkerBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserName.Text != string.Empty && Achternaam.Text != string.Empty && Password.Password != string.Empty)
                {
                    Login.AddNewMedewerkerToDb(UserName.Text, Tussenvoegsel.Text, Achternaam.Text, Password.Password);
                    if (UserCredentials.Medewerker == 1)
                    {
                        LoginLabel.Text = $"Welkom {UserCredentials.UserName} {UserCredentials.TussenVoegsel} {UserCredentials.Achternaam}";
                        LoginBtnStack.Children.Remove(AddNewMedewerker);
                        LoginBtnStack.Children.Remove(Terug);
                        LoginFields.Children.Remove(UserName);
                        LoginFields.Children.Remove(Tussenvoegsel);
                        LoginFields.Children.Remove(Achternaam);
                        LoginFields.Children.Remove(Password);
                        Login.GetAllMedewerkersFromDb();
                        AllMedewerkersGrid.DataContext = Medewerkers.MedewerkersNameTable.DefaultView;
                        AllMedewerkers.Children.Add(AllMedewerkersGrid);
                        LoginBtnStack.Children.Add(UitlogBtn);
                        LoginBtnStack.Children.Add(NieuweMedewerker);
                    }
                }
                else
                {
                    MessageBox.Show("Kan medewerker niet toevoegen omdat verplichte velden leeg zijn");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void WijzigMedewerkerBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)AllMedewerkersGrid.SelectedItems[0];
                string medewerkerNaam = row["naam"].ToString();
                Login.GetGebruikerId(medewerkerNaam);
                AllMedewerkersGrid.CommitEdit();
                AllMedewerkersGrid.CommitEdit();
                AllMedewerkersGrid.Items.Refresh();
                DataRowView rownew = (DataRowView)AllMedewerkersGrid.SelectedItems[0];
                string NewNaam = rownew["naam"].ToString();
                Login.UpdateMedewerkerFromDb(NewNaam, Medewerkers.GebruikersId);
                Login.GetAllMedewerkersFromDb();
                AllMedewerkersGrid.DataContext = Medewerkers.MedewerkersNameTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void VerwijderMedewerkerBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)AllMedewerkersGrid.SelectedItems[0];
                string medewerkerNaam = row["naam"].ToString();
                Login.GetGebruikerId(medewerkerNaam);

                MessageBoxResult result = MessageBox.Show($"Wil je {medewerkerNaam} verwijderen?", $"Verwijder medewerker", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Login.VerwijderMedewerkerFromDb(medewerkerNaam, Medewerkers.GebruikersId);
                        Login.GetAllMedewerkersFromDb();
                        AllMedewerkersGrid.DataContext = Medewerkers.MedewerkersNameTable.DefaultView;
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
    }
}
