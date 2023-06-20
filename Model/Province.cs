using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    internal class Province
    {
        internal int Id_ { get; set; }
        internal Country Country_ { get; set; } = new();
        internal string Province_Name_ { get; set; } = string.Empty;
    }
}
