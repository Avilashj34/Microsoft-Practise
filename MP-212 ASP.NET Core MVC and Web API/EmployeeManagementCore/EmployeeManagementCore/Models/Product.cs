using System;
using System.Collections.Generic;

namespace EmployeeManagementCore.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public int? UnitPrice { get; set; }
        public int? AvailableQuantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
