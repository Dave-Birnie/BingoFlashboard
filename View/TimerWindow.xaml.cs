using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace BingoFlashboard.View
{
    /// <summary>
    /// Interaction logic for TimerWindow.xaml
    /// </summary>
    public partial class TimerWindow : Window
    {
        #region Variables
        private static TimeSpan _time, _refreshSpan;
        private static DispatcherTimer? _timer = null, DataTimer = null, RotateTimer = null, refreshTimer = null;
        private bool _BreakLoop = false;
        #endregion

        public TimerWindow()
        {
            InitializeComponent();
        }

        public void Update(string minutes, string selectedType)
        {
            BreakLoop(minutes, selectedType);
            if (App.hall is not null)
            {
                //if (App.hall.Name_ == "Riverview")
                //{
                //    string source = @"../Images/gif/Riverview.gif";
                //    var image = new BitmapImage();
                //    image.BeginInit();
                //    image.UriSource = new Uri(@"/Flashboard;component/" + source, UriKind.Relative);
                //    image.EndInit();
                //    ImageBehavior.SetAnimatedSource(TimerBackground, image);
                //    ImageBehavior.SetRepeatBehavior(TimerBackground, new RepeatBehavior(0));
                //    ImageBehavior.SetRepeatBehavior(TimerBackground, RepeatBehavior.Forever);

                //    BitmapImage img = new BitmapImage();
                //    img.BeginInit();
                //    string str = "../Images/gif/RiverviewLogo.png";
                //    TimerLogo.Source = new BitmapImage(new Uri(str, UriKind.Relative));
                //    var converter = new System.Windows.Media.BrushConverter();
                //    //Brush border
                //    var brush = (Brush?) converter.ConvertFromString("#A2094C");
                //    timer.BorderBrush = brush;
                //    //brush background
                //    brush = (Brush?) converter.ConvertFromString("#000");
                //    timer.Background = brush;

                //    //Font Title
                //    title.Foreground = Brushes.White;

                //    //Font Writing
                //    writing.Foreground = Brushes.White;
                //}
                //else if (App.hall.Name_ == "Chances")
                //{
                //    string source = @"../Images/gif/bingoballs.gif";
                //    var image = new BitmapImage();
                //    image.BeginInit();
                //    image.UriSource = new Uri(@"/Flashboard;component/" + source, UriKind.Relative);
                //    image.EndInit();
                //    ImageBehavior.SetAnimatedSource(TimerBackground, image);
                //    ImageBehavior.SetRepeatBehavior(TimerBackground, new RepeatBehavior(0));
                //    ImageBehavior.SetRepeatBehavior(TimerBackground, RepeatBehavior.Forever);


                //    BitmapImage img = new BitmapImage();
                //    img.BeginInit();
                //    string str = "../Images/gif/ChancesLogo2.png";
                //    TimerLogo.Source = new BitmapImage(new Uri(str, UriKind.Relative));

                //    var converter = new System.Windows.Media.BrushConverter();
                //    //Brush border
                //    var brush = (Brush?) converter.ConvertFromString("#a8bb47");
                //    timer.BorderBrush = brush;
                //    //brush background
                //    brush = (Brush?) converter.ConvertFromString("#333");
                //    timer.Background = brush;
                //    //Font Title
                //    title.Foreground = Brushes.White;
                //    ;
                //    //Font Writing
                //    writing.Foreground = Brushes.White;
                //}
                //else if (App.hall.Name_ == "CBG")
                //{
                //    string source = @"../Images/gif/bubble.gif";
                //    var image = new BitmapImage();
                //    image.BeginInit();
                //    image.UriSource = new Uri(@"/Flashboard;component/" + source, UriKind.Relative);
                //    image.EndInit();
                //    ImageBehavior.SetAnimatedSource(TimerBackground, image);
                //    ImageBehavior.SetRepeatBehavior(TimerBackground, new RepeatBehavior(0));
                //    ImageBehavior.SetRepeatBehavior(TimerBackground, RepeatBehavior.Forever);


                //    BitmapImage img = new BitmapImage();
                //    img.BeginInit();
                //    string str = "../Images/gif/CambridgeLogo.png";
                //    TimerLogo.Source = new BitmapImage(new Uri(str, UriKind.Relative));

                //    var converter = new System.Windows.Media.BrushConverter();
                //    //Brush border
                //    var brush = (Brush?) converter.ConvertFromString("#E7C80A");
                //    timer.BorderBrush = brush;
                //    //brush background
                //    brush = (Brush?) converter.ConvertFromString("#A01C4B");
                //    timer.Background = brush;
                //    //Font Title
                //    brush = (Brush?) converter.ConvertFromString("#E7C80A");
                //    title.Foreground = brush;
                //    title.Background = null;
                //    title.BorderBrush = null;
                //    //Font Writing
                //    brush = (Brush?) converter.ConvertFromString("#E7C80A");
                //    writing.Foreground = brush;
                //    writing.Background = null;
                //    writing.BorderBrush = null;
                //}
                //else if (App.hall.Name_ == "Batchewana")
                //{
                //    string source = @"../Images/gif/BingoGif.gif";
                //    var image = new BitmapImage();
                //    image.BeginInit();
                //    image.UriSource = new Uri(@"/Flashboard;component/" + source, UriKind.Relative);
                //    image.EndInit();
                //    ImageBehavior.SetAnimatedSource(TimerBackground, image);
                //    ImageBehavior.SetRepeatBehavior(TimerBackground, new RepeatBehavior(0));
                //    ImageBehavior.SetRepeatBehavior(TimerBackground, RepeatBehavior.Forever);

                //    //App.flashboardWindow.FourBallGrid.Visibility = Visibility.Visible;
                //    //App.controlWindow.FourBallGrid.Visibility = Visibility.Visible;

                //    BitmapImage img = new BitmapImage();
                //    img.BeginInit();
                //    string str = "../Images/gif/batchewana-bingo-logo.png";
                //    TimerLogo.Source = new BitmapImage(new Uri(str, UriKind.Relative));
                //    var converter = new System.Windows.Media.BrushConverter();
                //    //Brush border
                //    var brush = (Brush?) converter.ConvertFromString("#009749");
                //    timer.BorderBrush = brush;
                //    //brush background
                //    brush = (Brush?) converter.ConvertFromString("#894b36");
                //    timer.Background = brush;
                //    //Font Title
                //    brush = (Brush?) converter.ConvertFromString("#894b36");
                //    title.Foreground = brush;
                //    //Font Writing
                //    brush = (Brush?) converter.ConvertFromString("#009749");
                //    writing.Foreground = brush;
                //}
                //else if (App.hall.Name_ == "Riverbank")
                //{
                //    string source = @"../Images/gif/bingoballs.gif";
                //    var image = new BitmapImage();
                //    image.BeginInit();
                //    image.UriSource = new Uri(@"/Flashboard;component/" + source, UriKind.Relative);
                //    image.EndInit();
                //    ImageBehavior.SetAnimatedSource(TimerBackground, image);
                //    ImageBehavior.SetRepeatBehavior(TimerBackground, new RepeatBehavior(0));
                //    ImageBehavior.SetRepeatBehavior(TimerBackground, RepeatBehavior.Forever);


                //    BitmapImage img = new BitmapImage();
                //    img.BeginInit();
                //    string str = "../Images/logos/RiverbankWhite.png";
                //    TimerLogo.Source = new BitmapImage(new Uri(str, UriKind.Relative));

                //    var converter = new System.Windows.Media.BrushConverter();
                //    //Brush border
                //    var brush = (Brush?) converter.ConvertFromString("#91d4f2");
                //    timer.BorderBrush = brush;
                //    //brush background
                //    brush = (Brush?) converter.ConvertFromString("#333");
                //    timer.Background = brush;
                //    //Font Title
                //    title.Foreground = Brushes.White;
                //    ;
                //    //Font Writing
                //    writing.Foreground = Brushes.White;
                //}
                //else
                //{
                TimerLogo.Source = App.hall.ByteArrayToImage();
                //}
            }
        }
        public async void BreakLoop(string minutes, string selectedType)
        {
            _BreakLoop = true;
            await Task.Delay(4500);

            switch (selectedType)
            {
                case "nextgame":
                    {
                        if (_timer is not null)
                        {
                            if (_timer.IsEnabled)
                            {
                                _timer.Stop();
                            }
                        }
                        if (App.timerWindow is not null)
                        {
                            App.timerWindow.timer.Content = minutes;
                            App.timerWindow.title.Content = "Thanks for playing!";
                            App.timerWindow.timer.Content = "Next game will be " + minutes;
                            App.timerWindow.writing.Content = "Hope you had a blast!";
                            App.timerWindow.Show();
                        }
                        break;
                    }

                case "start":
                case "intermission":
                    {
                        try
                        {
                            Int32.TryParse(minutes, out int min);

                            if (min >= 1)
                            {
                                //pauseData = true;
                                min = min * 60;
                                if (_timer is not null)
                                {
                                    if (_timer.IsEnabled)
                                    {
                                        _timer.Stop();
                                    }
                                }
                                UpdateTimer(min, selectedType);
                            }
                            if (min == 0)
                            {
                                //pauseData = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            string s = "Error Parsing Minute " + ex.Message;
                            System.Windows.MessageBox.Show(s);

                            using (StreamWriter sw = File.AppendText(App.errorlogPath))
                            {
                                DateTime dt = DateTime.Now;
                                sw.WriteLine(dt.ToString() + " -- " + s);
                            }
                        }
                        break;
                    }
            }
        }//End BreakLoop()
        public void UpdateTimer(int time, string selectedType)
        {
            try
            {
                if (App.timerWindow is not null)
                {
                    _time = TimeSpan.FromSeconds(time);
                    App.timerWindow.Show();
                    _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                    {
                        string st = _time.ToString("c");
                        App.timerWindow.timer.Content = st;

                        if (_timer is not null && _time == TimeSpan.Zero)
                            _timer.Stop();

                        _time = _time.Add(TimeSpan.FromSeconds(-1));
                    }, Application.Current.Dispatcher);

                    _timer.Start();

                    switch (selectedType)
                    {
                        case "start":
                            {
                                App.timerWindow.title.Content = "Starting soon!";
                                RotateGameStart();
                                break;
                            }
                        case "intermission":
                            {
                                App.timerWindow.title.Content = "On a break";
                                RotateIntermission();
                                break;
                            }
                        case "nextgame":
                            {
                                App.timerWindow.title.Content = "Thanks for playing!";
                                RotateNextGame();
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                string s = "Errorcode #9: " + ex.Message;

                MessageBox.Show(s);
                DateTime dt = DateTime.Now;
                App.WriteToErrorLog(dt.ToString() + " -- " + s);
            }
        }//End UpdateTimer()
        private async void RotateGameStart()
        {
            _BreakLoop = false;
            List<string> words = new List<string> { "Welcome", "Get your cards ready!", "This is going to be fun!",
            "We wish you good luck!", " see big wins coming!", "Grab a drink!", "Still time left!", "We will be starting soon", "You got this!"};
            int num = 0;
            while (true)
            {
                await Task.Delay(3500);
                if (App.timerWindow is not null)
                    App.timerWindow.writing.Content = words[num];

                if (num == 8)
                    num = 0;
                else
                    num++;

                if (_BreakLoop)
                    break;
            }
        }//End RotateGameStart()
        private async void RotateIntermission()
        {
            _BreakLoop = false;
            List<string> words = new List<string> { "Take a break", "Get your cards ready!", "Relax, grab a drink!",
            "Good luck on the rest of the game!", "Hope you are having a good time!", "Grab some popcorn!", "See you in a few!", "We will be starting soon", "Kiss your loved ones"};
            int num = 0;
            while (true)
            {
                await Task.Delay(3500);
                if (App.timerWindow is not null)
                    App.timerWindow.writing.Content = words[num];

                if (num == 8)
                    num = 0;
                else
                    num++;

                if (_BreakLoop)
                    break;
            }
        }//End RotateIntermission()
        private async void RotateNextGame()
        {
            List<string> words = new List<string> { "We hope you had a blast!", "Come get your cards for next game", "Check out our website!",
            "Make sure to stay safe", "We enjoyed having you!", "Don't forget to claim your prize", "Sorry if you didn't win....", "there's always next time!", "Follow us on Facebook"};
            int num = 0;
            while (true)
            {
                await Task.Delay(3500);
                if (App.timerWindow is not null)
                    App.timerWindow.writing.Content = words[num];

                if (num == 8)
                    num = 0;
                else
                    num++;
            }
        }//End RotateNextGame()

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

    }
}
