//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeadShop.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Call
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Call()
        {
            this.Leads = new HashSet<Lead>();
        }
    
        public int CallId { get; set; }
        public int UserId { get; set; }
        public System.DateTime CallDatetime { get; set; }
        public int CallDuration { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lead> Leads { get; set; }
    }
}
