using BingoFlashboard.Data;
using BingoFlashboard.Model;
using Global_Models_Library.Flashboard_Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
                //PRODUCTION
                .WithUrl("https://bingoappservice.azurewebsites.net/LoginHub")
                //DEVELOPMENT
                //.WithUrl("http://192.168.2.16:7226/LoginHub")
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

        private async void ConnectToServer()
        {
            if (connection != null)
            {
                connection.On<string, string>("LoginReply", (credentials, jsonHallInfo) =>
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
                            MessageLabel("Success", new SolidColorBrush(Colors.Green));

                            if (CheckboxRemember.IsChecked is not null && (bool) CheckboxRemember.IsChecked)
                            {
                                App.startup.UserName = Username.Text;
                                App.startup.Password = UserPassword.Password;
                                App.SaveStartupFile();
                            }

                            if(bh.Hall_Id is not null)
                            App.LoadHallInformation((int)bh.Hall_Id);

                            //System.Threading.Thread.Sleep(1500);
                            App.startupWindow = new StartupWindow();
                            App.startupWindow.Show();
                            this.Close();
                        }
                        else if (credentials == "Success - Temp Password")
                        {
                            Register registerWindow = new Register
                            {
                                Username = { Text = Username.Text },
                                TempPassword = { Password = UserPassword.Password }
                            };
                            registerWindow.Show();
                            this.Hide();
                        }
                        else if (credentials == "Incorrect Credentials")
                        {
                            MessageLabel(true, "Incorrect Username or Password\nPlease try again");
                        }
                        else
                        {
                            MessageLabel(false, credentials);
                        }
                    });
                });

                try
                {
                    await connection.StartAsync();
                    MessageLabel(false, "Connected to server");

                }
                catch (Exception ex)
                {
                    MessageLabel(true, $"Connection failed: {ex.Message}");
                }
            }
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(UserPassword.Password) && !string.IsNullOrEmpty(Username.Text))
                {
                    Login.IsEnabled = false;
                    MessageLabel(false, "Signing In");

                    if (connection.State == HubConnectionState.Disconnected)
                    {
                        await connection.StartAsync();
                    }

                    await connection.InvokeAsync("LoginMessage", Username.Text, UserPassword.Password);
                }
                else
                {
                    MessageLabel(true, "Please enter both Username and Password");
                }
            }
            catch (Exception ex)
            {
                MessageLabel(true, "Error: " + ex.Message);
            }
            finally
            {
                Login.IsEnabled = true; // Re-enable login button after process
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

        private void MessageLabel(bool error, string message)
        {
            MessageLbl.Text = message;
            MessageLbl.Foreground = error ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Yellow);
        }        
        private void MessageLabel(string message, SolidColorBrush color)
        {
            MessageLbl.Text = message;
            MessageLbl.Foreground = color;
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        #endregion
    }
}
