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
    
    public partial class PhoneNews : Notification
    {
        public PhoneNews()
        {
            this.PhoneInformations = new HashSet<PhoneInformation>();
        }
    
    
        public virtual ICollection<PhoneInformation> PhoneInformations { get; set; }
    }
}