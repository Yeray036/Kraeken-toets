using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kraeken_en_Krønen_HKS_FO
{

    class ConnectionVariables 
    {
        public static string cs = ConfigurationManager.ConnectionStrings["Kraeken"].ConnectionString;
    }

    class ZenderNames 
    {
        private static string KKRock = "";

        public static string KkRock
        {
            get { return KKRock; }
            set { KKRock = value; }
        }

        private static string KKRockOmschrijving = "";

        public static string KkRockOmschrijving
        {
            get { return KKRockOmschrijving; }
            set { KKRockOmschrijving = value; }
        }
    }

    class Zenders
    {
        public void GetKKRock()
        {
            var zenderquery = "select zendernaam, omschrijving from zenders where zenderId=3;";

            var conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionVariables.cs);
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(zenderquery, conn);

            conn.Open();
            var queryResults = cmd.ExecuteReader();//Return an object so first check for null
            if (queryResults.HasRows)
            {
                queryResults.Read();
                ZenderNames.KkRock = queryResults.GetString(0);
                ZenderNames.KkRockOmschrijving = queryResults.GetString(1);
            }
            else
            {
                // Else make id = "" so you can later check it.
                Console.WriteLine(queryResults.GetString(0) + queryResults.GetString(1) + "Geen resultaat");
                ZenderNames.KkRock = "Geen zender aanwezig";
                ZenderNames.KkRockOmschrijving = "Geen zender omschrijving";
            }
            queryResults.Close();
            conn.Close();
        }
    }
}
