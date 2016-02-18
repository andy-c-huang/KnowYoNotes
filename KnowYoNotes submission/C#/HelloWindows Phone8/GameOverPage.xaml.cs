using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace HelloWindows_Phone8
{
    public partial class GameOverPage : PhoneApplicationPage
    {
        public GameOverPage()
        {
            InitializeComponent();
            //myMediaElement.Source = new Uri("/Assets/trumpet_fail.mp3", UriKind.RelativeOrAbsolute);
            //myMediaElement.Play();
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MenuPage.xaml", UriKind.Relative));
        }

    }
}