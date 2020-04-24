using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kraeken_en_Krønen_HKS_FO.Classes
{
    class Youtube
    {
        private static string Youtubeid;

        public static string YoutubeId
        {
            get { return Youtubeid; }
            set { Youtubeid = value; }
        }

        public void GetYoutubeId(string Artiest, string Titel)
        {
            try
            {
                Youtube.YoutubeId = String.Empty;
                var query = $"SELECT youtubeId FROM songs WHERE artiest='{Artiest}' AND titel='{Titel}'";

                var cmd = new MySqlCommand(query, ConnectionVariables.conn);
                ConnectionVariables.conn.Open();
                var queryresult = cmd.ExecuteReader();
                if (queryresult.HasRows)
                {
                    while (queryresult.Read())
                    {
                        Youtube.YoutubeId = queryresult.GetString(0);
                    }
                }
                else
                {
                    MessageBox.Show($"Kan {Titel} van {Artiest} niet vinden");
                    Youtube.YoutubeId = String.Empty;
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
    }
}
