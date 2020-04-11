using Kraeken_en_Krønen_HKS_FO.UserControls;
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

namespace Kraeken_en_Krønen_HKS_FO
{
    /// <summary>
    /// Interaction logic for ZendersPage.xaml
    /// </summary>
    /// 

    class ZenderInformation
    {
        private static string ZenderTitel = "";

        public static string ZenderTitelText
        {
            get { return ZenderTitel; }
            set { ZenderTitel = value; }
        }

        private static string ZenderOmschrijving = "";

        public static string ZenderOmschrijvingText
        {
            get { return ZenderOmschrijving; }
            set { ZenderOmschrijving = value; }
        }
    }

    public partial class ZendersPage : Page
    {
        Zenders zendersClass = new Zenders();

        int gridCount = 0;

        public ZendersPage()
        {
            InitializeComponent();

            zendersClass.GetAllChannels();

            zendersClass.GetKKRock();
            KKRockZenderNaam.Content = ZenderNames.MusicZenders[0];
            KKRockOmschrijving.Content = ZenderNames.KkRockOmschrijving;

            zendersClass.GetKKSoul();
            KKSoulZenderNaam.Content = ZenderNames.MusicZenders[1];
            KKSoulOmschrijving.Content = ZenderNames.KkSoulOmschrijving;

            zendersClass.GetKKLounge();
            KKLoungeZenderNaam.Content = ZenderNames.KkLounge;
            KKLoungeOmschrijving.Content = ZenderNames.KkLoungeOmschrijving;

            zendersClass.GetKKAlternative();
            KKAlternativeZenderNaam.Content = ZenderNames.KkAlternative;
            KKAlternativeOmschrijving.Content = ZenderNames.KkAlternativeOmschrijving;

            zendersClass.GetKKCountry();
            KKCountryZenderNaam.Content = ZenderNames.KkCountry;
            KKCountryOmschrijving.Content = ZenderNames.KkCountryOmschrijving;

            zendersClass.GetKKGrasshopper();
            KKGrasshopperZenderNaam.Content = ZenderNames.KkGrasshoper;
            KKGrasshopperOmschrijving.Content = ZenderNames.KkGrasshopperOmschrijving;

            zendersClass.GetKKHipHop();
            KKHipHopZenderNaam.Content = ZenderNames.KkHipHop;
            KKHipHopOmschrijving.Content = ZenderNames.KkHipHopOmschrijving;

            zendersClass.GetKKMetal();
            KKMetalZenderNaam.Content = ZenderNames.KkMetal;
            KKMetalOmschrijving.Content = ZenderNames.KkMetalOmschrijving;

            zendersClass.GetKKWorkout();
            KKWorkoutZenderNaam.Content = ZenderNames.KkWorkout;
            KKWorkoutOmschrijving.Content = ZenderNames.KkWorkoutOmschrijving;
        }

        private void CreateNewZender(object sender, RoutedEventArgs e)
        {
            if (NewZenderNaam.Text != String.Empty && NewZenderOmschrijving.Text != String.Empty)
            {
                NewZenderLayout newZenderLayout = new NewZenderLayout();

                if (gridCount <= 2)
                {
                    ZenderInformation.ZenderTitelText = NewZenderNaam.Text;
                    ZenderInformation.ZenderOmschrijvingText = NewZenderOmschrijving.Text;
                    newZenderLayout.PlaceZenderInfoInLayout();
                    ExtraZender.Children.Add(newZenderLayout);
                    int totalcount = gridCount + 1;
                    gridCount = totalcount;
                }
                else
                {
                    ZenderInformation.ZenderTitelText = NewZenderNaam.Text;
                    ZenderInformation.ZenderOmschrijvingText = NewZenderOmschrijving.Text;
                    newZenderLayout.PlaceZenderInfoInLayout();
                    ExtraZender2.Children.Add(newZenderLayout);
                }
            }
            else
            {
                MessageBox.Show("Geen zender informatie");
            }
        }
    }
}

