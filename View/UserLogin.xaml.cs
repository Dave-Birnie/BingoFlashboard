using BingoFlashboard.Data;
using BingoFlashboard.Model;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BingoFlashboard.View
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        HubConnection connection;

        public UserLogin()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
            .WithUrl("https://bingoappservice.azurewebsites.net/LoginHub")
            //.WithUrl("https://localhost:7226/LoginHub")

            .WithAutomaticReconnect()
            .Build();
            ConnectToServer();
            Startup();

        }

        private void Startup()
        {
            if (App.startupFile != null)
            {
                if (File.Exists(App.startupFile))
                {
                    string jsonTxt = File.ReadAllText(App.startupFile);
                    StartupClass? sc = JsonConvert.DeserializeObject<StartupClass>(jsonTxt);

                    if (sc != null)
                    {
                        Username.Text = sc.UserName;
                        UserPassword.Password = sc.Password;
                        App.startup = sc;
                        CheckboxRemember.IsChecked = true;
                    }
                }
            }
        }

        private void ConnectToServer()
        {
            if (connection != null)
            {
                _ = connection.On<string, string>("LoginReply", (credentials, jsonHallInfo) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {

                        Hall? bh = JsonConvert.DeserializeObject<Hall>(jsonHallInfo);

                        if (bh != null)
                        {
                            App.hall = bh;
                        }

                        if (credentials == "Success")
                        {
                            MessageLbl.Text = "Success";
                            MessageLbl.Foreground = new SolidColorBrush(Colors.Green);

                            if (CheckboxRemember.IsChecked != null)
                            {
                                if ((bool) CheckboxRemember.IsChecked)
                                {
                                    App.startup.UserName = Username.Text;
                                    App.startup.Password = UserPassword.Password;
                                    App.SaveStartupFile();
                                }
                            }

                            //TODO - Get and update startupFile

                            System.Threading.Thread.Sleep(1500);
                            App.startupWindow = new StartupWindow();
                            App.startupWindow.Show();
                            this.Close();
                        }
                        else if (credentials == "Success - Temp Password")
                        {
                            Register registerWindow = new Register();
                            registerWindow.Username.Text = Username.Text;
                            registerWindow.TempPassword.Password = UserPassword.Password;
                            registerWindow.Show();
                            this.Hide();
                        }
                        else if (credentials == "Incorrect Credentials")
                        {
                            MessageLbl.Text = "Incorrect Username or Password\nPlease try again";
                            MessageLbl.Foreground = new SolidColorBrush(Colors.Yellow);
                        }
                        else
                        {
                            MessageLbl.Text = credentials;
                            MessageLbl.Foreground = new SolidColorBrush(Colors.Yellow);
                        }
                    });
                });
            }
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserPassword.Password != "" && Username.Text != "")
                {
                    Login.IsEnabled = false;
                    MessageLbl.Text = "Signing In";
                    MessageLbl.Foreground = new SolidColorBrush(Colors.Yellow);
                    if (connection.State == HubConnectionState.Disconnected)
                        await connection.StartAsync();
                        await connection.InvokeAsync("LoginMessage", Username.Text, UserPassword.Password);
                }
                else
                {
                    MessageLbl.Text = "Please enter both Username and Password";
                    MessageLbl.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            catch (Exception ex)
            {
                MessageLbl.Text = "Error: " + ex.Message;
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Show();
            this.Hide();
        }

        #region Window_MouseDown and ExitApp_Click
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        #endregion

    }
}
