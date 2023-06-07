using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    public class Program
    {
        public int Id_ { get; set; }
        public string Name_ { get; set; } = string.Empty;
        public List<Game>? Games_ { get; set; }
        public List<Cardset>? Cardsets_ { get; set; }
    }
}
