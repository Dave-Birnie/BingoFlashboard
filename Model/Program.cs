using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    internal class Program
    {
        internal int Id_ { get; set; }
        internal string Name_ { get; set; } = string.Empty;
        internal List<Game>? Games_ { get; set; }
        internal List<Cardset>? Cardsets_ { get; set; }
    }
}
