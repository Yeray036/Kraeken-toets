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

            NewZender1.Visibility = Visibility.Hidden;
            NewZender2.Visibility = Visibility.Hidden;
            NewZender3.Visibility = Visibility.Hidden;

            zendersClass.GetKKRock();
            KKRockZenderNaam.Content = ZenderNames.KkRock;
            KKRockOmschrijving.Content = ZenderNames.KkRockOmschrijving;

            zendersClass.GetKKSoul();
            KKSoulZenderNaam.Content = ZenderNames.KkSoul;
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
                StackPanel stackpanel = new StackPanel();
                stackpanel.Orientation = Orientation.Horizontal;

                Border border = new Border();
                border.HorizontalAlignment = HorizontalAlignment.Center;
                border.BorderThickness = new Thickness(2, 2, 2, 2);
                border.BorderBrush = new SolidColorBrush(new Color { R = 98, G = 98, B = 106, A = byte.MaxValue });

                StackPanel stackpanel2 = new StackPanel();
                stackpanel2.HorizontalAlignment = HorizontalAlignment.Center;
                stackpanel2.Orientation = Orientation.Vertical;
                stackpanel2.Margin = new Thickness(5, 0, 5, 5);

                Label newLabel = new Label();
                newLabel.FontSize = 20;
                newLabel.Foreground = Brushes.White;
                newLabel.Name = NewZenderNaam.Text + "ZenderNaam";
                newLabel.Content = NewZenderNaam.Text;

                var newLabel2 = new Label();
                newLabel2.FontSize = 20;
                newLabel2.Foreground = Brushes.White;
                newLabel2.Name = NewZenderOmschrijving.Text + "Omschrijving";
                newLabel2.Content = NewZenderOmschrijving.Text;

                stackpanel2.Children.Add(newLabel);
                stackpanel2.Children.Add(newLabel2);
                border.Child = stackpanel2;
                stackpanel.Children.Add(border);
                Grid5.Children.Add(stackpanel);


            }
            else
            {
                MessageBox.Show("Geen zender informatie");
            }
        }
    }
}

/*<Border HorizontalAlignment="Left" BorderThickness="2px" BorderBrush="#FF62626A">
            <StackPanel HorizontalAlignment="Left" Orientation="Vertical" x:Name="KKHipHop" Margin="5,0,5,5">
                <Label FontSize="20px" Foreground="White" x:Name="KKHipHopZenderNaam"/>
                <Label FontSize="20px" Foreground="White" x:Name="KKHipHopOmschrijving"/>
                <Button FontSize="20px" Foreground="White" Content="programmaoverzicht"/>
                <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,5,0,0">
                    <Button FontSize="20px" Foreground="White" Content="wijzig" Margin="0,0,5,0"/>
                    <Button FontSize="20px" Foreground="White" Content="verwijder"/>
                </StackPanel>
            </StackPanel>
        </Border>


Grid4.Children.Add(new StackPanel
        {
            Orientation = Orientation.Horizontal,
        });
        Grid4.Children.Add(new Border
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            BorderThickness = new Thickness(2, 2, 2, 2),
            BorderBrush = new SolidColorBrush(new Color { R = 98, G = 98, B = 106, A = byte.MaxValue })
        });
        Grid4.Children.Add(new StackPanel
        { 
            HorizontalAlignment = HorizontalAlignment.Left,
            Orientation = Orientation.Vertical,
            Margin = new Thickness(5, 0, 5, 5)
        });
        Grid4.Children.Add(new Label
        { 
            FontSize = 20,
            Foreground = Brushes.White,
            Name = NewZenderNaam.Text + "ZenderNaam",
            Content = NewZenderNaam.Text
        });
        Grid4.Children.Add(new Label
        {
            FontSize = 20,
            Foreground = Brushes.White,
            Name = NewZenderOmschrijving.Text + "Omschrijving",
            Content = NewZenderOmschrijving.Text
        });



     if (NewZender1.Visibility != Visibility.Visible)
                {
                    NewZenderNaam1.Content = NewZenderNaam.Text;
                    NewOmschrijving1.Content = NewZenderOmschrijving.Text;
                    NewZender1.Visibility = Visibility.Visible;
                    NewZenderNaam.Text = String.Empty;
                    NewZenderOmschrijving.Text = String.Empty;
                }
                else if (NewZender2.Visibility != Visibility.Visible)
                {
                    NewZenderNaam2.Content = NewZenderNaam.Text;
                    NewOmschrijving2.Content = NewZenderOmschrijving.Text;
                    NewZender2.Visibility = Visibility.Visible;
                    NewZenderNaam.Text = String.Empty;
                    NewZenderOmschrijving.Text = String.Empty;
                }
                else if (NewZender3.Visibility != Visibility.Visible)
                {
                    NewZenderNaam3.Content = NewZenderNaam.Text;
                    NewOmschrijving3.Content = NewZenderOmschrijving.Text;
                    NewZender3.Visibility = Visibility.Visible;
                    NewZenderNaam.Text = String.Empty;
                    NewZenderOmschrijving.Text = String.Empty;
                }
        */

