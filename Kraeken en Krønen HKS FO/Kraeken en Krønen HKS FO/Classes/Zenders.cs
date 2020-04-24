using Kraeken_en_Krønen_HKS_FO.UserControls;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Kraeken_en_Krønen_HKS_FO
{

    class ConnectionVariables
    {
        public static string cs = ConfigurationManager.ConnectionStrings["Kraeken"].ConnectionString;
        public static MySqlConnection conn = new MySqlConnection(ConnectionVariables.cs);
    }

    class ZenderNames
    {
        private static List<string> MusicChannels = new List<string>();

        public static List<string> MusicZenders
        {
            get { return MusicChannels; }
            set { MusicChannels = value; }
        }

        private static List<string> MusicDescription = new List<string>();

        public static List<string> Musicdescription
        {
            get { return MusicDescription; }
            set { MusicDescription = value; }
        }

        private static List<int> ZenderId = new List<int>();

        public static List<int> ZendersId
        {
            get { return ZenderId; }
            set { ZenderId = value; }
        }
    }

    class Programmas
    {
        private static DataTable dt = new DataTable();

        public static DataTable programmaDataTable
        {
            get { return dt; }
            set { dt = value; }
        }

        private static List<string> BeginTijd = new List<string>();

        public static List<string> beginTijd
        { 
            get { return BeginTijd; }
            set { BeginTijd = value; }
        }

        private static List<string> EindTijd = new List<string>();

        public static List<string> eindTijd
        {
            get { return EindTijd; }
            set { EindTijd = value; }
        }

        private static int ProgrammaId = 0;

        public static int prId
        {
            get { return ProgrammaId; }
            set { ProgrammaId = value; }
        }
    }

    class Zenders
    {
        public void GetAllChannels()
        {
            try
            {
                ZenderNames.MusicZenders.Clear();
                ZenderNames.Musicdescription.Clear();
                ZenderNames.ZendersId.Clear();
                var zenderquery = "SELECT zendernaam, omschrijving, zenderId FROM zenders";

                var cmd = new MySqlCommand(zenderquery, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryresult = cmd.ExecuteReader();
                if (queryresult.HasRows)
                {
                    while (queryresult.Read())
                    {
                        ZenderNames.MusicZenders.Add(queryresult.GetString(0).ToString());
                        ZenderNames.Musicdescription.Add(queryresult.GetString(1).ToString());
                        ZenderNames.ZendersId.Add(queryresult.GetInt32(2));
                    }
                }
                else
                {
                    ZenderNames.MusicZenders.Add("Geen zender");
                    ZenderNames.Musicdescription.Add("Geen informatie");
                }
                queryresult.Close();
                ConnectionVariables.conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateDbWithNewZenders()
        {
            try
            {
                var query = $"INSERT INTO `zenders` (`zenderId`, `zendernaam`, `omschrijving`) VALUES (NULL, '{ZenderInformation.ZenderTitelText}', '{ZenderInformation.ZenderOmschrijvingText}')";
                var cmd = new MySqlCommand(query, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryResult = cmd.ExecuteNonQuery();
                ConnectionVariables.conn.Close();
                if (queryResult < 0)
                {
                    MessageBox.Show($"Fout kan geen zender toevoegen in {ConnectionVariables.conn.Database} DB");
                }
                else
                {
                    MessageBox.Show($"Nieuwe zender: {ZenderInformation.ZenderTitelText} toegevoegd aan {ConnectionVariables.conn.Database} DB");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteZenderFromDb(int zenderId, string zendernaam)
        {
            try
            {
                var query = $"DELETE FROM zenders WHERE zenderId={zenderId}";
                var cmd = new MySqlCommand(query, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryResult = cmd.ExecuteNonQuery();
                ConnectionVariables.conn.Close();
                if (queryResult < 0)
                {
                    MessageBox.Show("Geen zender gevonden om te verwijderen");
                }
                else
                {
                    MessageBox.Show($"{zendernaam} is verwijderd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public void ChangeZenderFromDb(string zendernaam, string zenderomschrijving, int zenderId)
        {
            try
            {
                var query = $"UPDATE `zenders` SET `zendernaam` = '{zendernaam}', `omschrijving` = '{zenderomschrijving}' WHERE `zenders`.`zenderId` = {zenderId}";
                var cmd = new MySqlCommand(query, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryResult = cmd.ExecuteNonQuery();
                ConnectionVariables.conn.Close();
                if (queryResult < 0)
                {
                    MessageBox.Show("Geen zender gevonden om te wijzigen");
                }
                else
                {
                    MessageBox.Show($"{zendernaam} is gewijzigd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public void GetProgrammaOverzicht(int zenderId)
        {
            try
            {
                Programmas.programmaDataTable.Clear();
                var query = $"SELECT naam, datum, begin_tijd, eind_tijd, presentator FROM programmas WHERE zenderId={zenderId}";

                ConnectionVariables.conn.Open();

                using (MySqlCommand cmdSel = new MySqlCommand(query, ConnectionVariables.conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                    da.Fill(Programmas.programmaDataTable);
                }
                ConnectionVariables.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public void CalculateTotalTime(int zenderId, string zenderNaam)
        {
            try
            {
                Programmas.beginTijd.Clear();
                Programmas.eindTijd.Clear();
                var query = $"SELECT begin_tijd, eind_tijd FROM programmas WHERE zenderId={zenderId}";

                var cmd = new MySqlCommand(query, ConnectionVariables.conn);
                ConnectionVariables.conn.Open();
                var queryresult = cmd.ExecuteReader();
                if (queryresult.HasRows)
                {
                    while (queryresult.Read())
                    {
                        Programmas.beginTijd.Add(queryresult.GetString(0));
                        Programmas.eindTijd.Add(queryresult.GetString(1));
                    }
                }
                else
                {
                    MessageBox.Show($"Kan {zenderNaam} programma niet vinden");
                }
                queryresult.Close();
                ConnectionVariables.conn.Close();
            }
            catch (Exception ex)
            {
                ConnectionVariables.conn.Close();
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateProgramma(int programmaId, string naam, string datum, string begintijd, string eindtijd, string presentator)
        {
            try
            {
                var query = $"UPDATE `programmas` SET `naam` = '{naam}', `datum` = '{datum}', `begin_tijd` = '{begintijd}', `eind_tijd` = '{eindtijd}', `presentator` = '{presentator}' WHERE `programmas`.`programmaId` = {programmaId}";
                var cmd = new MySqlCommand(query, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryResult = cmd.ExecuteNonQuery();
                ConnectionVariables.conn.Close();
                if (queryResult < 0)
                {
                    MessageBox.Show("Geen programma gevonden om te wijzigen");
                }
                else
                {
                    MessageBox.Show($"{naam} is gewijzigd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveProgrammaFromDB(int programmaId, string programmaNaam)
        {
            try
            {
                var query = $"DELETE FROM programmas WHERE programmaId={programmaId}";
                var cmd = new MySqlCommand(query, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryResult = cmd.ExecuteNonQuery();
                ConnectionVariables.conn.Close();
                if (queryResult < 0)
                {
                    MessageBox.Show("Geen programma gevonden om te verwijderen");
                }
                else
                {
                    MessageBox.Show($"{programmaNaam} is verwijderd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public void GetProgrammaId(int zenderId, string programmaNaam)
        {
            try
            {
                Programmas.prId = 0;
                var query = $"SELECT programmaId FROM programmas WHERE naam='{programmaNaam}' AND zenderId='{zenderId}'";

                var cmd = new MySqlCommand(query, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryresult = cmd.ExecuteReader();
                if (queryresult.HasRows)
                {
                    while (queryresult.Read())
                    {
                        Programmas.prId = queryresult.GetInt32(0);
                    }
                }
                else
                {
                    MessageBox.Show("Geen programma gevonden");
                }
                queryresult.Close();
                ConnectionVariables.conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
            }
        }

    }
}
