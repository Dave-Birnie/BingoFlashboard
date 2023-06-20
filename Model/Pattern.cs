using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    internal class Pattern
    {
        internal int Id_ { get; set; }
        internal string Pattern_Name_ { get; set; } = string.Empty;
        internal List<List<string>>? Pattern_ { get; set; }
        internal bool Rotating_ { get; set; } = false;
        internal List<string>? Alias_ { get; set; }
    }
}
