using BingoFlashboard.Model;
using System;
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
using System.Windows.Shapes;

namespace BingoFlashboard.View
{
    /// <summary>
    /// Interaction logic for CallerWindow.xaml
    /// </summary>
    public partial class CallerWindow : Window
    {
        private Program program = new();
        private List<Game> games = new List<Game>();

        #region Variables
        bool maxSize = false;
        #endregion

        public CallerWindow()
        {
            InitializeComponent();
            if (App.SelectedSession is not null)
                if (App.SelectedSession.Program_ is not null)
                {
                    gamesList.ItemsSource = App.SelectedSession.Program_.Games_;
                    program = (Program) App.SelectedSession.Program_;
                    ProgramName.Content = program.Name_;
                    CB_Cardset.ItemsSource = program.Cardsets_;
                    if (program.Games_ != null)
                    {
                        games = program.Games_;
                    }
                }
                else
                    MessageBox.Show("Error, unable to load program");

            App.callerWindow = this;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


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


        private void GamesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DesignatedPrize_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DesignatedNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Update_Game_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Game_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Load_New_Session_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FourBallBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Intermission_Minutes_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void VerifyTxtBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CheckCardBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hide_Jackpot_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CallerType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DesignatedNum_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Ball_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void PreviousGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextGameBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
