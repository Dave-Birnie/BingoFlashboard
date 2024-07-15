using BingoFlashboard.Model;
using BingoFlashboard.Model.FlashboardModels;
using BingoFlashboard.View;
using Global_Models_Library.Flashboard_Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; // Added for ObservableCollection
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BingoFlashboard.Data
{
    public class ServerConnection
    {
        #region PROPERTIES
        private HubConnection hubConnection;
        private List<string> messages = new List<string>() { "Welcome to Bingo Flashboard" };
        private bool HadConnection = false;
        private bool NotifiedLostConnection = false;
        private bool failedServer = true;
        #endregion PROPERTIES

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes the server connection, sets up the SignalR connection and listener.
        /// </summary>
        public ServerConnection()
        {
            // Initialize the HubConnection
            hubConnection = new HubConnectionBuilder()
                //PRODUCTION
                .WithUrl("https://bingoappservice.azurewebsites.net/GameHub")
                //DEVELOPMENT
                //.WithUrl("http://192.168.2.16:7226/GameHub") // Update with the appropriate URL
                .WithAutomaticReconnect()
                .Build();

            // Start the connection and set up a listener
            StartAsync();

            // Monitor connection status
            var timer = new System.Timers.Timer(3000);
            timer.Elapsed += CheckConnectionStatus;
            timer.Start();
        }

        #endregion CONSTRUCTOR

        #region CONNECTION METHODS

        /// <summary>
        /// Starts the SignalR connection and sets up the listener for host responses.
        /// </summary>
        private async void StartAsync()
        {
            // Set up the SignalR listener
            hubConnection.On<DataTransfer>("HostResponse", HandleHostResponse);

            // Start the SignalR connection
            try
            {
                await hubConnection.StartAsync();
                NotifyConnectionStatus("Connected to server", "On");
            }
            catch (Exception ex)
            {
                NotifyConnectionStatus("Unable to connect to server", "Off");
                LogError("Unable to connect to server", ex);
            }
        }

        /// <summary>
        /// Checks the connection status and notifies if the connection is lost.
        /// </summary>
        private void CheckConnectionStatus(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (HadConnection && hubConnection.State != HubConnectionState.Connected && !NotifiedLostConnection)
            {
                NotifyConnectionStatus("Connection lost!", "Off");
                NotifiedLostConnection = true;
            }
        }

        /// <summary>
        /// Retrieves the current HubConnection.
        /// </summary>
        public HubConnection GetHubConnection() => hubConnection;

        /// <summary>
        /// Closes the SignalR connection and updates the connection status.
        /// </summary>
        public async void CloseConnection()
        {
            await hubConnection.StopAsync();
            await hubConnection.DisposeAsync();
            NotifyConnectionStatus("Disconnected from server", "Off");
        }

        #endregion CONNECTION METHODS

        #region LISTENER METHODS

        /// <summary>
        /// Handles responses from the host.
        /// </summary>
        private void HandleHostResponse(DataTransfer responseMessage)
        {
            try
            {
                if (responseMessage.Success_ == true)
                {
                    Application.Current.Dispatcher.Invoke(async () =>
                    {
                        ProcessSuccessResponse(responseMessage);
                    });
                }
                else if (responseMessage.Success_ == false)
                {
                    NotifyServerMessage(responseMessage.TransferMessage_);
                }
                else
                {
                    HandleSpecialCases(responseMessage);
                }
            }
            catch (Exception ex)
            {
                NotifyServerMessage(responseMessage.SecondaryMessage_);
                LogError("Error processing host response", ex);
            }
        }

        /// <summary>
        /// Processes successful responses from the host.
        /// </summary>
        private void ProcessSuccessResponse(DataTransfer responseMessage)
        {
            switch (responseMessage.TransferMessage_)
            {
                case "Game Connected":
                HadConnection = true;
                NotifyServerMessage(responseMessage.SecondaryMessage_);
                App.callerWindowViewModel.HostingStatus.HostingGameStatusSet("On");
                App.callerWindow?.SendGameInfo();
                break;

                case "Player Joined":
                NotifyServerMessage(responseMessage.SecondaryMessage_);
                App.playerList.Add(JsonConvert.DeserializeObject<Player>(responseMessage.JsonString_));
                break;

                default:
                NotifyServerMessage(responseMessage.TransferMessage_);
                break;
            }
        }

        /// <summary>
        /// Handles special case responses from the host.
        /// </summary>
        private void HandleSpecialCases(DataTransfer responseMessage)
        {
            switch (responseMessage.TransferMessage_)
            {
                case "Bingo Called":
                Application.Current.Dispatcher.InvokeAsync(async () =>
                {
                    await ProcessBingoCall(responseMessage);
                });
                break;

                default:
                MessageBox.Show(responseMessage.TransferMessage_);
                break;
            }
        }

        /// <summary>
        /// Processes bingo call responses.
        /// </summary>
        private async Task ProcessBingoCall(DataTransfer responseMessage)
        {
            if (!string.IsNullOrEmpty(responseMessage.SecondaryMessage_))
            {
                bool goodBingo = await App.SharedVerificationPage.CheckMobileWinner(responseMessage.SecondaryMessage_, "");

                if (goodBingo)
                {
                    var cbs = new CalledBingos
                    {
                        CardNum_ = responseMessage.SecondaryMessage_,
                        Source_ = "Phone App",
                        GoodBingo_ = true
                    };
                    App.callerWindowViewModel.Bingos_ ??= new ObservableCollection<CalledBingos>(); // Ensure Bingos_ is an ObservableCollection
                    App.callerWindowViewModel.Bingos_.Add(cbs);

                    var win = new Winner { Winner_Time = DateTime.Now.ToString() };
                    App.winnerList.Add(win);
                    App.callerWindowViewModel.CardNum_ = responseMessage.SecondaryMessage_;

                    if (!App.BingoCalled)
                    {
                        new BingoCalledWindow(responseMessage.SecondaryMessage_).Show();
                        App.BingoCalled = true;
                    }
                }
                else
                {
                    // Handle bad bingo case
                }
            }
            else
            {
                App.callerWindow?.StartFlashing();
            }
        }

        #endregion LISTENER METHODS

        #region GAME METHODS

        /// <summary>
        /// Hosts a new game.
        /// </summary>
        public async Task HostNewGame()
        {
            try
            {
                if (hubConnection.ConnectionId == null)
                {
                    App.server = new();
                    return;
                }

                if (hubConnection.State == HubConnectionState.Disconnected)
                    await hubConnection.StartAsync();

                // Example of sending a new game to the server
                // Uncomment and implement according to your needs
            }
            catch (Exception ex)
            {
                NotifyServerMessage("Server Unavailable, please contact administrator.\n" + ex.Message);
                LogError("Error hosting new game", ex);
            }
        }

        /// <summary>
        /// Sends game information to the server.
        /// </summary>
        public async Task SendGameInfo(Game game)
        {
            // Example of sending game info to the server
            // Uncomment and implement according to your needs
        }

        /// <summary>
        /// Sends the called ball information to the server.
        /// </summary>
        public async Task SendCalledBall(string ballnum)
        {
            if (App.hall != null && App.hall.Hall_Name != null)
            {
                var dt = new DataTransfer
                {
                    TransferMessage_ = "BallCalled",
                    JsonString_ = ballnum,
                    SecondaryMessage_ = App.flashboardViewModel.BallCount.ToString()
                };

                if (hubConnection.State == HubConnectionState.Connected)
                {
                    await hubConnection.SendAsync("BallCalled", dt);
                }
                else
                {
                    NotifyServerMessage("Server not connected, please try to reconnect if you are running a live game.");
                }
            }
        }

        /// <summary>
        /// Kills the current connection.
        /// </summary>
        public async Task KillConnection()
        {
            // Example of killing the connection
            // Uncomment and implement according to your needs
        }

        #endregion GAME METHODS

        #region HELPER METHODS

        /// <summary>
        /// Notifies the application about the connection status.
        /// </summary>
        private void NotifyConnectionStatus(string message, string status)
        {
            if (App.callerWindowViewModel != null)
            {
                App.callerWindowViewModel.AddServerMessage(message);
                App.callerWindowViewModel.BroadcastingStatus.BroadcastingStatusSet(status);
            }
        }

        /// <summary>
        /// Notifies the application about a server message.
        /// </summary>
        private void NotifyServerMessage(string message)
        {
            if (App.callerWindowViewModel != null)
            {
                App.callerWindowViewModel.AddServerMessage(message);
            }
            MessageBox.Show(message);
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        private void LogError(string message, Exception ex)
        {
            // Implement logging framework or method to log errors
            Console.WriteLine($"{message}: {ex.Message}");
        }

        #endregion HELPER METHODS
    }
}
