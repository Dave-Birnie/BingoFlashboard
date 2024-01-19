using BingoFlashboard.Model;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading.Tasks;
using System;
using System.Windows.Media.Animation;
using BingoFlashboard.Model.FlashboardModels;
using System.Windows.Media.Imaging;

namespace BingoFlashboard.View
{
    /// <summary>
    /// Interaction logic for CallerWindow.xaml
    /// </summary>
    public partial class CallerWindow : Window
    {
        #region VARIABLES
        private Program program = new();
        private List<Game> games = new();
        private int PreviousSelctedGameIndex = -1;
        private bool CancelPreviousGameSelect = false;
        //private Game game = new();
        HubConnection connection;
        //public List<string> calls = new();

        private readonly DispatcherTimer _timer;
        private readonly Storyboard _animation;


        private bool maxSize = false;
        public bool BroadcastingGame = false;

        private List<string> messages = new List<string>() { "Welcome to Bingo Flashboard" };

        #endregion VARIABLES

        #region CONSTRUCTOR
        public CallerWindow()
        {
            InitializeComponent();

            App.callerWindowViewModel = new();

            Maximize_Click(null, null);

            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(30) };
            _timer.Tick += Timer_Tick;

            _animation = (Storyboard) FindResource("FlashingAnimation");
            _animation.Completed += (s, e) => BingoOverlay.Background = null;

            PatternCB.ItemsSource = App.allPatterns;
            //ENSURES SESSION IS SELECTED AND LOADS PROGRAM & GAMES
            if (App.SelectedSession is not null)
                if (App.SelectedSession.Program_ is not null)
                {
                    program = (Program) App.SelectedSession.Program_;
                    ProgramName.Content = program.Name_;
                    CB_Cardset.ItemsSource = program.Cardsets_;
                    if (program.Games_ is not null)
                    {
                        games = program.Games_;
                    }
                    gamesList.ItemsSource = App.SelectedSession.Program_.Games_;
                    gamesList.SelectedIndex = 0;
                    BingosList.ItemsSource = App.callerWindowViewModel.Bingos_;
                }
                else
                    MessageBox.Show("Error, unable to load program");

            //LOADS ALL PATTERNS INTO THE PATTERN COMBOBOX
            App.callerWindow = this;
            DataContext = App.callerWindowViewModel;

            VerifyFrame.NavigationService.Navigate(App.SharedVerificationPage);
            if (App.verificationWindow is not null)
                App.verificationWindow.Show();

        }
        #endregion CONSTRUCTOR


        #region WINDOW KEYS
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        #endregion WINDOW KEYS


        #region TOP BUTTONS

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Exit_Click();
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (!maxSize)
            {
                this.WindowState = WindowState.Maximized;
                maxSize = true;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                maxSize = false;
            }
        }

        private void Save_FlashboardSize(object sender, RoutedEventArgs e)
        {
            try
            {
                if (App.flashboardWindow is not null)
                {
                    double width = App.flashboardWindow.Width;
                    double height = App.flashboardWindow.Height;

                    App.startup.FlashboardHeight = height;
                    App.startup.FlashboardWidth = width;

                    App.SaveStartupFile();

                    MessageBox.Show("Flashboard size saved");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (App.callerWindowViewModel is not null)
                    App.callerWindowViewModel.AddServerMessage("Flashboard not saved\n" + ex.Message);

            }
        }

        private async void GoLiveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.server is not null && App.callerWindowViewModel is not null)
            {
                //ENSURE DATE/TIME IS SET FOR GAME
                if (TimePickerControl.Text is null || TimePickerControl.Text == "")
                {
                    MessageBox.Show("Must enter time for the game to start");
                }
                else
                {
                    App.StartTime = TimePickerControl.Text;
                    if (App.callerWindowViewModel.HostingStatus.HostingGameStatus != "On")
                    {
                        TimePickerControl.IsEnabled = false;
                        await App.server.HostNewGame();
                    }
                    else
                    {
                        App.callerWindowViewModel.HostingStatus.HostingGameStatusSet("Off");
                        //BroadcastingGame = false;
                        TimePickerControl.IsEnabled = true;
                        MessageBox.Show("No longer hosting a game");
                    }
                }
            }
        }


        #endregion TOP BUTTONS


        #region GAME DETAILS REGION

        //SELECTS THE GAME
        private void GamesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (!App.GameStarted)
            //{
            if (gamesList.SelectedIndex is not -1 && App.flashboardViewModel is not null)
            {
                PreviousSelctedGameIndex = gamesList.SelectedIndex;
                App.SelectedGame = (Game) gamesList.SelectedItem;
                if (App.callerWindowViewModel is not null)
                {
                    //SETS GAMENAME TEXTBOX; SETS PRIZE TEXTBOX; SETS DESIGNATED NUMBER TEXTBOX; SETS DESIGNATED NUMBER TEXTBOX;
                    App.callerWindowViewModel.SelectedGame = App.SelectedGame;

                    //SELECTS GAMETYPE FROM GAMETYPE COMBOBOX
                    foreach (ComboBoxItem cbi in GameType.Items)
                    {
                        if (cbi.Content.ToString() == App.SelectedGame.GameType_)
                            cbi.IsSelected = true;
                    }

                    //SETS BORDER COLOR PICKER && FLASHBOARD BACKGROUND COLOR
                    Color background = (Color) ColorConverter.ConvertFromString(App.SelectedGame.Border_Color_.Color_Hash_);
                    Border_Color_Picker.SelectedColor = background;
                    App.flashboardViewModel.BackgroundColor = new SolidColorBrush(background);

                    //SETS BORDER COLOR PICKER && FLASHBOARD FONT COLOR 
                    Color font = (Color) ColorConverter.ConvertFromString(App.SelectedGame.Font_Color_.Color_Hash_);
                    Font_Color_Picker.SelectedColor = font;
                    App.flashboardViewModel.FontColor = new SolidColorBrush(font);

                    //SELECTS PATTER FROM PATTERN COMBOBOX
                    int a = 0; //Counts the Combobox item number. 
                    foreach (Pattern cbi in PatternCB.Items)
                    {
                        if (App.SelectedGame.Pattern_ is not null && cbi.Pattern_Name_ == App.SelectedGame.Pattern_.Pattern_Name_)
                        {
                            PatternCB.SelectedIndex = a++;
                            break;
                        }
                        a++;
                    }
                    if (App.SelectedGame.Pattern_ is not null && App.miniGrid is not null)
                        App.miniGrid.StartAnimation(App.SelectedGame.Pattern_);

                    if (App.SelectedGame is not null && App.callerWindowViewModel is not null)
                    {
                        //THIS SECTION OF CODE IS CHECKING IF THE GAME HAS BEEN STARTED BEFORE. IF IT HAS, IT WILL LOAD THE BINGOS FROM THE GAME. IF NOT IT WILL CREATE A NEW LIST
                        if (App.SelectedGame.Winner_ is null || App.SelectedGame.Winner_.Count == 0)
                        {
                            App.callerWindowViewModel.Bingos_ = new();
                        }
                        else
                        {
                            foreach (Winner cb in App.SelectedGame.Winner_)
                            {
                                App.callerWindowViewModel.Bingos_.Add(cb.PlayerInfo_);
                            }
                        }
                    }
                    Update_Flashboard_View();
                }
            }
            else
            {
                ClearLoadedGame();
            }
            //}
            //else
            //{
            //    if (gamesList.SelectedIndex != PreviousSelctedGameIndex)
            //        MessageBox.Show("Game is in progress, must end game before moving to next one.");
            //    gamesList.SelectedIndex = PreviousSelctedGameIndex;

            //}
        }

        //CLEARS ALL POPULATED GAME INFO
        private void ClearLoadedGame()
        {
            GameType.SelectedIndex = -1;
            GameName.Text = "";
            Border_Color_Picker.SelectedColor = null;
            BorderColorName.Text = "";
            Font_Color_Picker.SelectedColor = null;
            FontColorName.Text = "";
            PatternCB.SelectedIndex = -1;
            Prize.Text = "";
            JackpotNum.Text = "";
            JackpotPrize.Text = "";
        }

        //CHANGES LABELS TO MAKE IT CLEARER FOR USER
        private void GameType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem) CallerType.SelectedItem;

            //IF YOU HIDE ALL ELEMENTS FIRST, LESS CODE IN THE SWITCH CODE 
            JackpotGameSection.Visibility = Visibility.Visible;
            if (App.flashboardViewModel is not null)
            {
                App.flashboardViewModel.DesignatedNumVisibility = Visibility.Hidden;
                App.flashboardViewModel.JackpotSectionVisibility = Visibility.Hidden;
                App.flashboardViewModel.MoneyBallVisibility = Visibility.Hidden;
                App.flashboardViewModel.UPikEmVisibility = Visibility.Hidden;
                App.flashboardViewModel.JackpotVisibility = Visibility.Hidden;

                switch (cbi.Content)
                {
                    case "Regular":
                        {
                            JackpotGameSection.Visibility = Visibility.Hidden;

                            break;
                        }
                    case "Toonie Ball":
                        {
                            JackpotLbl.Content = "Tonnie Ball Prize";
                            DesignatedNumLbl.Content = "Toonie Ball #";
                            break;
                        }
                    case "Money Ball":
                        {
                            JackpotLbl.Content = "Money Ball Prize";
                            DesignatedNumLbl.Content = "Money Ball #";
                            break;
                        }
                    case "Designated Number":
                        {
                            JackpotLbl.Content = "Designated # Prize";
                            DesignatedNumLbl.Content = "Designated #";
                            break;
                        }
                    case "U Pik Em":
                        {
                            JackpotLbl.Content = "U Pik Em Prize";
                            DesignatedNumLbl.Content = "U Pik Em #";
                            break;
                        }
                }
            }//END CHECK FLASHBOARDVIEWMODEL
        }

        private async void Update_Flashboard_View()
        {
            App.SelectedGame = (Game) gamesList.SelectedItem;

            //UPDATE FLASHBOARD
            if (App.flashboardViewModel is not null)
            {
                App.flashboardViewModel.DesignatedNumVisibility = Visibility.Hidden;
                App.flashboardViewModel.JackpotSectionVisibility = Visibility.Hidden;
                App.flashboardViewModel.MoneyBallVisibility = Visibility.Hidden;
                App.flashboardViewModel.UPikEmVisibility = Visibility.Hidden;
                App.flashboardViewModel.JackpotVisibility = Visibility.Hidden;

                switch (App.SelectedGame.GameType_)
                {
                    case "Toonie Ball":
                        {
                            App.flashboardViewModel.MoneyBallVisibility = Visibility.Visible;
                            App.flashboardViewModel.JackpotSectionVisibility = Visibility.Visible;
                            App.flashboardViewModel.JackpotVisibility = Visibility.Visible;
                            break;
                        }
                    case "Money Ball":
                        {
                            App.flashboardViewModel.MoneyBallVisibility = Visibility.Visible;
                            App.flashboardViewModel.JackpotSectionVisibility = Visibility.Visible;
                            App.flashboardViewModel.JackpotVisibility = Visibility.Visible;
                            break;
                        }
                    case "Designated Number":
                        {
                            App.flashboardViewModel.DesignatedNumVisibility = Visibility.Visible;
                            App.flashboardViewModel.JackpotSectionVisibility = Visibility.Visible;
                            App.flashboardViewModel.JackpotVisibility = Visibility.Visible;
                            break;
                        }
                    case "U Pik Em":
                        {
                            App.flashboardViewModel.DesignatedNumVisibility = Visibility.Visible;
                            App.flashboardViewModel.JackpotSectionVisibility = Visibility.Visible;
                            App.flashboardViewModel.JackpotVisibility = Visibility.Visible;
                            break;
                        }
                }

                //UPDATES FLASHBOARD COLORS
                //SETS BORDER COLOR PICKER && FLASHBOARD BACKGROUND COLOR
                Color background = (Color) ColorConverter.ConvertFromString(App.SelectedGame.Border_Color_.Color_Hash_);
                Border_Color_Picker.SelectedColor = background;
                App.flashboardViewModel.BackgroundColor = new SolidColorBrush(background);

                //SETS BORDER COLOR PICKER && FLASHBOARD FONT COLOR 
                Color font = (Color) ColorConverter.ConvertFromString(App.SelectedGame.Font_Color_.Color_Hash_);
                Font_Color_Picker.SelectedColor = font;
                App.flashboardViewModel.FontColor = new SolidColorBrush(font);

                App.flashboardViewModel.CurrentGame = App.SelectedGame;
                App.flashboardViewModel.ChangeMoneyBallImage(App.SelectedGame.Designated_Number_);
            }//END CHECK FLASHBOARDVIEWMODEL

        }

        public async Task SendGameInfo()
        {
            if (BroadcastingGame)
                if (App.server is not null)
                    await App.server.SendGameInfo(App.SelectedGame);
        }

        //UPDATES GAME INFO
        private void Enter_Click(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Update_Game_Click(sender, e);
            }
        }
        private void Update_Game_Click(object sender, RoutedEventArgs e)
        {
            if (gamesList.SelectedIndex is not -1
                && App.SelectedSession is not null
                && App.SelectedSession.Program_ is not null
                && App.SelectedSession.Program_.Games_ is not null
                && App.flashboardViewModel is not null)
            {
                if (Int32.TryParse(JackpotNum.Text, out int j))
                {
                    if (j > 75 || j <= 0)
                    {
                        if (JackpotNum.Text is not "")
                        {
                            System.Windows.MessageBox.Show("Make sure number is between 1-75, Use numbers only");
                            return;
                        }
                    }
                    else
                    {
                        App.SelectedGame.Designated_Number_ = JackpotNum.Text;
                    }
                }
                else
                {
                    if (JackpotNum.Text is not "")
                    {
                        System.Windows.MessageBox.Show("Make sure number is between 1-75. Use numbers only");
                        return;
                    }
                }


                App.SelectedGame.Jackpot_Prize_ = JackpotPrize.Text;
                Pattern pat = (Pattern) PatternCB.SelectedItem;
                App.SelectedGame.Pattern_ = pat;
                ComboBoxItem cbi = (ComboBoxItem) GameType.SelectedItem;

                App.SelectedGame.GameType_ = cbi.Content.ToString();
                App.SelectedGame.Name_ = GameName.Text;
                App.SelectedGame.Border_Color_.Color_Hash_ = Border_Color_Picker.SelectedColor.ToString();
                App.SelectedGame.Font_Color_.Color_Hash_ = Font_Color_Picker.SelectedColor.ToString();
                App.SelectedGame.Border_Color_.Name_ = BorderColorName.Text;
                App.SelectedGame.Font_Color_.Name_ = FontColorName.Text;
                App.SelectedGame.Prize_ = Prize.Text;
                App.SelectedGame.Designated_Number_ = JackpotNum.Text;

                //foreach (Game gam in App.SelectedSession.Program_.Games_)
                //{
                //    if (gam.Name_ == App.SelectedGame.Name_)
                //    {
                //        gam.Jackpot_Prize_ = App.SelectedGame.Jackpot_Prize_;
                //        gam.Designated_Number_ = App.SelectedGame.Designated_Number_;
                //    }
                //}

                App.SelectedSession.Program_.Games_[gamesList.SelectedIndex] = App.SelectedGame;

                gamesList.Items.Refresh();

                //UPDATES FLASHBOARD
                Update_Flashboard_View();
            }//END CHECKS
        }

        //DELETES GAME FROM SESSION (for this round -- future programs will still have this game) 
        private void Delete_Game_Click(object sender, RoutedEventArgs e)
        {
            if (gamesList.SelectedIndex is not -1 && App.SelectedSession is not null && App.SelectedSession.Program_ is not null && App.SelectedSession.Program_.Games_ is not null)
            {
                App.SelectedSession.Program_.Games_.RemoveAt(gamesList.SelectedIndex);
                gamesList.Items.Refresh();
            }
        }

        //ALLOWS YOU TO GO BACK AND SELECT A NEW SESSION
        private void Load_New_Session_Click(object sender, RoutedEventArgs e)
        {
            if (App.startupWindow is not null)
            {
                App.startupWindow.Show();
                this.Close();
            }
        }

        #endregion GAME DETAILS REGION


        #region EXTRA SETTINGS REGION

        private void FourBallBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion EXTRAS SETTINGS REGION


        #region INTERMISSION SECTION REGION
        private void Intermission_Minutes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string selectedType = "";
                if (start.IsSelected)
                    selectedType = "start";

                else if (intermission.IsSelected)
                    selectedType = "intermission";

                else
                    selectedType = "nextgame";

                if (Int32.TryParse(Minutes.Text, out int minutesNum))
                {
                    if (App.timerWindow is not null)
                        App.timerWindow.Show();
                    else
                        App.timerWindow = new TimerWindow();

                    App.timerWindow.Update(Minutes.Text, selectedType);
                }
                else
                {
                    if (App.timerWindow is not null)
                        App.timerWindow.BreakLoop(Minutes.Text, selectedType);
                }
            }
        }



        #endregion INTERMISSION SECTION REGION


        #region VERIFYCARD REGION
        private void VerifyTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VerifyCard();
            }
        }

        private void CheckCardBtn_Click(object sender, RoutedEventArgs e)
        {
            //StartFlashing();
            if (VerifyTxtBox.Text is not null)
            {
                VerifyCard();
            }
        }

        public async void VerifyCard()
        {
            if (App.SharedVerificationPage is not null)
            {
                if (CB_Cardset.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select cardset first");
                }
                else
                {
                    BingosList.SelectedIndex = -1;

                    string tempCard = VerifyTxtBox.Text;
                    await App.SharedVerificationPage.SelectCard(VerifyTxtBox.Text, CB_Cardset.Text);
                    await App.SharedVerificationPage2.SelectCard(VerifyTxtBox.Text, CB_Cardset.Text);
                    VerifyTxtBox.Text = "";

                    bool winner = false;

                    App.SharedVerificationPage.HighlightCard(App.Calls);
                    App.SharedVerificationPage2.HighlightCard(App.Calls);
                    if (App.SelectedGame!.Pattern_ is not null)
                    {
                        winner = App.SharedVerificationPage.CheckWinner();
                        App.SharedVerificationPage2.CheckWinner();
                    }
                    if (winner)
                    {
                        //TODO Add to List<Winner>
                        App.BingoCalled = true;


                        CalledBingos cbs = new();
                        cbs.CardNum_ = tempCard;
                        cbs.Source_ = "Caller";
                        cbs.GoodBingo_ = true;
                        if (App.callerWindowViewModel is not null)
                        {
                            if (App.callerWindowViewModel.Bingos_ is null)
                                App.callerWindowViewModel.Bingos_ = new();

                            App.callerWindowViewModel.Bingos_.Add(cbs);
                        }

                        Winner win = new();
                        win.Date_Time_ = DateTime.Now.ToString();
                        win.PlayerInfo_ = cbs;
                        App.winnerList.Add(win);
                        BingosList.Items.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Unable to verify card.");
            }
        }


        #endregion VERIFYCARD REGION


        #region GAME CONTROL REGION
        private void Hide_Jackpot_Click(object sender, RoutedEventArgs e)
        {
            if (App.flashboardViewModel is not null)
                App.flashboardViewModel.JackpotSectionVisibility = Visibility.Hidden;
        }

        private void Reset_Board_Click(object sender, RoutedEventArgs e)
        {
            if (App.flashboardViewModel is not null)
            {
                App.flashboardViewModel.ResetBoard();
                App.Calls = new();
            }
        }


        private async void Ball_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter && App.flashboardViewModel is not null)
            {
                bool allowAdd = true;
                switch (Ball.Text)
                {
                    case "1":
                        {
                            Ball.Text = "01";
                            break;
                        }
                    case "2":
                        {
                            Ball.Text = "02";
                            break;
                        }
                    case "3":
                        {
                            Ball.Text = "03";
                            break;
                        }
                    case "4":
                        {
                            Ball.Text = "04";
                            break;
                        }
                    case "5":
                        {
                            Ball.Text = "05";
                            break;
                        }
                    case "6":
                        {
                            Ball.Text = "06";
                            break;
                        }
                    case "7":
                        {
                            Ball.Text = "07";
                            break;
                        }
                    case "8":
                        {
                            Ball.Text = "08";
                            break;
                        }
                    case "9":
                        {
                            Ball.Text = "09";
                            break;
                        }
                }
                string response = "";

                foreach (string st in App.Calls)
                {
                    if (Ball.Text == st)
                    {
                        App.Calls.Remove(st);
                        if (st.StartsWith("0"))
                        {
                            string newText = st.Substring(1);
                            App.Calls.Add(newText);
                        }

                        allowAdd = false;
                        response = App.flashboardViewModel.UpdateFlashboardNumbers(Ball.Text);
                        Ball.Text = "";
                        break;
                    }
                }
                if (allowAdd)
                {
                    App.Calls.Add(Ball.Text);
                    if (Ball.Text.StartsWith("0"))
                    {
                        string newText = Ball.Text.Substring(1);
                        App.Calls.Add(newText);
                    }

                    response = App.flashboardViewModel.UpdateFlashboardNumbers(Ball.Text);

                    // Ball.Text = "";
                }
                if (response == "Success")
                {
                    if (App.callerWindowViewModel is not null && App.server is not null && App.callerWindowViewModel.HostingStatus.HostingGameStatus == "On")
                    {
                        await App.server.SendCalledBall(Ball.Text);
                    }
                    Ball.Text = "";
                }

                else if (response == "Fail")
                    MessageBox.Show("Ball Error");

            }
        }

        #endregion GAME CONTROL REGION


        #region GAME SELECTION REGION
        private void NextGameBtn_Click(object sender, RoutedEventArgs e)
        {
            NextGameSelection();
        }
        private void PreviousGame_Click(object sender, RoutedEventArgs e)
        {
            PreviousGameSelection();
        }
        public void PreviousGameSelection()
        {
            int selectedIndex = gamesList.SelectedIndex;
            selectedIndex--;
            // Prevents exception on the last element:      
            if (selectedIndex >= 0)
            {
                gamesList.SelectedIndex = selectedIndex;
            }
        }

        public void NextGameSelection()
        {
            int selectedIndex = gamesList.SelectedIndex;
            selectedIndex++;
            // Prevents exception on the last element:      
            if (selectedIndex < gamesList.Items.Count)
            {
                gamesList.SelectedIndex = selectedIndex;
            }
        }


        #endregion GAME SELECTION REGION

        #region FLASHING BINGO CALLED

        public void StartFlashing()
        {
            BingoOverlay.Background = new SolidColorBrush(Colors.Red);
            _animation.Begin(BingoOverlay, true);
            _timer.Start();
            BingoOverlay.Visibility = Visibility.Visible;
        }

        public async Task OnSignalRMessageReceived()
        {
            _animation.Stop(BingoOverlay);
            _timer.Stop();
            BingoOverlay.Background = null;
            BingoOverlay.Visibility = Visibility.Visible; // Keep the overlay visible until acknowledged
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _animation.Stop(BingoOverlay);
            _timer.Stop();
            BingoOverlay.Background = null;
            BingoOverlay.Visibility = Visibility.Collapsed;
        }

        private void OnAcknowledgeClick(object sender, RoutedEventArgs e)
        {
            _animation.Stop(BingoOverlay);
            _timer.Stop();
            BingoOverlay.Background = null;
            BingoOverlay.Visibility = Visibility.Collapsed;
        }

        private void OnOverlayClick(object sender, MouseButtonEventArgs e)
        {
            _animation.Stop(BingoOverlay);
            _timer.Stop();
            BingoOverlay.Background = null;
            BingoOverlay.Visibility = Visibility.Collapsed;
        }

        #endregion FLASHING BINGO CALLED

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            //TODO START GAME

            bool startGame = true;
            if (App.SelectedGame is not null && App.SelectedGame.Game_End_Time_ != string.Empty)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to overwrite the current data?", "Confirm Overwrite", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (App.SelectedGame is not null && App.callerWindowViewModel is not null)
                    {
                        startGame = true;
                        App.callerWindowViewModel.Bingos_ = new();
                        App.SelectedGame.Winner_ = new();
                        App.SelectedGame.Game_Start_Time_ = DateTime.Now.ToString();
                        MessageBox.Show("Game started @ " + App.SelectedGame.Game_Start_Time_);
                        SendGameInfo();
                    }
                }
                else
                {
                    startGame = false;
                    // Code to handle 'No' option, if needed
                }
            }
            else if (App.SelectedGame is not null && App.SelectedGame.Game_Start_Time_ != string.Empty)
            {
                MessageBox.Show("Game already started");
            }
            else
            {
                if (startGame)
                {
                    App.GameStarted = true;
                    App.BingoCalled = false;
                    if (App.SelectedGame is not null && App.callerWindowViewModel is not null)
                    {
                        SendGameInfo();
                        App.SelectedGame.Game_Start_Time_ = DateTime.Now.ToString();
                        MessageBox.Show("Game started @ " + App.SelectedGame.Game_Start_Time_);
                    }
                }
            }
        }

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            //TODO END GAME
            if (App.SelectedGame is not null && App.SelectedGame.Game_Start_Time_ != string.Empty && App.SelectedGame.Game_End_Time_ == string.Empty)
            {
                App.SelectedGame.Game_End_Time_ = DateTime.Now.ToString();
                App.SelectedGame.Winner_ = App.winnerList;
                App.BingoCalled = false;
                App.GameStarted = false;
                MessageBox.Show("Game stopped @ " + App.SelectedGame.Game_End_Time_);

                //if (App.flashboardViewModel is not null)
                //{
                //    App.flashboardViewModel.ResetBoard();
                //    App.Calls = new();
                //}
            }
            else if (App.SelectedGame is not null && App.SelectedGame.Game_Start_Time_ != string.Empty && App.SelectedGame.Game_End_Time_ != string.Empty)
            {
                MessageBox.Show("Game already stopped");
            }
            else
            {
                MessageBox.Show("Game has not started");
            }
            //TODO PUSH GAME TO SERVER TO SAVE. 
        }

        private async void BingosList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BingosList.SelectedIndex != -1)
            {
                CalledBingos cb = (CalledBingos) BingosList.SelectedItem;
                await App.SharedVerificationPage.SelectCard(cb.CardNum_, "UniMax");
                await App.SharedVerificationPage2.SelectCard(cb.CardNum_, "UniMax");
                App.SharedVerificationPage.CheckWinner();
                App.SharedVerificationPage2.CheckWinner();
            }
        }
    }
}
