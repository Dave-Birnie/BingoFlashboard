using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    internal class Session
    {
        internal int Id_ { get; set; }
        internal string Date_Time_ { get; set; } = string.Empty;
        internal string Name_ { get; set; } = string.Empty;
        internal Program? Program_ { get; set; }
    }
}
