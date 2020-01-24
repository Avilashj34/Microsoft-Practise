using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcept
{
    abstract class EmployeeDetail : Employee
    {
        public static int CalculateAge(DateTime DateOfBirth)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyymmdd"));
            int dob = int.Parse(DateOfBirth.ToString("yyyymmdd"));
            int age = (now - dob) / 10000;
            return age;
        }
        public double salary { get; set; }       
        public abstract void GetEmployeeDetail();
        public abstract void CalculateSalary(int presentday, double perdayammount, double workhours);
    }
}
