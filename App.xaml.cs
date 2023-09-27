using BingoFlashboard.Data;
using BingoFlashboard.View;
using BingoFlashboard.Model;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
using BingoFlashboard.ViewModel;
using System;

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
        public static ServerConnection? server;
        public static VerificationPage SharedVerificationPage { get; } = new VerificationPage();
        public static VerificationPage SharedVerificationPage2 { get; } = new VerificationPage();


        #region MainVariables

        public static Hall? hall;
        public static Session? SelectedSession;
        public static Game? SelectedGame;
        public static string StartTime = "";
        public static List<Pattern> allPatterns = new();
        private static LoadAllPatterns lap = new();
        public static List<Card> cardList = new();
        public static List<Player> playerList = new();
        public static List<string> Calls = new();

        #endregion

        public static StartupClass startup = new();
        #endregion GLOBAL VARIABLES

        #region WINDOWS
        public static FlashboardWindow? flashboardWindow;
        public static StartupWindow? startupWindow;
        public static CallerWindow? callerWindow;
        public static MiniGrid? miniGrid;
        public static TimerWindow? timerWindow;
        //public static VerificationPage? verificationPage;
        public static VerifyWindow? verificationWindow = new();
        #endregion WINDOWS

        #region VIEWMODELS  
        public static CallerWindowViewModel? callerWindowViewModel;
        public static FlashboardViewModel? flashboardViewModel;
        #endregion VIEWMODELS

        #region METHODS

        public static void SaveStartupFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(App.startupFile, false))
                {
                    string json = JsonConvert.SerializeObject(startup);
                    writer.Write(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " 001");
            }
        }

        public static void LoadStartupFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(App.startupFile))
                {
                    string json = reader.ReadToEnd();
                    startup = JsonConvert.DeserializeObject<StartupClass>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowCallerWindows()
        {
            startupWindow?.Hide();
            callerWindow?.Show();
            flashboardWindow?.Show();
            timerWindow?.Show();
        }

        //TODO
        public static void WriteToErrorLog(string errorMessage)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(App.errorlogPath))
                {
                    sw.WriteLine(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " 002");
            }
        }

        public void ShowToastNotification(string title, string message)
        {
            //ToastContent toastContent = new ToastContentBuilder()
            //      .AddText(title)
            //      .AddText(message)
            //      .GetToastContent();

            //// Generate the toast XML
            //XDocument xDoc = XDocument.Parse(toastContent.GetContent());

            //// Create the toast notification
            //ToastNotification toast = new ToastNotification(xDoc);

            //// Display the toast notification
            //ToastNotificationManagerCompat.CreateToastNotifier().Show(toast);
        }

        public async static void Exit_Click()
        {
            string message = "Are you sure you would like to close the game?";
            string caption = "WARNING: Ending Game";
            if (System.Windows.MessageBox.Show(message, caption, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (App.callerWindowViewModel is not null && App.callerWindowViewModel.HostingStatus.HostingGameStatus == "On")
                {
                    if (App.server is not null)
                    {
                        await App.server.KillConnection();
                        App.server.CloseConnection();
                    }
                }
                Application.Current.Shutdown();
                App.Current.Shutdown();
            }
        }

        #endregion METHODS

    }
}
