using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcept
{
    
    class FullTimeEmployee : EmployeeDetail
    {
        public override void CalculateSalary(int presentday, double perdayammount, double workhours)
        {
            salary = presentday * (workhours * perdayammount);
            Console.WriteLine();
        }
        public override void GetEmployeeDetail()
        {           
            Console.WriteLine("Name : {0}" + "{1} \n Age: {2} \n Address : {3} \n MobileNo. : {4}", FirstName, LastName, CalculateAge(DateOfBirth), Address,MobileNo);
        }
    }
    class PartTimeEmployee : EmployeeDetail
    {
        public override void CalculateSalary(int presentday, double perdayammount, double workhours)
        {
            salary = presentday * (workhours * perdayammount);
            Console.WriteLine();
        }
        public override void GetEmployeeDetail()
        {
            Console.WriteLine("Name : {0} + {1} \n Age: {3} \n Address : {4} \n MobileNo. : {5}", FirstName, LastName, CalculateAge(DateOfBirth), Address, MobileNo);
        }
    }

    class ContractEmployee : EmployeeDetail
    {
        public override void CalculateSalary(int presentday, double perdayammount, double workhours)
        {
            salary = presentday * (workhours * perdayammount);
            Console.WriteLine();
        }
        public override void GetEmployeeDetail()
        {
            Console.WriteLine("Name : {0} + {1} \n Age: {3} \n Address : {4} \n MobileNo. : {5}", FirstName, LastName, CalculateAge(DateOfBirth), Address, MobileNo);
        }
    }
}
