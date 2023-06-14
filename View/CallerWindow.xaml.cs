using BingoFlashboard.Data;
using BingoFlashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        private bool maxSize = false;
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

        #endregion TOP BUTTONS


        #region GAME DETAILS REGION

        //SELECTS THE GAME
        private void GamesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gamesList.SelectedIndex is not -1)
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

                    //SETS BORDER COLOR PICKER
                    Border_Color_Picker.SelectedColor = (Color) ColorConverter.ConvertFromString(game.Border_Color_.Color_Hash_);


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
        private void CallerType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //UPDATES GAME INFO
        private void Update_Game_Click(object sender, RoutedEventArgs e)
        {
            if (gamesList.SelectedIndex is not -1
                && App.SelectedSession is not null
                && App.SelectedSession.Program_ is not null
                && App.SelectedSession.Program_.Games_ is not null)
            {
                Pattern pat = (Pattern) PatternCB.SelectedItem;
                game.Pattern_ = pat;
                ComboBoxItem cbi = (ComboBoxItem) GameType.SelectedItem;
                game.GameType_ = cbi.Content.ToString();
                game.Name_ = GameName.Text;
                game.Border_Color_.Color_Hash_ = Border_Color_Picker.SelectedColor.ToString();
                game.Border_Color_.Name_ = BorderColorName.Text;
                game.Prize_ = Prize.Text;
                game.Designated_Number_ = JackpotNum.Text;
                game.Jackpot_Prize_ = JackpotPrize.Text;

                App.SelectedSession.Program_.Games_[gamesList.SelectedIndex] = game;
                gamesList.Items.Refresh();
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

        }

        private void Reset_Board_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ball_KeyDown(object sender, KeyEventArgs e)
        {

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
