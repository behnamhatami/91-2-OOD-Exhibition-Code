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
    
    public partial class BoothRequest : Request
    {
        public string Quality { get; set; }
        public int OperatorCount { get; set; }
        public bool ForSell { get; set; }
        public int Area { get; set; }
        public bool ForVitrin { get; set; }
        public bool ForCommision { get; set; }
        public bool HasPhone { get; set; }
        public bool HasCardReader { get; set; }
    }
}
