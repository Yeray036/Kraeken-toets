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

            try
            {
                zendersClass.GetAllChannels();

                KKRockZenderNaam.Content = ZenderNames.MusicZenders[0];
                KKRockOmschrijving.Content = ZenderNames.Musicdescription[0];

                KKSoulZenderNaam.Content = ZenderNames.MusicZenders[1];
                KKSoulOmschrijving.Content = ZenderNames.Musicdescription[1];

                KKLoungeZenderNaam.Content = ZenderNames.MusicZenders[2];
                KKLoungeOmschrijving.Content = ZenderNames.Musicdescription[2];

                KKAlternativeZenderNaam.Content = ZenderNames.MusicZenders[3];
                KKAlternativeOmschrijving.Content = ZenderNames.Musicdescription[3];

                KKCountryZenderNaam.Content = ZenderNames.MusicZenders[4];
                KKCountryOmschrijving.Content = ZenderNames.Musicdescription[4];

                KKGrasshopperZenderNaam.Content = ZenderNames.MusicZenders[5];
                KKGrasshopperOmschrijving.Content = ZenderNames.Musicdescription[5];

                KKHipHopZenderNaam.Content = ZenderNames.MusicZenders[6];
                KKHipHopOmschrijving.Content = ZenderNames.Musicdescription[6];

                KKMetalZenderNaam.Content = ZenderNames.MusicZenders[7];
                KKMetalOmschrijving.Content = ZenderNames.Musicdescription[7];

                KKWorkoutZenderNaam.Content = ZenderNames.MusicZenders[8];
                KKWorkoutOmschrijving.Content = ZenderNames.Musicdescription[8];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }        
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

