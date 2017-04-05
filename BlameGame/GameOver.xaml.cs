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
    public sealed partial class GameOver : Page
    {
        //made this property static so you don't have to create a new instance of this page when updating property
        public static string FailureReason { get; set; }

        public GameOver()
        {
            this.InitializeComponent();
            SetFailureReasonLabel();
        }

        private void SetFailureReasonLabel()
        {
            lblReason.Text = FailureReason;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GamePage));
        }
    }
}
