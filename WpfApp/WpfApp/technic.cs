//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class technic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public technic()
        {
            this.normTeches = new HashSet<normTech>();
        }
    
        public int ID { get; set; }
        public string type { get; set; }
        public string company { get; set; }
        public string model { get; set; }
        public string businessNumber { get; set; }
        public string serialNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<normTech> normTeches { get; set; }
        public virtual systemCharacteristic systemCharacteristic { get; set; }
        public virtual hardDrive hardDrives { get; set; }
    }
}
