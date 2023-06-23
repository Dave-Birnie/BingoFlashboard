using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BingoFlashboard.Model.FlashboardModels
{
    public class Broadcasting
    {
        public bool BroadcastingLive { get; private set; }
        public string BroadcastingStatus { get; private set; } = string.Empty;
        public string BroadcastingBtn { get; private set; } = string.Empty;
        public Brush? BroadcastingColor { get; private set; }


        public void BroadcastingBoolSet(bool status)
        {
            BroadcastingLive = status;
            ChangeBroadcasting();
        }
        public void ChangeBroadcasting()
        {
            if (BroadcastingLive)
            {
                BroadcastingBtn = "Stop Broadcast";
                BroadcastingStatus = "On";
                BroadcastingColor = new SolidColorBrush(Colors.Green);
            }
            else
            {
                BroadcastingBtn = "Start Broadcast";
                BroadcastingStatus = "Off";
                BroadcastingColor = new SolidColorBrush(Colors.Red);
            }
        }
        
        public Broadcasting()
        {
            BroadcastingLive = false;
            ChangeBroadcasting();
        }
    }
}
