//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Login.Modeling
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public string Destination { get; set; }
    
        public virtual PostOffice PostOffice { get; set; }
        public virtual User User { get; set; }
    }
}
