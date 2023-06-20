using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    public class Cardset
    {
        public int Id_ { get; set; }
        public string Set_Name_ { get; set; } = string.Empty;
        public List<Card>? Card_ { get; set; }
    }
}
