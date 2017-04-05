using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlameGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CaseSelectionPage : Page
    {
        public CaseSelectionPage()
        {
            this.InitializeComponent();
        }

        private void btnDogCase_Click(object sender, RoutedEventArgs e)
        {
            CaseIdStatic.CaseId = 1;
            StartGame();
        }

        private void btnSandwichCase_Click(object sender, RoutedEventArgs e)
        {
            CaseIdStatic.CaseId = 2;
            StartGame();
        }

        private void btnBlackmailCase_Click(object sender, RoutedEventArgs e)
        {
            CaseIdStatic.CaseId = 3;
            StartGame();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void StartGame()
        {
            this.Frame.Navigate(typeof(CaseDescriptionPage));
        }
    }
}
