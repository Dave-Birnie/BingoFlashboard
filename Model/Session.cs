﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoFlashboard.Model
{
    public class Session
    {
        public int Id_ { get; set; }
        public string Date_Time_ { get; set; } = string.Empty;
        public string Name_ { get; set; } = string.Empty;
        public Program? Program_ { get; set; }
    }
}
