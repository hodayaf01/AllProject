using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ArchiveTakeMedicineDetails
    {
        //userName?
        public string NameMedicine { get; set; }
        public TimeSpan DateToken { get; set; }
        public bool OnTime { get; set; }

    }
}
