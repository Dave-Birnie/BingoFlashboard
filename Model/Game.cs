using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
   internal class Game
    {
        internal int Id_ { get; set; }
        internal string Name_ { get; set; } = string.Empty;
        internal string Date_Time_ { get; set; } = string.Empty;
        internal GameColor Border_Color_ { get; set; }
        internal GameColor Font_Color_ { get; set; }
        internal string GameType_ { get; set; } = string.Empty;
        internal Pattern? Pattern_ { get; set; }
        internal string Prize_ { get; set; } = string.Empty;
        internal string Min_Prize_Amount_ { get; set; } = string.Empty;
        internal string Max_Prize_Amount_ { get; set; } = string.Empty;
        internal string Jackpot_Prize_ { get; set; } = string.Empty;
        internal string Min_Jackpot_Prize_ { get; set; } = string.Empty;
        internal string Max_Jackpot_Prize_ { get; set; } = string.Empty;
        internal string Designated_Number_ { get; set; } = string.Empty;
        internal string? Four_Ball_ { get; set; }
        internal string? Four_Ball_Prize_ { get; set; }
        internal List<Player>? Player_List { get; set; }
        internal List<Winner>? Winner { get; set; }
    }
}
