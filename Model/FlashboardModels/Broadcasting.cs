using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BingoFlashboard.Model.FlashboardModels
{
    public class Broadcasting
    {
        public string BroadcastingLive { get; private set; }
        public string BroadcastingStatus { get; private set; } = string.Empty;
        public string BroadcastingBtn { get; set; } = string.Empty;
        public bool BroadcastingEnabled { get; set; } = true;
        public Brush? BroadcastingColor { get; private set; }


        public void BroadcastingStatusSet(string status)
        {
            BroadcastingLive = status;
            ChangeBroadcasting();
        }
        public void ChangeBroadcasting()
        {

            switch (BroadcastingLive)
            {

                case "On":
                    {
                        BroadcastingBtn = "Stop Broadcast";
                        BroadcastingStatus = "On";
                        BroadcastingEnabled = true;
                        BroadcastingColor = new SolidColorBrush(Colors.Green);
                        break;
                    }
                case "Off":
                    {
                        BroadcastingBtn = "Connect Broadcast";
                        BroadcastingStatus = "Off";
                        BroadcastingEnabled = true;
                        BroadcastingColor = new SolidColorBrush(Colors.Red);
                        break;
                    }
                case "Waiting":
                    {
                        BroadcastingBtn = "Connecting...";
                        BroadcastingStatus = "Waiting..";
                        BroadcastingEnabled = true;
                        BroadcastingColor = new SolidColorBrush(Colors.Blue);
                        break;
                    }
            }
            if (App.callerWindowViewModel is not null)
            {
                App.callerWindowViewModel.BroadcastingStatus = this;
            }
        }

        public Broadcasting()
        {
            BroadcastingLive = "Off";
            ChangeBroadcasting();
        }
    }
}
