using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Data
{
    internal class DataTransfer
    {
        public bool? Success_ { get; set; } //SENDS IF JSON REQUEST WAS SUCCESSFUL OR FAILED
        public string TransferMessage_ { get; set; } = string.Empty; //SENDS TRANSFER MESSAGE - I.E - Regiser: User already registered
        public string SecondaryMessage_ { get; set; } = string.Empty; //SENDS SECONDARY MESSAGE AS NEEDED- I.E - Regiser: User already registered
        public string JsonString_ { get; set; } = string.Empty; //WILL CONTAIN THE JSON MESSAGE TO BE DESERIALIZED
    }
}
