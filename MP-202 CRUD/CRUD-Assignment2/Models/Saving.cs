using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Assignment2.Models
{
    public class Saving
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int AccountNo { get; set; }
        public string BranchCode { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public decimal CurrentBalance { get; set; }

        
    }
}