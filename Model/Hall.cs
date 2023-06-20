using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BingoFlashboard.Model
{
    internal class Hall
    {
        internal int Id_ { get; set; }
        internal string Name_ { get; set; } = string.Empty;
        internal string? Logo_ { get; set; }
        internal string? Address_ { get; set; } = string.Empty;
        internal string? City_ { get; set; } = string.Empty;
        internal string? Postal_ { get; set; } = string.Empty;
        internal Country? Country_ { get; set; } = new();
        internal Province? Province_ { get; set; } = new();
        internal string? Phone_ { get; set; } = string.Empty;
        internal string? Website_ { get; set; } = string.Empty;
        internal string? Email_ { get; set; } = string.Empty;
        internal string? Username_ { get; set; } = string.Empty;
        internal string? Login_Password_ { get; set; } = string.Empty;
        internal string? Temp_Login_Password_ { get; set; } = string.Empty;
        internal string? Comport_ { get; set; } = string.Empty;
        internal bool? Auto_Caller_ { get; set; } = false;
        internal string? Message_ { get; set; } = string.Empty;
        internal bool? Master_ { get; set; } = false;
        internal bool? Active_ { get; set; } = true;

        internal List<Session>? AllSessions_ { get; set; }
    }
}
