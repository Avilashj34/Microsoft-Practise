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
    
    public partial class Loan_Account
    {
        public int Loan_AccountNo { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<decimal> LoanAmount { get; set; }
        public Nullable<int> Loan_Term { get; set; }
        public string Loan_Int_Type { get; set; }
    
        public virtual Saving_Account Saving_Account { get; set; }
    }
}
