using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UpdateListMedicines
    {
        public List<GenerateMedicine> ListMedicines { get; set; }
        public CodeTimeToUser CodeTimeToUser { get; set; }
        public int CountSnooze { get; set; }
    }
}
