using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
   public class Hall
    {
        public int Id_ { get; set; }
        public string Name_ { get; set; } = string.Empty;
        public string Logo_ { get; set; } = string.Empty;
        public string Address_ { get; set; } = string.Empty; 
        public string City_ { get; set; } = string.Empty;
        public string Postal_ { get; set; } = string.Empty;
        public Country Country_ { get; set; } = new();
        public Province Province_ { get; set; } = new();
        public string Phone_ { get; set; } = string.Empty;
        public string Website_ { get; set; } = string.Empty;
        public string Email_ { get; set; } = string.Empty;
        public string Username_ { get; set; } = string.Empty;   
        public string Comport_ { get; set; } = string.Empty;
        public bool AutoCaller_ { get; set; }   
        public string Message_ { get; set; } = string.Empty;
        public bool Master_ { get; set; }
        public bool Active_ { get; set; }
    }
}
