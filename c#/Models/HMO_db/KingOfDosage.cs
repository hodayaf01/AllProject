//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models.HMO_db
{
    using System;
    using System.Collections.Generic;
    
    public partial class KingOfDosage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KingOfDosage()
        {
            this.MedicinesToClients = new HashSet<MedicinesToClient>();
        }
    
        public int kindOfDosageId { get; set; }
        public string kindOfDosageName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicinesToClient> MedicinesToClients { get; set; }
    }
}