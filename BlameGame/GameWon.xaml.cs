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
    public sealed partial class GameWon : Page
    {
        public GameWon()
        {
            this.InitializeComponent();
        }

        private void btnToMenu_Click(object sender, RoutedEventArgs e)
        {
            //navigate to menu page
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void btnNextCase_Click(object sender, RoutedEventArgs e)
        {
            //nvaigate to game page. case id already incremented when game was won
            this.Frame.Navigate(typeof(CaseDescriptionPage));
        }
    }
}
