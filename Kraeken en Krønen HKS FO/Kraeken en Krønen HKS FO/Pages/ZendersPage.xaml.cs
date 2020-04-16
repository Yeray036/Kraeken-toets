using Kraeken_en_Krønen_HKS_FO.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
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

        private static int i = 0;

        public static int y
        {
            get { return i; }
            set { i = value; }
        }

        private static int ZenderCount = 0;

        public static int ZenderCounter
        {
            get { return ZenderCount; }
            set { ZenderCount = value; }
        }
    }

    public partial class ZendersPage : Page
    {
        Zenders zendersClass = new Zenders();

        int gridCount = 0;
        int totalCount;

        public ZendersPage()
        {
            InitializeComponent();
            try
            {
                zendersClass.GetAllChannels();
                PlaceZendersInGrid();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void CreateNewZender(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NewZenderNaam.Text != string.Empty && NewZenderOmschrijving.Text != string.Empty)
                {
                    ZenderInformation.ZenderTitelText = NewZenderNaam.Text;
                    ZenderInformation.ZenderOmschrijvingText = NewZenderOmschrijving.Text;
                    zendersClass.UpdateDbWithNewZenders();
                    ExtraZender.Children.Clear();
                    ExtraZender1.Children.Clear();
                    ExtraZender2.Children.Clear();
                    ExtraZender3.Children.Clear();
                    ExtraZender4.Children.Clear();
                    ExtraZender5.Children.Clear();
                    PlaceZendersInGrid();
                    NewZenderNaam.Text = String.Empty;
                    NewZenderOmschrijving.Text = String.Empty;
                }
                else
                {
                    MessageBox.Show("Geen zender informatie ingevoerd");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void PlaceZendersInGrid()
        {
            try
            {
                zendersClass.GetAllChannels();

                foreach (var zender in ZenderNames.MusicZenders)
                {
                    ZenderInformation.ZenderCounter++;
                }
                while (gridCount < ZenderInformation.ZenderCounter)
                {
                    if (gridCount <= ZenderInformation.ZenderCounter)
                    {
                        for (ZenderInformation.y = 0; ZenderInformation.y < 3; ZenderInformation.y++)
                        {
                            NewZenderLayout newZenderLayout = new NewZenderLayout();
                            newZenderLayout.NewZender.Text = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                            newZenderLayout.NewOmschrijving.Text = ZenderNames.Musicdescription[ZenderInformation.y].ToString();
                            newZenderLayout.Name = "zender" + ZenderNames.ZendersId[ZenderInformation.y];
                            newZenderLayout.Tag = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                            ExtraZender.Children.Add(newZenderLayout);
                            totalCount = gridCount + 1;
                            gridCount = totalCount;
                        }
                        if (gridCount <= ZenderInformation.ZenderCounter)
                        {
                            for (ZenderInformation.y = 3; ZenderInformation.y < 6; ZenderInformation.y++)
                            {
                                NewZenderLayout newZenderLayout = new NewZenderLayout();
                                newZenderLayout.NewZender.Text = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                                newZenderLayout.NewOmschrijving.Text = ZenderNames.Musicdescription[ZenderInformation.y].ToString();
                                newZenderLayout.Name = "zender" + ZenderNames.ZendersId[ZenderInformation.y];
                                newZenderLayout.Tag = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                                ExtraZender1.Children.Add(newZenderLayout);
                                totalCount = gridCount + 1;
                                gridCount = totalCount;
                            }
                            if (gridCount <= ZenderInformation.ZenderCounter)
                            {
                                for (ZenderInformation.y = 6; ZenderInformation.y < 9; ZenderInformation.y++)
                                {
                                    NewZenderLayout newZenderLayout = new NewZenderLayout();
                                    newZenderLayout.NewZender.Text = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                                    newZenderLayout.NewOmschrijving.Text = ZenderNames.Musicdescription[ZenderInformation.y].ToString();
                                    newZenderLayout.Name = "zender" + ZenderNames.ZendersId[ZenderInformation.y];
                                    newZenderLayout.Tag = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                                    ExtraZender2.Children.Add(newZenderLayout);
                                    totalCount = gridCount + 1;
                                    gridCount = totalCount;
                                }
                                if (gridCount <= ZenderInformation.ZenderCounter)
                                {
                                    for (ZenderInformation.y = 9; ZenderInformation.y < 12; ZenderInformation.y++)
                                    {
                                        NewZenderLayout newZenderLayout = new NewZenderLayout();
                                        newZenderLayout.NewZender.Text = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                                        newZenderLayout.NewOmschrijving.Text = ZenderNames.Musicdescription[ZenderInformation.y].ToString();
                                        newZenderLayout.Name = "zender" + ZenderNames.ZendersId[ZenderInformation.y];
                                        newZenderLayout.Tag = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                                        ExtraZender3.Children.Add(newZenderLayout);
                                        totalCount = gridCount + 1;
                                        gridCount = totalCount;
                                    }
                                    if (gridCount <= ZenderInformation.ZenderCounter)
                                    {
                                        for (ZenderInformation.y = 12; ZenderInformation.y < 15; ZenderInformation.y++)
                                        {
                                            NewZenderLayout newZenderLayout = new NewZenderLayout();
                                            newZenderLayout.NewZender.Text = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                                            newZenderLayout.NewOmschrijving.Text = ZenderNames.Musicdescription[ZenderInformation.y].ToString();
                                            newZenderLayout.Name = "zender" + ZenderNames.ZendersId[ZenderInformation.y];
                                            newZenderLayout.Tag = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                                            ExtraZender4.Children.Add(newZenderLayout);
                                            totalCount = gridCount + 1;
                                            gridCount = totalCount;
                                        }
                                        if (gridCount <= ZenderInformation.ZenderCounter)
                                        {
                                            for (ZenderInformation.y = 15; ZenderInformation.y < 18; ZenderInformation.y++)
                                            {
                                                NewZenderLayout newZenderLayout = new NewZenderLayout();
                                                newZenderLayout.NewZender.Text = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                                                newZenderLayout.NewOmschrijving.Text = ZenderNames.Musicdescription[ZenderInformation.y].ToString();
                                                newZenderLayout.Name = "zender" + ZenderNames.ZendersId[ZenderInformation.y];
                                                newZenderLayout.Tag = ZenderNames.MusicZenders[ZenderInformation.y].ToString();
                                                ExtraZender5.Children.Add(newZenderLayout);
                                                totalCount = gridCount + 1;
                                                gridCount = totalCount;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
/*
if (NewZenderNaam.Text != String.Empty && NewZenderOmschrijving.Text != String.Empty)
{
    if (gridCount <= 11)
    {
        for (i = 0; i < 12; i++)
        {
            NewZenderLayout newZenderLayout = new NewZenderLayout();
            newZenderLayout.NewZender.Text = ZenderNames.MusicZenders[i].ToString();
            newZenderLayout.Name = "zender" + i;
            ExtraZender3.Children.Add(newZenderLayout);
            totalCount = gridCount + 1;
            gridCount = totalCount;
        }
    }
    else if (gridCount <= 14)
    {
        for (i = 0; i < 15; i++)
        {
            NewZenderLayout newZenderLayout = new NewZenderLayout();
            newZenderLayout.NewZender.Text = ZenderNames.MusicZenders[i].ToString();
            newZenderLayout.Name = "zender" + i;
            ExtraZender4.Children.Add(newZenderLayout);
            totalCount = gridCount + 1;
            gridCount = totalCount;
        }
    }
    else if (gridCount <= 17)
    {
        for (i = 0; i < 18; i++)
        {
            NewZenderLayout newZenderLayout = new NewZenderLayout();
            newZenderLayout.NewZender.Text = ZenderNames.MusicZenders[i].ToString();
            newZenderLayout.Name = "zender" + i;
            ExtraZender5.Children.Add(newZenderLayout);
            totalCount = gridCount + 1;
            gridCount = totalCount;
        }
    }
}

    */



/*
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





    <!------------------OLD XAML PLUS OLD CODE--------------------!>

     <Grid Grid.Row="1" Margin="0,20,0,0" HorizontalAlignment="Center" VerticalAlignment="Top">
            <StackPanel Margin="20,0" Orientation="Horizontal">
                <Border HorizontalAlignment="Left" BorderThickness="2px" BorderBrush="#FF62626A">
                    <StackPanel HorizontalAlignment="Left" Orientation="Vertical" x:Name="KKSoul" Margin="5,0,5,5">
                        <Label FontSize="20px" Foreground="White" x:Name="KKSoulZenderNaam"/>
                        <Label FontSize="20px" Foreground="White" x:Name="KKSoulOmschrijving"/>
                        <Button FontSize="20px" Foreground="White" Content="programmaoverzicht"/>
                        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,5,0,0">
                            <Button FontSize="20px" Foreground="White" Content="wijzig" Margin="0,0,5,0"/>
                            <Button FontSize="20px" Foreground="White" Content="verwijder"/>
                        </StackPanel>
                    </StackPanel>
                </Border>

                <Border HorizontalAlignment="Center" BorderThickness="2px" BorderBrush="#FF62626A">
                    <StackPanel HorizontalAlignment="Left" Orientation="Vertical" x:Name="KKRock" Margin="5,0,5,5">
                        <Label FontSize="20px" Foreground="White" x:Name="KKRockZenderNaam" Margin="0"/>
                        <Label FontSize="20px" Foreground="White" x:Name="KKRockOmschrijving" Margin="0"/>
                        <Button FontSize="20px" Foreground="White" Content="programmaoverzicht"/>
                        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,5,0,0">
                            <Button FontSize="20px" Foreground="White" Content="wijzig" Margin="0,0,5,0"/>
                            <Button FontSize="20px" Foreground="White" Content="verwijder"/>
                        </StackPanel>
                    </StackPanel>
                </Border>

                <Border HorizontalAlignment="Right" BorderThickness="2px" BorderBrush="#FF62626A">
                    <StackPanel HorizontalAlignment="Left" Orientation="Vertical" x:Name="KKLounge" Margin="5,0,5,5">
                        <Label FontSize="20px" Foreground="White" x:Name="KKLoungeZenderNaam"/>
                        <Label FontSize="20px" Foreground="White" x:Name="KKLoungeOmschrijving"/>
                        <Button FontSize="20px" Foreground="White" Content="programmaoverzicht"/>
                        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,5,0,0">
                            <Button FontSize="20px" Foreground="White" Content="wijzig" Margin="0,0,5,0"/>
                            <Button FontSize="20px" Foreground="White" Content="verwijder"/>
                        </StackPanel>
                    </StackPanel>
                </Border>
            </StackPanel>
        </Grid>

        <Grid Grid.Row="2" VerticalAlignment="Top" HorizontalAlignment="Center">
            <StackPanel Margin="20,0" Orientation="Horizontal">
                <Border HorizontalAlignment="Left" BorderThickness="2px" BorderBrush="#FF62626A">
                    <StackPanel HorizontalAlignment="Left" Orientation="Vertical" x:Name="KKAlternative" Margin="5,0,5,5">
                        <Label FontSize="20px" Foreground="White" x:Name="KKAlternativeZenderNaam"/>
                        <Label FontSize="20px" Foreground="White" x:Name="KKAlternativeOmschrijving"/>
                        <Button FontSize="20px" Foreground="White" Content="programmaoverzicht"/>
                        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,5,0,0">
                            <Button FontSize="20px" Foreground="White" Content="wijzig" Margin="0,0,5,0"/>
                            <Button FontSize="20px" Foreground="White" Content="verwijder"/>
                        </StackPanel>
                    </StackPanel>
                </Border>

                <Border HorizontalAlignment="Center" BorderThickness="2px" BorderBrush="#FF62626A">
                    <StackPanel HorizontalAlignment="Left" Orientation="Vertical" x:Name="KKCountry" Margin="5,0,5,5">
                        <Label FontSize="20px" Foreground="White" x:Name="KKCountryZenderNaam" Margin="0"/>
                        <Label FontSize="20px" Foreground="White" x:Name="KKCountryOmschrijving" Margin="0"/>
                        <Button FontSize="20px" Foreground="White" Content="programmaoverzicht"/>
                        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,5,0,0">
                            <Button FontSize="20px" Foreground="White" Content="wijzig" Margin="0,0,5,0"/>
                            <Button FontSize="20px" Foreground="White" Content="verwijder"/>
                        </StackPanel>
                    </StackPanel>
                </Border>

                <Border HorizontalAlignment="Right" BorderThickness="2px" BorderBrush="#FF62626A">
                    <StackPanel HorizontalAlignment="Left" Orientation="Vertical" x:Name="KKGrasshopper" Margin="5,0,5,5">
                        <Label FontSize="20px" Foreground="White" x:Name="KKGrasshopperZenderNaam"/>
                        <Label FontSize="20px" Foreground="White" x:Name="KKGrasshopperOmschrijving"/>
                        <Button FontSize="20px" Foreground="White" Content="programmaoverzicht"/>
                        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,5,0,0">
                            <Button FontSize="20px" Foreground="White" Content="wijzig" Margin="0,0,5,0"/>
                            <Button FontSize="20px" Foreground="White" Content="verwijder"/>
                        </StackPanel>
                    </StackPanel>
                </Border>
            </StackPanel>
        </Grid>

        <Grid Grid.Row="3" VerticalAlignment="Top" HorizontalAlignment="Center">
            <StackPanel Margin="20,0" Orientation="Horizontal">
                <Border HorizontalAlignment="Left" BorderThickness="2px" BorderBrush="#FF62626A">
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

                <Border HorizontalAlignment="Center" BorderThickness="2px" BorderBrush="#FF62626A">
                    <StackPanel HorizontalAlignment="Left" Orientation="Vertical" x:Name="KKMetal" Margin="5,0,5,5">
                        <Label FontSize="20px" Foreground="White" x:Name="KKMetalZenderNaam" Margin="0"/>
                        <Label FontSize="20px" Foreground="White" x:Name="KKMetalOmschrijving" Margin="0"/>
                        <Button FontSize="20px" Foreground="White" Content="programmaoverzicht"/>
                        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,5,0,0">
                            <Button FontSize="20px" Foreground="White" Content="wijzig" Margin="0,0,5,0"/>
                            <Button FontSize="20px" Foreground="White" Content="verwijder"/>
                        </StackPanel>
                    </StackPanel>
                </Border>

                <Border HorizontalAlignment="Right" BorderThickness="2px" BorderBrush="#FF62626A">
                    <StackPanel HorizontalAlignment="Left" Orientation="Vertical" x:Name="KKWorkout" Margin="5,0,5,5">
                        <Label FontSize="20px" Foreground="White" x:Name="KKWorkoutZenderNaam"/>
                        <Label FontSize="20px" Foreground="White" x:Name="KKWorkoutOmschrijving"/>
                        <Button FontSize="20px" Foreground="White" Content="programmaoverzicht"/>
                        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,5,0,0">
                            <Button FontSize="20px" Foreground="White" Content="wijzig" Margin="0,0,5,0"/>
                            <Button FontSize="20px" Foreground="White" Content="verwijder"/>
                        </StackPanel>
                    </StackPanel>
                </Border>
            </StackPanel>
        </Grid>


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
     */

