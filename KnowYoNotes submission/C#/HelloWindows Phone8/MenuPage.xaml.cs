using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HelloWindows_Phone8.Resources;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO.IsolatedStorage;

namespace HelloWindows_Phone8
{
    public partial class Page1 : PhoneApplicationPage
    {

        private void HighScoreInitialize()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            // txtInput is a TextBox defined in XAML.
            if (!settings.Contains("HighScoreData"))
            {
                settings.Add("HighScoreData", 0);
            }
            settings.Save();
        }


        public Page1()
        {
            InitializeComponent();
            int CurrentHighScore = (int)IsolatedStorageSettings.ApplicationSettings["HighScoreData"];
            string CurrentHighScoreString = "The current high score is: " + CurrentHighScore.ToString();
            Scoreboard.Text = CurrentHighScoreString;
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void InstructionClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InstructionPage.xaml", UriKind.Relative));
        }
    }
}