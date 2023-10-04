using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model.FlashboardModels
{
    public class CalledBingos
    {
        public string PlayerName_ { get; set; } = "N/A";
        public string Source_ { get; set; } = string.Empty;
        public string CardNum_ { get; set; } = string.Empty;
        public bool GoodBingo_ { get; set; }
    }
}
