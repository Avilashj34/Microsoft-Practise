using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Assignment2.Models
{
    public class Loan
    {
        public int Loan_AccountNo { get; set; }
        public int CustomerId { get; set; }
        public decimal LoanAmount { get; set; }
        public int Loan_Term { get; set; }
        public string Loan_Int_Type { get; set; }
    }
}