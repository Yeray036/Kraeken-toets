using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Kraeken_en_Krønen_HKS_FO.UserControls
{
    /// <summary>
    /// Interaction logic for NewZenderLayout.xaml
    /// </summary>
    public partial class NewZenderLayout : UserControl
    {

        private static bool isClicked = false;

        public static bool IsClicked
        {
            get { return isClicked; }
            set { isClicked = value; }
        }

        public NewZenderLayout()
        {
            InitializeComponent();
        }

        private void VerwijderClick(object sender, RoutedEventArgs e)
        {
            isClicked = true;
        }
    }
}
