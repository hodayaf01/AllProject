using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GenerateMedicine
    {
        public int Points { get; set; }
        public long Id { get; set; }
        public string MedicineName { get; set; }
        public int Dosage { get; set; }
        public string DosageName { get; set; }
        public bool Status { get; set; }

        public TimeSpan Time { get; set; }
    }
}
