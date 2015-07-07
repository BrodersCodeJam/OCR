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
    
    public partial class Applications
    {
        public Applications()
        {
            this.ApplicationHistory = new HashSet<ApplicationHistory>();
            this.Documents = new HashSet<Documents>();
        }
    
        public int ID { get; set; }
        public int FK_CustomerID { get; set; }
        public string Deed { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> DepositAmount { get; set; }
        public Nullable<decimal> LoanAmount { get; set; }
        public Nullable<System.DateTime> OccupationalDate { get; set; }
        public Nullable<decimal> OccupationalRent { get; set; }
        public Nullable<System.DateTime> OTPExpiryDate { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    
        public virtual ICollection<ApplicationHistory> ApplicationHistory { get; set; }
        public virtual CustomerInfo CustomerInfo { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
    }
}
