using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
   public class Game
    {
        public int Id_ { get; set; }
        public string Name_ { get; set; } = string.Empty;
        public string Date_Time_ { get; set; } = string.Empty;
        public string Border_Color_ { get; set; } = string.Empty;
        public string Font_Color_ { get; set; } = string.Empty;
        public string GameType_ { get; set; } = string.Empty;
        public Pattern? Pattern_ { get; set; }
        public string Patterns_ { get; set; } = string.Empty;
        public string Prize_ { get; set; } = string.Empty;
        public string Min_Prize_Amount_ { get; set; } = string.Empty;
        public string Max_Prize_Amount_ { get; set; } = string.Empty;
        public string Jackpot_Prize_ { get; set; } = string.Empty;
        public string Min_Jackpot_Prize_ { get; set; } = string.Empty;
        public string Max_Jackpot_Prize_ { get; set; } = string.Empty;
        public string Designated_Number_ { get; set; } = string.Empty;
        public string? Four_Ball_ { get; set; }
        public string? Four_Ball_Prize_ { get; set; }
        public List<Player>? Player_List { get; set; }
        public List<Winner>? Winner { get; set; }
    }
}
