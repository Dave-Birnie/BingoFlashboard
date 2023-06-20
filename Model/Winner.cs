using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    internal class Winner
    {
        internal int Id_ { get; set; }
        internal string Date_Time_ { get; set; } = string.Empty;
        internal string Prize_ { get; set; } = string.Empty;
        internal List<Player>? Players_ { get; set; }
    }
}
