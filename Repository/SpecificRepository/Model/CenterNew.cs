//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpecificRepository.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CenterNew
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CenterNew()
        {
            this.CenterNewPictures = new HashSet<CenterNewPicture>();
        }
    
        public int New_ID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public System.DateTime ReleaseDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CenterNewPicture> CenterNewPictures { get; set; }
    }
}
