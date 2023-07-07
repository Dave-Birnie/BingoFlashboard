using BingoFlashboard.Model;
using BingoFlashboard.Model.FlashboardModels;
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
        #endregion PROPERTIES

        #region SET CONNECTION

        public ServerConnection()
        {
            hubConnection = new HubConnectionBuilder()
            .WithUrl("http://192.168.2.16:7226/GameHub") // Replace with the appropriate URL
            //.WithUrl("https://localhost:7226/GameHub") // Replace with the appropriate URL
            .WithAutomaticReconnect()
            .Build();

            ///LISTENER
            StartAsync();


        }//END Constructor

        private async void StartAsync()
        {
            hubConnection.On<DataTransfer>("HostResponse", responseMessage =>
            {
                try
                {
                    Application.Current.Dispatcher.Invoke(async () =>
                    {
                        // Handle the response message received from the server
                        if (responseMessage.Success_ is not null && (bool)responseMessage.Success_ && App.callerWindowViewModel is not null)
                        {
                            switch (responseMessage.TransferMessage_)
                            {
                                case "Game Connected":
                                    {

                                        App.callerWindowViewModel.AddServerMessage(responseMessage.SecondaryMessage_.ToString());
                                        MessageBox.Show(responseMessage.SecondaryMessage_);
                                        App.callerWindowViewModel.HostingStatus.HostingGameStatusSet("On");
                                        if(App.callerWindow is not null)
                                            await App.callerWindow.SendGameInfo();
                                        break;
                                    }
                                default:
                                    {
                                        App.callerWindowViewModel.AddServerMessage(responseMessage.TransferMessage_.ToString());
                                        //MessageBox.Show(responseMessage.TransferMessage_);
                                        break;
                                    }
                            }
                        }
                        else if (responseMessage.Success_ is not null && !(bool)responseMessage.Success_ && App.callerWindowViewModel is not null)
                        {
                            App.callerWindowViewModel.AddServerMessage(responseMessage.TransferMessage_.ToString());
                            MessageBox.Show(responseMessage.TransferMessage_);
                        }
                        else
                        {

                        }
                    });
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
                    DateTimeStart_ = "Jan 23 --  @ 7pm",
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

        #endregion GAME METHODS

    }
}
