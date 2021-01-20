using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class ChildMedicin
    {
        public long userId { get; set; }
        public string midicineName { get; set; }
        public string userName { get; set; }

        public int Dosage { get; set; }
        public string kindOfDosageName { get; set; }


    }
}
