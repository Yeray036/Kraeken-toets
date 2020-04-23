using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kraeken_en_Krønen_HKS_FO.Classes
{
    class Login
    {
        public void UserLogin(string userName, string pwd)
        {
            try
            {
                var query = $"SELECT * FROM gebruikers WHERE naam='{userName}' AND wachtwoord='{pwd}'";

                var cmd = new MySqlCommand(query, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryresult = cmd.ExecuteReader();
                if (queryresult.Read())
                {
                    UserCredentials.UserName = queryresult.GetString(1).ToString();
                    UserCredentials.TussenVoegsel = queryresult.GetString(2).ToString();
                    UserCredentials.Achternaam = queryresult.GetString(3).ToString();
                    UserCredentials.Password = queryresult.GetString(4).ToString();
                    UserCredentials.Medewerker = queryresult.GetInt32(5);
                }
                else
                {
                    MessageBox.Show("Verkeerde inlog gegevens");
                }
                queryresult.Close();
                ConnectionVariables.conn.Close();
            }
            catch (Exception e)
            {
                ConnectionVariables.conn.Close();
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
            }
        }

        public void AddNewGebruiker(string Naam, string Tussenvoegsel, string Achternaam, string Wachtwoord)
        {
            try
            {
                var query = $"INSERT INTO `gebruikers` (`naam`, `tussenvoegsel`, `achternaam`, `wachtwoord`, `medewerker`) VALUES ('{Naam}', '{Tussenvoegsel}', '{Achternaam}', '{Wachtwoord}', '0')";

                var cmd = new MySqlCommand(query, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryResult = cmd.ExecuteNonQuery();
                ConnectionVariables.conn.Close();
                if (queryResult < 0)
                {
                    MessageBox.Show($"Fout kan {Naam} niet toevoegen in {ConnectionVariables.conn.Database} DB");
                }
                else
                {
                    MessageBox.Show($"Nieuwe gebruiker: {Naam} is toegevoegd aan {ConnectionVariables.conn.Database} DB");
                    UserCredentials.Medewerker = 0;
                }
            }
            catch (Exception e)
            {
                ConnectionVariables.conn.Close();
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
            }
        }

        public void AddNewMedewerkerToDb(string Naam, string Tussenvoegsel, string Achternaam, string Wachtwoord)
        {
            try
            {
                var query = $"INSERT INTO `gebruikers` (`naam`, `tussenvoegsel`, `achternaam`, `wachtwoord`, `medewerker`) VALUES ('{Naam}', '{Tussenvoegsel}', '{Achternaam}', '{Wachtwoord}', '1')";

                var cmd = new MySqlCommand(query, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryResult = cmd.ExecuteNonQuery();
                ConnectionVariables.conn.Close();
                if (queryResult < 0)
                {
                    MessageBox.Show($"Fout kan {Naam} niet toevoegen in {ConnectionVariables.conn.Database} DB");
                }
                else
                {
                    MessageBox.Show($"Nieuwe medewerker: {Naam} is toegevoegd aan {ConnectionVariables.conn.Database} DB");
                }
            }
            catch (Exception e)
            {
                ConnectionVariables.conn.Close();
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
            }
        }
    }
    
    class UserCredentials
    {
        private static string username = "";

        public static string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private static string pwd = "";

        public static string Password
        {
            get { return pwd; }
            set { pwd = value; }
        }

        private static string tussenVoegsel = "";

        public static string TussenVoegsel
        {
            get { return tussenVoegsel; }
            set { tussenVoegsel = value; }
        }

        private static string achterNaam = "";

        public static string Achternaam
        {
            get { return achterNaam; }
            set { achterNaam = value; }
        }

        private static int medeWerker = 2;

        public static int Medewerker
        {
            get { return medeWerker; }
            set { medeWerker = value; }
        }
    }
}
