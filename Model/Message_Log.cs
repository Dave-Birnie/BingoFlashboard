using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    internal class Message_Log
    {
        internal int Id_ { get; set; }
        internal string Date_Time_ { get; set; } = string.Empty;
        internal string Message_Request_ { get; set; } = string.Empty;
        internal string Return_Message_ { get; set; } = string.Empty;
        internal string Notes_ { get; set; } = string.Empty;
        internal Hall? Hall_ { get; set; }
    }
}
