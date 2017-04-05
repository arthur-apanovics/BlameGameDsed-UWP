using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BlameGame
{
    public sealed partial class GamePage
    {

        public GamePage()
        {
            //make sure a previous timer instance is not running in the background
            CheckIfTimerRunning();

            InitializeComponent();

            //retrieve current scores and assign to labels
            SetScores();

            //Start a new timer during page construction
            HiddenTimer();

            //Start playing background music
            Music.StartMusic();
        }

        /// <summary>
        /// Button click events
        /// </summary>

        private void btnCharge_Click(object sender, RoutedEventArgs e)
        {
            bool guilty = SuspectInteractions.CheckIfSuspectIsCriminal(SuspectGrid.SelectedItem);
            BlameSuspect(guilty);
        }

        private void btnQ1_Click(object sender, RoutedEventArgs e)
        {
            lbxLog.Items.Add(SuspectInteractions.ShowAnswerToAskedQuestion(btnQ1.Name, SuspectGrid.SelectedItem));
        }

        private void btnQ2_Click(object sender, RoutedEventArgs e)
        {
            lbxLog.Items.Add(SuspectInteractions.ShowAnswerToAskedQuestion(btnQ2.Name, SuspectGrid.SelectedItem));
        }

        private void btnInterrogate_Click(object sender, RoutedEventArgs e)
        {
            lbxLog.Items.Add(SuspectInteractions.InterrogateTheSuspect(SuspectGrid.SelectedItem));
            HideInterrogateButton();
        }

        private void btnSoundToggle_Click(object sender, RoutedEventArgs e)
        {
            Music.StopMusic();
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        /// <summary>
        ///  Methods used for button clicks
        /// </summary>

        private void BlameSuspect(bool guilt)
        {
            if (guilt)
                GameWasWon();
            else
                GameOverMethod("You blamed the wrong suspect.\nShame on you!");
        }

        private void HideInterrogateButton()
        {
            btnInterrogate.IsEnabled = false;
            btnInterrogate.Visibility = Visibility.Collapsed;
            lblInterrogate.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Game event methods (game over, enable buttons, etc)
        /// </summary>

        private void GameWasWon()
        {
            StopTimer(_timer);
            //increment case id so that the nect case runs when a new game is started
            CaseIdStatic.IncrementCaseId();
            //update score
            ScoreTracking.Won++;
            this.Frame.Navigate(typeof(GameWon));
        }

        private void GameOverMethod(string reason)
        {
            StopTimer(_timer);
            //update the score
            ScoreTracking.Lost++;
            GameOver.FailureReason = reason;
            this.Frame.Navigate(typeof(GameOver));
        }

        private void SuspectGrid_GotFocus(object sender, SelectionChangedEventArgs e)
        {
            //check if button is enabled, if not, enable all necessary buttons
            if (!btnCharge.IsEnabled) { 
                btnCharge.IsEnabled =
                    btnQ1.IsEnabled =
                    btnQ2.IsEnabled =
                    btnInterrogate.IsEnabled = true;
                //TODO make button disabled instead of invisible. 
                //Since button BG is image, when disabled button shows as a grey block
                btnInterrogate.Visibility = Visibility.Visible;
                lblInterrogate.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Methods used when page is loading 
        /// </summary>

        private void CheckIfTimerRunning()
        {
            if (_timerTimesTicked != 0 || _timerTimesToTick != 60)
            {
                StopTimer(_timer);
                _timerTimesToTick = 60;
            }
        }

        private void SetScores()
        {
            lblWonCount.Text = ScoreTracking.Won.ToString();
            lblLostCount.Text = ScoreTracking.Lost.ToString();
        }

        /// <summary>
        /// Timer for the game
        /// </summary>

        private DispatcherTimer _timer;
        // Set the amount of times ticked to 0 just to be safe
        private int _timerTimesTicked = 0;
        // THIS SETS THE AMOUNT OF TIME PLAYER HAS BEFORE GAME IS OVER
        private int _timerTimesToTick = 60;

        //Method to start new timer
        private void HiddenTimer()
        {
            //set the progress bar maximum value to timer's max tick number
            prbarTimeLeft.Maximum = _timerTimesToTick;
            prbarTimeLeft_top.Maximum = _timerTimesToTick;

            //start the timer
            _timer = new DispatcherTimer();
            _timer.Tick += TimerTick;
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }
        private void TimerTick(object sender, object e)
        {
            //update reamining time on game page on every timer tick
            prbarTimeLeft.Value = _timerTimesToTick - _timerTimesTicked;
            prbarTimeLeft_top.Value = _timerTimesToTick - _timerTimesTicked;

            //check if out of time
            if (_timerTimesTicked >= _timerTimesToTick)
            {
                StopTimer(_timer);
                GameOverMethod("You were too slow, the suspect got away!");
                return;
            }

            //if not out of time, add 1 to ticked counter
            _timerTimesTicked++;
        }

        //method to stop timer
        private void StopTimer(DispatcherTimer timerToStop)
        {
            timerToStop.Stop();
        }
    }
}
