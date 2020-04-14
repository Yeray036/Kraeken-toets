using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
    }

    class Zenders
    {
        public void GetAllChannels()
        {
            try
            {
                ZenderNames.MusicZenders.Clear();
                ZenderNames.Musicdescription.Clear();
                var zenderquery = "select zendernaam, omschrijving from zenders";

                var cmd = new MySqlCommand(zenderquery, ConnectionVariables.conn);

                ConnectionVariables.conn.Open();
                var queryresult = cmd.ExecuteReader();
                if (queryresult.HasRows)
                {
                    while (queryresult.Read())
                    {
                        ZenderNames.MusicZenders.Add(queryresult.GetString(0).ToString());
                        ZenderNames.Musicdescription.Add(queryresult.GetString(1).ToString());
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
            var query = $"INSERT INTO `zenders` (`zenderId`, `zendernaam`, `omschrijving`) VALUES (NULL, '{ZenderInformation.ZenderTitelText}', '{ZenderInformation.ZenderOmschrijvingText}')";
            var cmd = new MySqlCommand(query, ConnectionVariables.conn);

            ConnectionVariables.conn.Open();
            var queryResult = cmd.ExecuteNonQuery();
            ConnectionVariables.conn.Close();
            if (queryResult < 0)
            {
                MessageBox.Show($"Error while inserting into {ConnectionVariables.conn.Database} DB");
            }
            else
            {
                MessageBox.Show($"New zender: {ZenderInformation.ZenderTitelText} added to {ConnectionVariables.conn.Database} DB");
            }
        }
    }
}
