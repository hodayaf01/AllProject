﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CodeTimeToUser
    {
        public long UserID { get; set; }
        public int TimeOfDay { get; set; }
        public int CountSnooze { get; set; }
    }
}
