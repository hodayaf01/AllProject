﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Registration
    {
        public User NewUser { get; set; }
        public List<Guardian> Guardians { get; set; }

    }
}
