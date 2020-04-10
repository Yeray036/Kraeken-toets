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
    public partial class ZendersPage : Page
    {
        Zenders zendersClass = new Zenders();

        public ZendersPage()
        {
            InitializeComponent();
            zendersClass.GetKKRock();
            KKRockZenderNaam.Content = ZenderNames.KkRock;
            KKRockzenderOmschrijving.Content = ZenderNames.KkRockOmschrijving;
        }
    }
}
