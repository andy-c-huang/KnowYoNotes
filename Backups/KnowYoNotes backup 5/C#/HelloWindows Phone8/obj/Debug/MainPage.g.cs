﻿#pragma checksum "C:\Users\Andy\Desktop\KnowYoNotes backup 4\C#\HelloWindows Phone8\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D5600284646E84E8471A97470C0C58F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace HelloWindows_Phone8 {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock ScoreBox;
        
        internal System.Windows.Controls.TextBlock LivesBox;
        
        internal System.Windows.Controls.Image TrebleCleffStaff;
        
        internal System.Windows.Controls.Image CurrentNoteImage;
        
        internal System.Windows.Controls.Button button0;
        
        internal System.Windows.Controls.Button button1;
        
        internal System.Windows.Controls.Button button2;
        
        internal System.Windows.Controls.Button button3;
        
        internal System.Windows.Controls.MediaElement myMediaElement;
        
        internal System.Windows.Controls.Button playSoundButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/HelloWindows%20Phone8;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.ScoreBox = ((System.Windows.Controls.TextBlock)(this.FindName("ScoreBox")));
            this.LivesBox = ((System.Windows.Controls.TextBlock)(this.FindName("LivesBox")));
            this.TrebleCleffStaff = ((System.Windows.Controls.Image)(this.FindName("TrebleCleffStaff")));
            this.CurrentNoteImage = ((System.Windows.Controls.Image)(this.FindName("CurrentNoteImage")));
            this.button0 = ((System.Windows.Controls.Button)(this.FindName("button0")));
            this.button1 = ((System.Windows.Controls.Button)(this.FindName("button1")));
            this.button2 = ((System.Windows.Controls.Button)(this.FindName("button2")));
            this.button3 = ((System.Windows.Controls.Button)(this.FindName("button3")));
            this.myMediaElement = ((System.Windows.Controls.MediaElement)(this.FindName("myMediaElement")));
            this.playSoundButton = ((System.Windows.Controls.Button)(this.FindName("playSoundButton")));
        }
    }
}

