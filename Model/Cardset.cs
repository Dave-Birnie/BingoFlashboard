using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    internal class Cardset
    {
        internal int Id_ { get; set; }
        internal string Set_Name_ { get; set; } = string.Empty;
        internal List<Card>? Card_ { get; set; }
    }
}
