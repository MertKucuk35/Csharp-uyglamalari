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
    
    public partial class urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public urunler()
        {
            this.satislar = new HashSet<satislar>();
        }
    
        public int id { get; set; }
        public string urun_ad { get; set; }
        public Nullable<short> marka_no { get; set; }
        public Nullable<short> tur_no { get; set; }
        public Nullable<decimal> alis_fiyat { get; set; }
        public Nullable<decimal> satisfiyat { get; set; }
        public Nullable<short> stok { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<satislar> satislar { get; set; }
        public virtual urun_tur urun_tur { get; set; }
        public virtual markalar markalar { get; set; }
    }
}
