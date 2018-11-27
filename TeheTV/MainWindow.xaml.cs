﻿using System;
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

namespace TeheTV
{
    public partial class MainWindow : Window
    {
        // add all pages here
        private static Page createNewAccount;
        private static Page initialize;
        private static Page navigator;
        private static Page nowPlaying;
        private static Page options;
        private static Page parentSettings;
        private static Page profileSelector;
        private static Page splashScreen;

        public MainWindow()
        {
            InitializeComponent();

            // instantiate all pages here
            createNewAccount = new pages.CreateNewAccount(this);
            initialize       = new pages.Initialize(this);
            navigator        = new pages.Navigator(this);
            nowPlaying       = new pages.NowPlaying(this);
            options          = new pages.Options(this);
            parentSettings   = new pages.ParentSettings(this);
            profileSelector  = new pages.ProfileSelector(this);
            splashScreen     = new pages.SplashPage(this);

            // this is the first screen that loads, do not change
            ScreenFrame.NavigationService.Navigate(splashScreen);
        }
        
        private void dragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        
        private void closeApp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void minimizeApp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// This can be used statically from any page as long as you pass it the "app" instance variable.
        /// Use this to change the screen frame
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="screen"></param>
        public static void changeScreen(MainWindow instance, SCREEN screen)
        {
            if (screen == SCREEN.CreateNewAccount)
                instance.ScreenFrame.NavigationService.Navigate(createNewAccount);
            else if (screen == SCREEN.Initialize)
                instance.ScreenFrame.NavigationService.Navigate(initialize);
            else if (screen == SCREEN.Navigator)
                instance.ScreenFrame.NavigationService.Navigate(navigator);
            else if (screen == SCREEN.NowPlaying)
                instance.ScreenFrame.NavigationService.Navigate(nowPlaying);
            else if (screen == SCREEN.Options)
                instance.ScreenFrame.NavigationService.Navigate(options);
            else if (screen == SCREEN.ParentSettings)
                instance.ScreenFrame.NavigationService.Navigate(parentSettings);
            else if (screen == SCREEN.ProfileSelector)
                instance.ScreenFrame.NavigationService.Navigate(profileSelector);
        }
        public static void changeScreen(MainWindow instance, Page nextPage)
        {
            instance.ScreenFrame.NavigationService.Navigate(nextPage);
        }
    }
}