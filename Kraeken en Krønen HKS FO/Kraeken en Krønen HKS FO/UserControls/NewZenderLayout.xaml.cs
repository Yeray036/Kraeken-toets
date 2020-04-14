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
        Zenders zenderClass = new Zenders();

        public NewZenderLayout()
        {
            InitializeComponent();
        }

        private void VerwijderClick(object sender, RoutedEventArgs e)
        {
            int currentZenderId;
            string currentZender;
            currentZender = this.Name.Remove(0, 6);
            currentZenderId = Int32.Parse(currentZender);

            MessageBoxResult result = MessageBox.Show("Wil je deze zender verwijderen?", $"Verwijder zender: {currentZenderId}", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    zenderClass.DeleteZenderFromDb(currentZenderId);
                    ((Panel)this.Parent).Children.Remove(this);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
