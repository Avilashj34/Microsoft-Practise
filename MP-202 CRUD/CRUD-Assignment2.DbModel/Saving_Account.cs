//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_Assignment2.DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Saving_Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Saving_Account()
        {
            this.Loan_Account = new HashSet<Loan_Account>();
        }
    
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountNo { get; set; }
        public string BranchCode { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public decimal CurrentBalance { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan_Account> Loan_Account { get; set; }

        public static implicit operator Saving_Account(List<object> v)
        {
            throw new NotImplementedException();
        }
    }
}
