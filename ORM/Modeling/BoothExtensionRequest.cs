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
    
    public partial class BoothExtensionRequest : Request
    {
        public BoothExtensionRequest()
        {
            this.ProfessionAssignments = new HashSet<ProfessionAssignment>();
        }
    
        public int Area { get; set; }
    
        public virtual Booth Booth { get; set; }
        public virtual ICollection<ProfessionAssignment> ProfessionAssignments { get; set; }
    }
}
