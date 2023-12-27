using BingoFlashboard.Model;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BingoFlashboard.View
{
    public partial class Register : Window
    {
        HubConnection? connection;
        Hall? hall;

        public Register()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
            .WithUrl("https://bingoappservice.azurewebsites.net/RegisterHub")
            //.WithUrl("https://localhost:7226/RegisterHub")
            .WithAutomaticReconnect()
            .Build();

            ConnectToServer();
        }

        private void ConnectToServer()
        {
            if (connection != null)
            {
                MessageLbl.Text = "";

               _ = connection.On<string>("RegisterReply", (message) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        if (message== "Incorrect Credentials")
                        {
                            MessageLbl.Text = "Incorrect Username or Password\nPlease try again";
                            MessageLbl.Foreground = new SolidColorBrush(Colors.Red);
                        }
                        else if (message == "Success")
                        {
                            MessageLbl.Text = "Password Updated";
                            MessageLbl.Foreground = new SolidColorBrush(Colors.Green);
                            System.Threading.Thread.Sleep(2500);
                            UserLogin userWindow = new UserLogin();
                            userWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageLbl.Text = message;
                            MessageLbl.Foreground = new SolidColorBrush(Colors.Red);
                        }
                    });
                });
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private async void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(NewPassword.Password == ConfirmPassword.Password)
                {


                MessageLbl.Text = "Updating Password";
                MessageLbl.Foreground = new SolidColorBrush(Colors.Yellow);

                //int? password = NewPassword.Password.GetHashCode();

                if (NewPassword.Password == ConfirmPassword.Password && connection != null)
                {
                    //byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
                    //string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    //    password: password!,
                    //    salt: salt,
                    //    prf: KeyDerivationPrf.HMACSHA256,
                    //    iterationCount: 100000,
                    //    numBytesRequested: 256 / 8));

                    await connection.StartAsync();
                    await connection.InvokeAsync("RegisterMessage", Username.Text, NewPassword.Password, TempPassword.Password);
                }
                }
                else
                {
                    MessageLbl.Text = "Passwords not matching";
                    MessageLbl.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            catch(Exception ex)
            {
                MessageLbl.Text = "Error: " + ex.Message;
            }
        }

        #region EXIT APP

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        #endregion
    }
}
