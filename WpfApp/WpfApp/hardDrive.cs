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
    
    public partial class hardDrive
    {
        public int PCID { get; set; }
        public string company { get; set; }
        public string serialNumber { get; set; }
        public string space { get; set; }
    
        public virtual technic technic { get; set; }
    }
}