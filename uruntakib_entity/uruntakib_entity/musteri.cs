//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace uruntakib_entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public musteri()
        {
            this.satislar = new HashSet<satislar>();
        }
    
        public int musteri_id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public Nullable<short> sehir_no { get; set; }
        public Nullable<decimal> bakiye { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<satislar> satislar { get; set; }
        public virtual sehirler sehirler { get; set; }
    }
}