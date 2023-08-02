using BingoFlashboard.Model;
using BingoFlashboard.Model.FlashboardModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        private HostingGame hostingStatus_ = new HostingGame();
        public HostingGame HostingStatus
        {
            get
            {
                return hostingStatus_;
            }
            set
            {
                hostingStatus_ = value;
                OnPropertyChanged(nameof(HostingStatus));
            }
        }

        private ObservableCollection<string> serverMessages_ = new ObservableCollection<string>() { "Welcome to Bingo Flashboard" };
        public ObservableCollection<string> ServerMessages
        {
            get { return serverMessages_; }
            set
            {
                serverMessages_ = value;
                OnPropertyChanged(nameof(ServerMessages));
            }
        }

        public void AddServerMessage(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string formattedMessage = $"{timestamp} - \t{message}";

            Application.Current.Dispatcher.Invoke(() =>
            {
                serverMessages_.Insert(0, formattedMessage);
                OnPropertyChanged(nameof(ServerMessages));
            });
        }

        private string cardNum_ = "";
        public string CardNum_
        {
            get
            {
                return cardNum_;
            }
            set
            {
                cardNum_ = value;
                OnPropertyChanged(nameof(CardNum_));
            }
        }

        //private Page verificationPage_;
        //public Page VerificationPage
        //{
        //    get
        //    {
        //        return verificationPage_;
        //    }
        //    set
        //    {
        //        verificationPage_ = value;
        //        OnPropertyChanged(nameof(VerificationPage));
        //    }
        //}
    }
}
