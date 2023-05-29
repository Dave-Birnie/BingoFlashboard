using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    public class Pattern
    {
        public string PatternName_ { get; set; } = string.Empty;
        public List<List<string>>? Pattern_ { get; set; }
        public bool Rotating_ { get; set; } = false;
        public List<string>? Alias_ { get; set; }
    }
}
