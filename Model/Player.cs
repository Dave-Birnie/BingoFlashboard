using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
   internal class Player
    {
        internal int? Id_ { get; set; }
        internal string? Username_ { get; set; }
        internal string? Email_ { get; set; }
        internal string? Phone_ { get; set; }
        internal string? Password_ { get; set; }
        internal string? Temp_Password_ { get; set; }
        internal bool? Email_Opt_In_ { get; set; }
        internal bool? Active_ { get; set; }
    }
}
