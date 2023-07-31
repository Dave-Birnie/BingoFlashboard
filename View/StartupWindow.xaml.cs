using BingoFlashboard.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
using System.Windows.Input;
using Microsoft.AspNetCore.SignalR.Client;

namespace BingoFlashboard.View
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {

        #region classVariables
        //ViewModel.StartViewModel svm;
        public string filepath = "";

        #endregion

        public StartupWindow()
        {
            InitializeComponent();

            App.startupWindow = this;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void LoadHallBtn_Click(object sender, RoutedEventArgs e)
        {
            Startup();
            LoadSessions();
        }

        #region ErrorCode #1: Startup()
        private void Startup()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == true)
                {
                    filepath = openFileDialog.FileName;
                    App.hallFile = filepath;

                    string[] lines = System.IO.File.ReadAllLines(filepath);


                    if (File.Exists(App.hallFile))
                    {
                        string json = File.ReadAllText(App.hallFile);

                        Hall? hall = JsonConvert.DeserializeObject<Hall>(json);

                        if (hall is not null)
                            App.hall = hall;
                        else
                            MessageBox.Show("Unable to load hall");
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "ErrorCode #1: " + ex.Message + "\n Unable to load hall";
                MessageBox.Show(errorMessage);
                DateTime dt = DateTime.Now;
                App.WriteToErrorLog(dt.ToString() + " -- " + errorMessage);
            }
        }
        #endregion

        public void LoadSessions()
        {
            if (App.hall is not null)
            {
                if (App.hall.AllSessions_ is not null && App.hall.AllSessions_.Count <= 1)
                {
                    sessionsList.ItemsSource = App.hall.AllSessions_;
                    sessionsList.SelectedIndex = 0;
                }
            }
        }

        private void StartSession_Click(object sender, RoutedEventArgs e)
        {
            if (sessionsList.SelectedIndex is not -1)
            {
                App.SelectedSession = (Session) sessionsList.SelectedItem;
                sessionsList.ItemsSource = new List<Session>();
                App.flashboardWindow = new();
                App.callerWindow = new();
                this.Hide();
                App.ShowCallerWindows();

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
            else
                MessageBox.Show("Please select a session");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Exit_Click();
        }
    }
}
