//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ogrenci_akademisyen.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class bolumler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bolumler()
        {
            this.ogrenciler = new HashSet<ogrenciler>();
        }
    
        public int bolum_id { get; set; }
        public string bolum_ad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ogrenciler> ogrenciler { get; set; }
    }
}
