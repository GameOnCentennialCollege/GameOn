//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameOnAPIs
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDetail
    {
        public UserDetail()
        {
            this.Orders = new HashSet<Order>();
            this.Reviews = new HashSet<Review>();
        }
    
        public string UserID { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
