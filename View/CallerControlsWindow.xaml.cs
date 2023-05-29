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
    /// Interaction logic for CallerControlsWindow.xaml
    /// </summary>
    public partial class CallerControlsWindow : Window
    {

        #region CLASS VARIABLES
        bool maxSize = false;

        #endregion CLASS VARIABLES

        public CallerControlsWindow()
        {
            InitializeComponent();
        }

        #region TOP BAR BUTTONS
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

              //  App.SaveStartupFile();
            }
        }
        #endregion TOP BAR BUTTONS

        #region EDIT GAMEDATA BUTTONS 

        private void DesignatedNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DesignatedNum_KeyDown(object sender, KeyEventArgs e)
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
        #endregion EDIT GAMEDATA BUTTONS

        #region EXTRA GAME BUTTONS


        private void FourBallBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion EXTRA GAME BUTTONS

        #region INTERMISSION SETTINGS

        private void Intermission_Minutes_KeyDown(object sender, KeyEventArgs e)
        {

        }

        #endregion


        private void DesignatedPrize_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void VerifyTxtBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CheckCardBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GamesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
    }
}
