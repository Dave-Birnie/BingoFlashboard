using BingoFlashboard.Model;
using BingoFlashboard.Model.FlashboardModels;
using BingoFlashboard.View;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
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
        bool failedServer = true;
        #endregion PROPERTIES

        #region SET CONNECTION

        public ServerConnection()
        {
            hubConnection = new HubConnectionBuilder()
            //PRODUCTION
            .WithUrl("https://bingoappservice.azurewebsites.net/GameHub")

            //DEVELOPMENT
            //.WithUrl("http://192.168.2.16:7226/GameHub") // Replace with the appropriate URL
            //.WithUrl("https://localhost:7226/GameHub") // Replace with the appropriate URL


            .WithAutomaticReconnect()
            .Build();

            ///LISTENER
            StartAsync();

            System.Timers.Timer timer = new System.Timers.Timer(3000);
            timer.Elapsed += (sender, e) =>
            {
                if (HadConnection)
                {
                    if (hubConnection.State != HubConnectionState.Connected)
                    {
                        // Use the Dispatcher to run the MessageBox.Show on the UI thread
                        if (!NotifiedLostConnection && App.callerWindowViewModel is not null)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                App.callerWindowViewModel.HostingStatus.HostingGameStatusSet("Off");
                                MessageBox.Show("Connection lost!");
                            });
                            NotifiedLostConnection = true;
                        }
                    }
                }
            };

            timer.Start();

        }//END Constructor

        private async void StartAsync()
        {
            _ = hubConnection.On<DataTransfer>("HostResponse", responseMessage =>
            {
                try
                {
                    if (responseMessage.Success_ is not null && (bool) responseMessage.Success_ && App.callerWindowViewModel is not null)
                    {
                        Application.Current.Dispatcher.Invoke(async () =>
                        {
                            // Handle the response message received from the server
                            switch (responseMessage.TransferMessage_)
                            {
                                case "Game Connected":
                                    {
                                        HadConnection = true;
                                        App.callerWindowViewModel.AddServerMessage(responseMessage.SecondaryMessage_.ToString());
                                        MessageBox.Show(responseMessage.SecondaryMessage_);
                                        App.callerWindowViewModel.HostingStatus.HostingGameStatusSet("On");
                                        if (App.callerWindow is not null)
                                            await App.callerWindow.SendGameInfo();
                                        break;
                                    }
                                case "Player Joined":
                                    {
                                        App.callerWindowViewModel.AddServerMessage(responseMessage.SecondaryMessage_.ToString());
                                        App.playerList.Add(JsonConvert.DeserializeObject<Player>(responseMessage.JsonString_));
                                        break;
                                    }
                                default:
                                    {
                                        App.callerWindowViewModel.AddServerMessage(responseMessage.TransferMessage_.ToString());
                                        //MessageBox.Show(responseMessage.TransferMessage_);
                                        break;
                                    }
                            }//END SWITCH
                        });//END DISPATCHER

                    }//END IF SUCCESS
                    else if (responseMessage.Success_ is not null && !(bool) responseMessage.Success_ && App.callerWindowViewModel is not null)
                    {
                        App.callerWindowViewModel.AddServerMessage(responseMessage.TransferMessage_.ToString());
                        MessageBox.Show(responseMessage.TransferMessage_);
                    }//END IF SUCCESS FALSE
                    else
                    {
                        try
                        {
                            switch (responseMessage.TransferMessage_)
                            {
                                case "Bingo Called":
                                    {
                                        Application.Current.Dispatcher.Invoke(async () =>
                                        {
                                            if (responseMessage.SecondaryMessage_ is not null && responseMessage.SecondaryMessage_ is not "")
                                            {
                                                bool Success = false;
                                                if (App.SelectedGame is not null && App.SelectedGame.Pattern_ is not null)
                                                {
                                                    Success = await App.SharedVerificationPage.VerifyWinnerAsync(App.calls, App.SelectedGame.Pattern_, responseMessage.SecondaryMessage_);
                                                }

                                                if (Success)
                                                {
                                                    BingoCalledWindow bingoCalledWindow = new BingoCalledWindow(responseMessage.SecondaryMessage_);
                                                    bingoCalledWindow.Show();
                                                }
                                                else
                                                {
                                                    //TODO RETURN NOT A WINNER MESSAGE
                                                }
                                            }
                                            else
                                            {
                                                if (App.callerWindow is not null)
                                                    App.callerWindow.StartFlashing();
                                            }
                                        });
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show(responseMessage.TransferMessage_);
                                        break;
                                    }
                            }//END SWITCH
                        }
                        catch (Exception ex)
                        {

                        }
                    }//END SUCCESS NULL
                }
                catch (Exception ex)
                {
                    if (App.callerWindowViewModel is not null)
                        App.callerWindowViewModel.AddServerMessage(responseMessage.SecondaryMessage_.ToString());
                    MessageBox.Show(ex.Message);
                }
            });
            // Start the SignalR connection
            try
            {
                await hubConnection.StartAsync();

                if (App.callerWindowViewModel is not null)
                {
                    App.callerWindowViewModel.AddServerMessage("Connected to server");
                    App.callerWindowViewModel.BroadcastingStatus.BroadcastingStatusSet("On");
                }
            }
            catch (Exception ex)
            {
                if (App.callerWindowViewModel is not null)
                {
                    messages.Add("Unable to connect to server.");
                    messages.Add(ex.Message);
                    App.callerWindowViewModel.AddServerMessage("Unable to connect to server");
                    App.callerWindowViewModel.BroadcastingStatus.BroadcastingStatusSet("Off");
                }
            }
        }

        #endregion SET CONNECTION

        #region GET/CLOSE CONNECTION    
        public HubConnection GetHubConnection()
        {
            return hubConnection;
        }

        public async void CloseConnection()
        {
            await hubConnection.StopAsync();
            await hubConnection.DisposeAsync();

            if (App.callerWindowViewModel is not null)
            {
                App.callerWindowViewModel.AddServerMessage("Disconnected from server");
                App.callerWindowViewModel.BroadcastingStatus.BroadcastingStatusSet("Off");
            }
        }

        #endregion GET/CLOSE CONNECTION

        #region GAME METHODS

        //Allows the flashboard app to host a new game for players to join
        public async Task HostNewGame()
        {
            try
            {
                if (hubConnection.ConnectionId is null)
                {
                    App.server = new();
                    return;
                }

                if (hubConnection.State == HubConnectionState.Disconnected)
                    await hubConnection.StartAsync();


                if (App.hall is not null)
                {
                    Hall partialHall = new Hall()
                    {
                        Id_ = App.hall.Id_,
                        Name_ = App.hall.Name_,
                        Logo_ = App.hall.Logo_,
                        Address_ = App.hall.Address_,
                        City_ = App.hall.City_,
                        Postal_ = App.hall.Postal_,
                        Country_ = App.hall.Country_,
                        Province_ = App.hall.Province_,
                        Phone_ = App.hall.Phone_,
                        Website_ = App.hall.Website_,
                        Email_ = App.hall.Email_,
                        Username_ = App.hall.Username_,
                        Login_Password_ = App.hall.Login_Password_,
                        Temp_Login_Password_ = App.hall.Temp_Login_Password_,
                        Comport_ = App.hall.Comport_,
                        Auto_Caller_ = App.hall.Auto_Caller_,
                        Message_ = App.hall.Message_,
                        Master_ = App.hall.Master_,
                        Active_ = App.hall.Active_,
                        AllSessions_ = null
                    };

                    DataTransfer dt = new()
                    {
                        TransferMessage_ = "Hall",
                        JsonString_ = JsonConvert.SerializeObject(partialHall, Formatting.Indented)
                    };

                    await hubConnection.SendAsync("HostNewGame", dt);
                }
            }
            catch (Exception ex)
            {
                if (App.callerWindowViewModel is not null)
                {
                    //messages.Add("Server Unavailable, please contact administrator.\n" + ex.Message);
                    App.callerWindowViewModel.AddServerMessage("Server Unavailable, please contact administrator.\n" + ex.Message);
                }
            }
        }

        //Allows flashboard app to send the game info to the server
        public async Task SendGameInfo(Game game)
        {
            if (App.hall is not null && App.hall.Name_ is not null)
            {
                PartialGame pt = new()
                {
                    Id_ = game.Id_,
                    HallName_ = App.hall.Name_,
                    DateTimeStart_ = App.StartTime,
                    GameName_ = game.Name_,
                    Border_Color_ = game.Border_Color_,
                    Font_Color_ = game.Font_Color_,
                    GameType_ = game.GameType_,
                    Pattern_ = game.Pattern_,
                    Prize_ = game.Prize_,
                    Jackpot_Prize_ = game.Jackpot_Prize_,
                    Designated_Number_ = game.Designated_Number_,
                    Four_Ball_ = game.Four_Ball_,
                    Four_Ball_Prize_ = game.Four_Ball_Prize_,
                };
                DataTransfer dt = new()
                {
                    TransferMessage_ = "Game",
                    JsonString_ = JsonConvert.SerializeObject(game, Formatting.Indented),
                    SecondaryMessage_ = JsonConvert.SerializeObject(pt, Formatting.Indented)
                };

                await hubConnection.SendAsync("NewGameInfo", dt);
            }

        }

        public async Task SendCalledBall(string ballnum)
        {
            if (App.hall is not null && App.hall.Name_ is not null)
            {
                DataTransfer dt = new()
                {
                    TransferMessage_ = "BallCalled",
                    JsonString_ = ballnum,
                };

                if (App.server is not null && App.server.hubConnection.State == HubConnectionState.Connected)
                    await hubConnection.SendAsync("BallCalled", dt);
                else
                {
                    if (App.callerWindowViewModel is not null && !failedServer)
                        App.callerWindowViewModel.AddServerMessage("Server not connected, please try to reconnect if you are running a live game.");
                }

            }
        }

        public async Task KillConnection()
        {
            if (App.hall is not null && App.hall.Name_ is not null)
            {
                Hall partialHall = new Hall()
                {
                    Id_ = App.hall.Id_,
                    Name_ = App.hall.Name_,
                    Logo_ = App.hall.Logo_,
                    Address_ = App.hall.Address_,
                    City_ = App.hall.City_,
                    Postal_ = App.hall.Postal_,
                    Country_ = App.hall.Country_,
                    Province_ = App.hall.Province_,
                    Phone_ = App.hall.Phone_,
                    Website_ = App.hall.Website_,
                    Email_ = App.hall.Email_,
                    Username_ = App.hall.Username_,
                    Login_Password_ = App.hall.Login_Password_,
                    Temp_Login_Password_ = App.hall.Temp_Login_Password_,
                    Comport_ = App.hall.Comport_,
                    Auto_Caller_ = App.hall.Auto_Caller_,
                    Message_ = App.hall.Message_,
                    Master_ = App.hall.Master_,
                    Active_ = App.hall.Active_,
                    AllSessions_ = null
                };

                DataTransfer dt = new()
                {
                    TransferMessage_ = "Hall",
                    JsonString_ = JsonConvert.SerializeObject(partialHall, Formatting.Indented)
                };

                if (App.server is not null && App.server.hubConnection.State == HubConnectionState.Connected)
                    await hubConnection.SendAsync("KillConnection", dt);
            }
        }

        #endregion GAME METHODS

    }
}
