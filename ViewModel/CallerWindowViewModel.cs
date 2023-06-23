using BingoFlashboard.Model;
using BingoFlashboard.Model.FlashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BingoFlashboard.ViewModel
{
    public class CallerWindowViewModel : ViewModelBase
    {
        private Game selected_game_ = new();
        public Game SelectedGame
        {
            get
            {
                return selected_game_;
            }
            set
            {
                selected_game_ = value;
                OnPropertyChanged(nameof(SelectedGame));
            }
        }

        private Visibility jackpotGameSection_;
        public Visibility JackpotGameSection
        {
            get
            {
                return jackpotGameSection_;
            }
            set
            {
                jackpotGameSection_ = value;
                OnPropertyChanged(nameof(JackpotGameSection));
            }
        }

        //private string broadcastingStatus_ = "OFF";
        //public string BroadcastingStatus
        //{
        //    get
        //    {
        //        return broadcastingStatus_;
        //    }
        //    set
        //    {
        //        broadcastingStatus_ = value;
        //        OnPropertyChanged(nameof(BroadcastingStatus));
        //    }
        //}

        //private Brush broadcastingColor_;
        //public Brush BroadcastingColor
        //{
        //    get
        //    {
        //        return broadcastingColor_;
        //    }
        //    set
        //    {
        //        broadcastingColor_ = value;
        //        OnPropertyChanged(nameof(BroadcastingColor));
        //    }
        //}

        //private string broadcastingBtn = "Go Live";
        //public string BroadcastingBtn
        //{
        //    get
        //    {
        //        return broadcastingBtn;
        //    }
        //    set
        //    {
        //        broadcastingBtn = value;
        //        OnPropertyChanged(nameof(BroadcastingBtn));
        //    }
        //}

        private Broadcasting broadcastingStatus_ = new Broadcasting();
        public Broadcasting BroadcastingStatus
        {
            get
            {
                return broadcastingStatus_;
            }
            set
            {
                broadcastingStatus_ = value;
                OnPropertyChanged(nameof(BroadcastingStatus));
            }
        }

        private List<string> serverMessages_;//= new List<string>() { "Welcome to Bingo Flashboard"};
        public List<string> ServerMessages
        {
            get
            {
                return serverMessages_;
            }
            set
            {
                serverMessages_ = value;
                OnPropertyChanged(nameof(ServerMessages));
            }
        }
    }
}
