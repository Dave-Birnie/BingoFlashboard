using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    public class Province
    {
        public int Id_ { get; set; }
        public Country Country_ { get; set; } = new();
        public string Province_Name_ { get; set; } = string.Empty;
    }
}
