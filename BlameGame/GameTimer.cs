using System;
using System.ComponentModel;
using Windows.UI.Xaml;

namespace BlameGame
{
    class GameTimer : INotifyPropertyChanged
    {

        /// <summary>
        /// This is the timer that I used initially but had to abandon to save development time.
        /// I cannot figure out a way to make the main game page navigate to GameOver page when the time runs out...
        /// leaving everything intact just for fun :)
        /// </summary>

        private DispatcherTimer timer;
        private int timerTimesTicked = 0;
        private int _timeLeft;
        private int _timesToTick;

        public GameTimer()
        {
            TimesToTick = 60;
            TimerStart();
        }

        public int TimesToTick
        {
            get
            {
                if (_timesToTick == 0)
                    _timesToTick = 90;
                return _timesToTick;
            }
            set { _timesToTick = value; }
        }

        public int TimeLeft
        {
            get
            {
                if (_timeLeft <= 0)
                {
                    TimeLeft = _timesToTick;
                    return _timeLeft;
                }
                return _timeLeft ;
            }
            set
            {
                _timeLeft = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeLeft)));
            }
        }

        private void TimerStart()
        {
            timer = new DispatcherTimer();
            timer.Tick += TimerTick;
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();
        }

        public void TimerTick(object sender, object e)
        {
            if (timerTimesTicked >= TimesToTick)
            {
                timer.Stop();
                return;
            }
            timerTimesTicked++;
            TimeLeft = TimesToTick - timerTimesTicked;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
