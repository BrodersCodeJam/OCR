//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace brodersService
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerInfo
    {
        public CustomerInfo()
        {
            this.Applications = new HashSet<Applications>();
        }
    
        public int ID { get; set; }
        public int FK_DigitalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSBCustomer { get; set; }
        public Nullable<decimal> TotalSalary { get; set; }
        public Nullable<decimal> TotalExpenses { get; set; }
        public string IDNumber { get; set; }
        public string IncomeTaxNumber { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Cellnumber { get; set; }
        public string Relationship { get; set; }
    
        public virtual ICollection<Applications> Applications { get; set; }
        public virtual DigitalIds DigitalIds { get; set; }
    }
}
