using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    public class Message_Log
    {
        public int Id_ { get; set; }
        public string Date_Time_ { get; set; } = string.Empty;
        public string Message_Request_ { get; set; } = string.Empty;
        public string Return_Message_ { get; set; } = string.Empty;
        public string Notes_ { get; set; } = string.Empty;
        public Hall? Hall_ { get; set; }
    }
}
