using BingoFlashboard.Model;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading.Tasks;

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
        private Game game = new();
        HubConnection connection;

        private bool maxSize = false;
        private bool Broadcasting = false;

        private List<string> messages = new List<string>() { "Welcome to Bingo Flashboard" };

        #endregion VARIABLES

        #region CONSTRUCTOR
        public CallerWindow()
        {
            InitializeComponent();

            App.callerWindowViewModel = new();
            PatternCB.ItemsSource = App.allPatterns;
            //ENSURES SESSION IS SELECTED AND LOADS PROGRAM & GAMES
            if (App.SelectedSession is not null)
                if (App.SelectedSession.Program_ is not null)
                {
                    program = (Program) App.SelectedSession.Program_;
                    ProgramName.Content = program.Name_;
                    CB_Cardset.ItemsSource = program.Cardsets_;
                    if (program.Games_ != null)
                    {
                        games = program.Games_;
                    }
                    gamesList.ItemsSource = App.SelectedSession.Program_.Games_;
                    gamesList.SelectedIndex = 0;
                }
                else
                    MessageBox.Show("Error, unable to load program");

            //LOADS ALL PATTERNS INTO THE PATTERN COMBOBOX
            App.callerWindow = this;
            DataContext = App.callerWindowViewModel;

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
            if (App.flashboardWindow != null)
            {
                double width = App.flashboardWindow.Width;
                double height = App.flashboardWindow.Height;

                App.startup.FlashboardHeight = height;
                App.startup.FlashboardWidth = width;

                App.SaveStartupFile();
            }
        }

        private async void GoLiveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.callerWindowViewModel is not null)
            {
                App.callerWindowViewModel.BroadcastingStatus.BroadcastingStatusSet("Waiting");

                if (App.server is null)
                {
                    App.server = new();
                }
                else
                {
                    App.server.CloseConnection();
                    App.server = null;
                }
            }
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            App.server.HostNewGame();
        }

        #endregion TOP BUTTONS


        #region GAME DETAILS REGION

        //SELECTS THE GAME
        private void GamesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gamesList.SelectedIndex is not -1 && App.flashboardViewModel is not null)
            {
                game = (Game) gamesList.SelectedItem;
                if (App.callerWindowViewModel is not null)
                {
                    //SETS GAMENAME TEXTBOX; SETS PRIZE TEXTBOX; SETS DESIGNATED NUMBER TEXTBOX; SETS DESIGNATED NUMBER TEXTBOX;
                    App.callerWindowViewModel.SelectedGame = game;

                    //SELECTS GAMETYPE FROM GAMETYPE COMBOBOX
                    foreach (ComboBoxItem cbi in GameType.Items)
                    {
                        if (cbi.Content.ToString() == game.GameType_)
                            cbi.IsSelected = true;
                    }

                    //SETS BORDER COLOR PICKER && FLASHBOARD BACKGROUND COLOR
                    Color background = (Color) ColorConverter.ConvertFromString(game.Border_Color_.Color_Hash_);
                    Border_Color_Picker.SelectedColor = background;
                    App.flashboardViewModel.BackgroundColor = new SolidColorBrush(background);

                    //SETS BORDER COLOR PICKER && FLASHBOARD FONT COLOR 
                    Color font = (Color) ColorConverter.ConvertFromString(game.Font_Color_.Color_Hash_);
                    Font_Color_Picker.SelectedColor = font;
                    App.flashboardViewModel.FontColor = new SolidColorBrush(font);


                    //SELECTS PATTER FROM PATTERN COMBOBOX
                    int a = 0; //Counts the Combobox item number. 
                    foreach (Pattern cbi in PatternCB.Items)
                    {
                        if (game.Pattern_ is not null && cbi.Pattern_Name_ == game.Pattern_.Pattern_Name_)
                        {
                            PatternCB.SelectedIndex = a++;
                            break;
                        }
                        a++;
                    }
                    if (game.Pattern_ is not null && App.miniGrid is not null)
                        App.miniGrid.StartAnimation(game.Pattern_);

                    Update_Flashboard_View();
                }
            }
            else
            {
                ClearLoadedGame();
            }
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

        private void Update_Flashboard_View()
        {
            game = (Game) gamesList.SelectedItem;

            //UPDATE FLASHBOARD
            if (App.flashboardViewModel is not null)
            {
                App.flashboardViewModel.DesignatedNumVisibility = Visibility.Hidden;
                App.flashboardViewModel.JackpotSectionVisibility = Visibility.Hidden;
                App.flashboardViewModel.MoneyBallVisibility = Visibility.Hidden;
                App.flashboardViewModel.UPikEmVisibility = Visibility.Hidden;
                App.flashboardViewModel.JackpotVisibility = Visibility.Hidden;

                switch (game.GameType_)
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
                Color background = (Color) ColorConverter.ConvertFromString(game.Border_Color_.Color_Hash_);
                Border_Color_Picker.SelectedColor = background;
                App.flashboardViewModel.BackgroundColor = new SolidColorBrush(background);

                //SETS BORDER COLOR PICKER && FLASHBOARD FONT COLOR 
                Color font = (Color) ColorConverter.ConvertFromString(game.Font_Color_.Color_Hash_);
                Font_Color_Picker.SelectedColor = font;
                App.flashboardViewModel.FontColor = new SolidColorBrush(font);

                App.flashboardViewModel.CurrentGame = game;

            }//END CHECK FLASHBOARDVIEWMODEL

        }

        //UPDATES GAME INFO
        private void Update_Game_Click(object sender, RoutedEventArgs e)
        {
            if (gamesList.SelectedIndex is not -1
                && App.SelectedSession is not null
                && App.SelectedSession.Program_ is not null
                && App.SelectedSession.Program_.Games_ is not null
                && App.flashboardViewModel is not null)
            {
                Pattern pat = (Pattern) PatternCB.SelectedItem;
                game.Pattern_ = pat;
                ComboBoxItem cbi = (ComboBoxItem) GameType.SelectedItem;
                game.GameType_ = cbi.Content.ToString();
                game.Name_ = GameName.Text;
                game.Border_Color_.Color_Hash_ = Border_Color_Picker.SelectedColor.ToString();
                game.Font_Color_.Color_Hash_ = Font_Color_Picker.SelectedColor.ToString();
                game.Border_Color_.Name_ = BorderColorName.Text;
                game.Font_Color_.Name_ = FontColorName.Text;
                game.Prize_ = Prize.Text;
                game.Designated_Number_ = JackpotNum.Text;
                game.Jackpot_Prize_ = JackpotPrize.Text;

                App.SelectedSession.Program_.Games_[gamesList.SelectedIndex] = game;

                gamesList.Items.Refresh();


                //UPDATES FLASHBOARD
                Update_Flashboard_View();
            }
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
            App.startupWindow.Show();
            this.Close();
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

        }



        #endregion INTERMISSION SECTION REGION


        #region VERIFYCARD REGION
        private void VerifyTxtBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CheckCardBtn_Click(object sender, RoutedEventArgs e)
        {

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
                App.flashboardViewModel.ResetBoard();
        }

        private void Ball_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && App.flashboardViewModel is not null)
            {
                string response = App.flashboardViewModel.UpdateFlashboardNumbers(Ball.Text);
                if (response == "Success")
                    Ball.Text = "";

                else if (response == "Fail")
                    MessageBox.Show("Ball Error");
            }
        }

        #endregion GAME CONTROL REGION


        #region GAME SELECTION REGION
        private void NextGameBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void PreviousGame_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion GAME SELECTION REGION


    }
}
