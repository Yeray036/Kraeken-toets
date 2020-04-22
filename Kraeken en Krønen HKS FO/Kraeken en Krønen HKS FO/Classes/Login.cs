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
                    Console.WriteLine(UserCredentials.UserName + UserCredentials.TussenVoegsel + UserCredentials.Achternaam + pwd + UserCredentials.Medewerker);
                }
                queryresult.Close();
                ConnectionVariables.conn.Close();
                Console.WriteLine(UserCredentials.UserName + UserCredentials.TussenVoegsel + UserCredentials.Achternaam + pwd + UserCredentials.Medewerker);
            }
            catch (Exception e)
            {
                ConnectionVariables.conn.Close();
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
                Console.WriteLine(UserCredentials.UserName  +  UserCredentials.TussenVoegsel  +  UserCredentials.Achternaam  +  pwd  +  UserCredentials.Medewerker);
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
