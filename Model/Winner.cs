using BingoFlashboard.Model.FlashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    public class Winner
    {
        public int Id_ { get; set; }
        public string Date_Time_ { get; set; } = string.Empty;
        public string Prize_ { get; set; } = string.Empty;
        public List<SourceAndCard>? Winner_ { get; set; }
    }
}
