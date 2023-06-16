using BingoFlashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
    }
}
