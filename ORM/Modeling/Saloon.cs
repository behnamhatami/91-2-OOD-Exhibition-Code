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
    
    public partial class Saloon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
    
        public virtual Map Map { get; set; }
        public virtual Exhibition Exhibition { get; set; }
    }
}
