using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace HelloWindows_Phone8
{
    public partial class InstructionPage : PhoneApplicationPage
    {

        public InstructionPage()
        {
            InitializeComponent();
        }

        private void ReturnMenuClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MenuPage.xaml", UriKind.Relative));
        }

    }
}