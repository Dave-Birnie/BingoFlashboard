using BingoFlashboard.Data;
using BingoFlashboard.View;
using BingoFlashboard.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
using System.Security.Policy;
using BingoFlashboard.ViewModel;

namespace BingoFlashboard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region GLOBAL VARIABLES
        public static string errorlogPath = @".\errorlog.txt";
        public static string startupFile = @".\startupFile.txt";
        public static string hallFile = string.Empty;


        #region MainVariables

        public static Hall? hall;
        public static Session? SelectedSession;
        public static Game? SelectedGame;
        public static List<Pattern> allPatterns = new();
        private static LoadAllPatterns lap = new();
        public static List<Card> cardList = new();
       // public static List<Pattern>? patternList_ = new();

        #endregion

        public static StartupClass startup = new();
        #endregion GLOBAL VARIABLES

        #region WINDOWS
        public static FlashboardWindow? flashboardWindow;
        public static StartupWindow? startupWindow;
        public static CallerWindow? callerWindow;
        public static MiniGrid? miniGrid;
        public static TimerWindow? timerWindow;
        #endregion WINDOWS

        #region VIEWMODELS  
        public static CallerWindowViewModel? callerWindowViewModel;
        public static FlashboardViewModel? flashboardViewModel;
        #endregion VIEWMODELS

        public static void SaveStartupFile()
        {
            using (StreamWriter writer = new StreamWriter(App.startupFile, false))
            {
                string json = JsonConvert.SerializeObject(startup);
                writer.Write(json);
            }
        }

        public static void ShowCallerWindows()
        {
            startupWindow?.Hide();
            callerWindow?.Show();
            flashboardWindow?.Show();
        }

        //TODO
        public static void WriteToErrorLog(string errorMessage)
        {
            using (StreamWriter sw = File.AppendText(App.errorlogPath))
            {
                sw.WriteLine(errorMessage);
            }
        }


        public static void Exit_Click()
        {
            string message = "Are you sure you would like to close the game?";
            string caption = "WARNING: Ending Game";
            if (System.Windows.MessageBox.Show(message, caption, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
                App.Current.Shutdown();
            }
        }
    }
}
