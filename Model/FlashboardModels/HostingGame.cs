using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BingoFlashboard.Model.FlashboardModels
{
    public class HostingGame
    {
        public string HostingGameLive { get; private set; } = string.Empty;
        public string HostingGameStatus { get; private set; } = string.Empty;
        public string HostingGameBtn { get; set; } = string.Empty;
        public Brush? HostingGameColor { get; private set; }


        public void HostingGameStatusSet(string status)
        {
            HostingGameLive = status;
            ChangeHostingGame();
        }
        public void ChangeHostingGame()
        {

            switch (HostingGameLive)
            {

                case "On":
                    {
                        HostingGameBtn = "Stop Hosting";
                        HostingGameStatus = "On";
                        HostingGameColor = new SolidColorBrush(Colors.Green);
                        if (App.callerWindow is not null) App.callerWindow.BroadcastingGame = true;
                        break;
                    }
                case "Off":
                    {
                        HostingGameBtn = "Host Game";
                        HostingGameStatus = "Off";
                        HostingGameColor = new SolidColorBrush(Colors.Red);
                        if (App.callerWindow is not null)
                            App.callerWindow.BroadcastingGame = false;
                        break;
                    }
                case "Waiting":
                    {
                        HostingGameBtn = "Connecting...";
                        HostingGameStatus = "Waiting..";
                        HostingGameColor = new SolidColorBrush(Colors.Blue);
                        if (App.callerWindow is not null)
                            App.callerWindow.BroadcastingGame = false;
                        break;
                    }
            }
            if (App.callerWindowViewModel is not null)
            {
                App.callerWindowViewModel.HostingStatus = this;
            }
        }

        public HostingGame()
        {
            HostingGameLive = "Off";
            ChangeHostingGame();
        }
    }
}
