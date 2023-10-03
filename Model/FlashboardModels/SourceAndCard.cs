using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model.FlashboardModels
{
    public class SourceAndCard
    {
        /// <summary>
        /// Either from Mobile or from CallerControls
        /// </summary>
        public string Source { get; set; } = string.Empty;
        public string Card_ID { get; set; } = string.Empty;
    }
}
