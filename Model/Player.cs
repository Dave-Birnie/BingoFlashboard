using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
   public class Player
    {
        public int? Id_ { get; set; }
        public string? Username_ { get; set; }
        public string? Email_ { get; set; }
        public string? Phone_ { get; set; }
        public string? Password_ { get; set; }
        public string? Temp_Password_ { get; set; }
        public bool? Email_Opt_In_ { get; set; }
        public bool? Active_ { get; set; }
    }
}
