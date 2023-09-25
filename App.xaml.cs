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
        public static string hallFile = @".\DaveHall.txt";


        #region MainVariables

        public static Hall? hall;
        public static Session? SelectedSession;
        public static Game? SelectedGame;
        #endregion

        public static StartupClass startup = new();
        #endregion GLOBAL VARIABLES

        #region WINDOWS
        public static FlashboardWindow? flashboardWindow;
        public static StartupWindow? startupWindow;
        public static CallerWindow? callerWindow;
        public static MiniGrid? miniGrid;
        #endregion WINDOWS

        public static void SaveStartupFile()
        {
            using (StreamWriter writer = new StreamWriter(App.startupFile, false))
            {
                string json = JsonConvert.SerializeObject(startup);
                writer.Write(json);
            }
        }


        //TODO
        public static void WriteToErrorLog(string errorMessage)
        {
            

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
