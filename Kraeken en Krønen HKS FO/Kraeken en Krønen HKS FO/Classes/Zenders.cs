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

        private static string KKSoul = "";

        public static string KkSoul
        {
            get { return KKSoul; }
            set { KKSoul = value; }
        }

        private static string KKSoulOmschrijving = "";

        public static string KkSoulOmschrijving
        {
            get { return KKSoulOmschrijving; }
            set { KKSoulOmschrijving = value; }
        }

        private static string KKLounge = "";

        public static string KkLounge
        {
            get { return KKLounge; }
            set { KKLounge = value; }
        }

        private static string KKLoungeOmschrijving = "";

        public static string KkLoungeOmschrijving
        {
            get { return KKLoungeOmschrijving; }
            set { KKLoungeOmschrijving = value; }
        }

        private static string KKAlternative = "";

        public static string KkAlternative
        {
            get { return KKAlternative; }
            set { KKAlternative = value; }
        }

        private static string KKAlternativeOmschrijving = "";

        public static string KkAlternativeOmschrijving
        {
            get { return KKAlternativeOmschrijving; }
            set { KKAlternativeOmschrijving = value; }
        }

        private static string KKCountry = "";

        public static string KkCountry
        {
            get { return KKCountry; }
            set { KKCountry = value; }
        }

        private static string KKCountryOmschrijving = "";

        public static string KkCountryOmschrijving
        {
            get { return KKCountryOmschrijving; }
            set { KKCountryOmschrijving = value; }
        }

        private static string KKGrasshopper = "";

        public static string KkGrasshoper
        {
            get { return KKGrasshopper; }
            set { KKGrasshopper = value; }
        }

        private static string KKGrasshopperOmschrijving = "";

        public static string KkGrasshopperOmschrijving
        {
            get { return KKGrasshopperOmschrijving; }
            set { KKGrasshopperOmschrijving = value; }
        }

        private static string KKHipHop = "";

        public static string KkHipHop
        {
            get { return KKHipHop; }
            set { KKHipHop = value; }
        }

        private static string KKHipHopOmschrijving = "";

        public static string KkHipHopOmschrijving
        {
            get { return KKHipHopOmschrijving; }
            set { KKHipHopOmschrijving = value; }
        }

        private static string KKMetal = "";

        public static string KkMetal
        {
            get { return KKMetal; }
            set { KKMetal = value; }
        }

        private static string KKMetalOmschrijving = "";

        public static string KkMetalOmschrijving
        {
            get { return KKMetalOmschrijving; }
            set { KKMetalOmschrijving = value; }
        }

        private static string KKWorkout = "";

        public static string KkWorkout
        {
            get { return KKWorkout; }
            set { KKWorkout = value; }
        }

        private static string KKWorkoutOmschrijving = "";

        public static string KkWorkoutOmschrijving
        {
            get { return KKWorkoutOmschrijving; }
            set { KKWorkoutOmschrijving = value; }
        }

        private static List<string> MusicChannels = new List<string>();

        public static List<string> MusicZenders
        {
            get { return MusicChannels; }
            set { MusicChannels = value; }
        }
    }

    class Zenders
    {
        MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionVariables.cs);

        public void GetAllChannels()
        {
            var zenderquery = "select zendernaam, omschrijving from zenders";

            var cmd = new MySqlCommand(zenderquery, conn);

            conn.Open();
            var queryresult = cmd.ExecuteReader();
            if (queryresult.HasRows)
            {
                while (queryresult.Read())
                {
                    ZenderNames.MusicZenders.Add(queryresult.GetString(0).ToString());
                }
            }
            conn.Close();
        }

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

        public void GetKKSoul()
        {
            var zenderquery = "select zendernaam, omschrijving from zenders where zenderId=4;";

            var conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionVariables.cs);
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(zenderquery, conn);

            conn.Open();
            var queryResults = cmd.ExecuteReader();//Return an object so first check for null
            if (queryResults.HasRows)
            {
                queryResults.Read();
                ZenderNames.KkSoul = queryResults.GetString(0);
                ZenderNames.KkSoulOmschrijving = queryResults.GetString(1);
            }
            else
            {
                // Else make id = "" so you can later check it.
                Console.WriteLine(queryResults.GetString(0) + queryResults.GetString(1) + "Geen resultaat");
                ZenderNames.KkSoul = "Geen zender aanwezig";
                ZenderNames.KkSoulOmschrijving = "Geen zender omschrijving";
            }
            queryResults.Close();
            conn.Close();
        }

        public void GetKKAlternative()
        {
            var zenderquery = "select zendernaam, omschrijving from zenders where zenderId=7;";

            var conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionVariables.cs);
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(zenderquery, conn);

            conn.Open();
            var queryResults = cmd.ExecuteReader();//Return an object so first check for null
            if (queryResults.HasRows)
            {
                queryResults.Read();
                ZenderNames.KkAlternative = queryResults.GetString(0);
                ZenderNames.KkAlternativeOmschrijving = queryResults.GetString(1);
            }
            else
            {
                // Else make id = "" so you can later check it.
                Console.WriteLine(queryResults.GetString(0) + queryResults.GetString(1) + "Geen resultaat");
                ZenderNames.KkAlternative = "Geen zender aanwezig";
                ZenderNames.KkAlternativeOmschrijving = "Geen zender omschrijving";
            }
            queryResults.Close();
            conn.Close();
        }

        public void GetKKLounge()
        {
            var zenderquery = "select zendernaam, omschrijving from zenders where zenderId=5;";

            var conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionVariables.cs);
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(zenderquery, conn);

            conn.Open();
            var queryResults = cmd.ExecuteReader();//Return an object so first check for null
            if (queryResults.HasRows)
            {
                queryResults.Read();
                ZenderNames.KkLounge = queryResults.GetString(0);
                ZenderNames.KkLoungeOmschrijving = queryResults.GetString(1);
            }
            else
            {
                // Else make id = "" so you can later check it.
                Console.WriteLine(queryResults.GetString(0) + queryResults.GetString(1) + "Geen resultaat");
                ZenderNames.KkLounge = "Geen zender aanwezig";
                ZenderNames.KkLoungeOmschrijving = "Geen zender omschrijving";
            }
            queryResults.Close();
            conn.Close();
        }

        public void GetKKCountry()
        {
            var zenderquery = "select zendernaam, omschrijving from zenders where zenderId=8;";

            var conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionVariables.cs);
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(zenderquery, conn);

            conn.Open();
            var queryResults = cmd.ExecuteReader();//Return an object so first check for null
            if (queryResults.HasRows)
            {
                queryResults.Read();
                ZenderNames.KkCountry = queryResults.GetString(0);
                ZenderNames.KkCountryOmschrijving = queryResults.GetString(1);
            }
            else
            {
                // Else make id = "" so you can later check it.
                Console.WriteLine(queryResults.GetString(0) + queryResults.GetString(1) + "Geen resultaat");
                ZenderNames.KkCountry = "Geen zender aanwezig";
                ZenderNames.KkCountryOmschrijving = "Geen zender omschrijving";
            }
            queryResults.Close();
            conn.Close();
        }

        public void GetKKGrasshopper()
        {
            var zenderquery = "select zendernaam, omschrijving from zenders where zenderId=9;";

            var conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionVariables.cs);
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(zenderquery, conn);

            conn.Open();
            var queryResults = cmd.ExecuteReader();//Return an object so first check for null
            if (queryResults.HasRows)
            {
                queryResults.Read();
                ZenderNames.KkGrasshoper = queryResults.GetString(0);
                ZenderNames.KkGrasshopperOmschrijving = queryResults.GetString(1);
            }
            else
            {
                // Else make id = "" so you can later check it.
                Console.WriteLine(queryResults.GetString(0) + queryResults.GetString(1) + "Geen resultaat");
                ZenderNames.KkGrasshoper = "Geen zender aanwezig";
                ZenderNames.KkGrasshopperOmschrijving = "Geen zender omschrijving";
            }
            queryResults.Close();
            conn.Close();
        }

        public void GetKKHipHop()
        {
            var zenderquery = "select zendernaam, omschrijving from zenders where zenderId=10;";

            var conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionVariables.cs);
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(zenderquery, conn);

            conn.Open();
            var queryResults = cmd.ExecuteReader();//Return an object so first check for null
            if (queryResults.HasRows)
            {
                queryResults.Read();
                ZenderNames.KkHipHop = queryResults.GetString(0);
                ZenderNames.KkHipHopOmschrijving = queryResults.GetString(1);
            }
            else
            {
                // Else make id = "" so you can later check it.
                Console.WriteLine(queryResults.GetString(0) + queryResults.GetString(1) + "Geen resultaat");
                ZenderNames.KkHipHop = "Geen zender aanwezig";
                ZenderNames.KkHipHopOmschrijving = "Geen zender omschrijving";
            }
            queryResults.Close();
            conn.Close();
        }

        public void GetKKMetal()
        {
            var zenderquery = "select zendernaam, omschrijving from zenders where zenderId=11;";

            var conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionVariables.cs);
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(zenderquery, conn);

            conn.Open();
            var queryResults = cmd.ExecuteReader();//Return an object so first check for null
            if (queryResults.HasRows)
            {
                queryResults.Read();
                ZenderNames.KkMetal = queryResults.GetString(0);
                ZenderNames.KkMetalOmschrijving = queryResults.GetString(1);
            }
            else
            {
                // Else make id = "" so you can later check it.
                Console.WriteLine(queryResults.GetString(0) + queryResults.GetString(1) + "Geen resultaat");
                ZenderNames.KkMetal = "Geen zender aanwezig";
                ZenderNames.KkMetalOmschrijving = "Geen zender omschrijving";
            }
            queryResults.Close();
            conn.Close();
        }

        public void GetKKWorkout()
        {
            var zenderquery = "select zendernaam, omschrijving from zenders where zenderId=12;";

            var conn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionVariables.cs);
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(zenderquery, conn);

            conn.Open();
            var queryResults = cmd.ExecuteReader();//Return an object so first check for null
            if (queryResults.HasRows)
            {
                queryResults.Read();
                ZenderNames.KkWorkout = queryResults.GetString(0);
                ZenderNames.KkWorkoutOmschrijving = queryResults.GetString(1);
            }
            else
            {
                // Else make id = "" so you can later check it.
                Console.WriteLine(queryResults.GetString(0) + queryResults.GetString(1) + "Geen resultaat");
                ZenderNames.KkWorkout = "Geen zender aanwezig";
                ZenderNames.KkWorkoutOmschrijving = "Geen zender omschrijving";
            }
            queryResults.Close();
            conn.Close();
        }
    }
}
