using BingoFlashboard.Model;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BingoFlashboard.Data
{
    public class ServerConnection
    {
        private HubConnection hubConnection;
        private List<string> messages = new List<string>() { "Welcome to Bingo Flashboard" };

        public ServerConnection()
        {
            hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7226/GameHub") // Replace with the appropriate URL
            .WithAutomaticReconnect()
            .Build();

            ///LISTENER
            StartAsync();

            
        }//END Constructor

        private async void StartAsync()
        {
            hubConnection.On<DataTransfer>("HostResponse", responseMessage =>
            {
                // Handle the response message received from the server
                if (responseMessage.Success_)
                {
                    if (App.callerWindowViewModel is not null)
                    {
                        messages.Add(responseMessage.TransferMessage_);
                        App.callerWindowViewModel.ServerMessages = messages;
                        App.callerWindowViewModel.BroadcastingStatus.BroadcastingStatusSet("On");
                    }
                    MessageBox.Show(responseMessage.TransferMessage_);
                }
                else
                {
                    if (App.callerWindowViewModel is not null)
                    {
                        messages.Add(responseMessage.TransferMessage_);
                        App.callerWindowViewModel.ServerMessages = messages;
                        App.callerWindowViewModel.BroadcastingStatus.BroadcastingStatusSet("Off");
                    }
                    MessageBox.Show(responseMessage.TransferMessage_);
                }
            });
            // Start the SignalR connection
            try
            {
                await hubConnection.StartAsync();


            }
            catch (Exception ex)
            {
                if (App.callerWindowViewModel is not null)
                {
                    messages.Add("Unable to connect to server.");
                    messages.Add(ex.Message);
                    App.callerWindowViewModel.ServerMessages = messages;
                    App.callerWindowViewModel.BroadcastingStatus.BroadcastingStatusSet("Off");
                }
            }
        }

        public HubConnection GetHubConnection()
        {
            return hubConnection;
        }


        public async void HostNewGame()
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
                    messages.Add("Server Unavailable, please contact administrator.\n" + ex.Message);
                    App.callerWindowViewModel.ServerMessages = messages;
                }
            }
        }

        public async void SendGameInfo()
        {
            DataTransfer dt = new()
            {
                TransferMessage_ = "Game",
                JsonString_ = JsonConvert.SerializeObject(App.SelectedGame, Formatting.Indented)
            };
            
            await hubConnection.SendAsync("NewGameInfo", dt);
        }
        public async void CloseConnection()
        {
            await hubConnection.DisposeAsync();
        }
    }
}
