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
    
    public partial class User
    {
        public User()
        {
            this.UserExhibitionRoles = new HashSet<UserExhibitionRole>();
            this.PollUsers = new HashSet<PollUser>();
            this.Notifications = new HashSet<Notification>();
            this.WareHouseItems = new HashSet<WareHouseItem>();
            this.PostItems = new HashSet<PostItem>();
            this.Payments = new HashSet<Payment>();
            this.Booths = new HashSet<Booth>();
            this.Requests = new HashSet<Request>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string FamilyName { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
    
        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<UserExhibitionRole> UserExhibitionRoles { get; set; }
        public virtual ICollection<PollUser> PollUsers { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<WareHouseItem> WareHouseItems { get; set; }
        public virtual ICollection<PostItem> PostItems { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Booth> Booths { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
