//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedicinesToChild
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedicinesToChild()
        {
            this.TimeToMedicinesForChilds = new HashSet<TimeToMedicinesForChild>();
        }
    
        public long Id { get; set; }
        public long medicineId { get; set; }
        public long childId { get; set; }
        public int Dosage { get; set; }
        public long kindOfDosage { get; set; }
    
        public virtual KingOfDosage KingOfDosage { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeToMedicinesForChild> TimeToMedicinesForChilds { get; set; }
    }
}
