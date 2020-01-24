using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            Validation v = new Validation();
            Console.WriteLine("Enter Firstname, LastName, DOB (in format yyyymmdd), Address, MobileNo");
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee
            {
                FirstName = v.validateString(Console.ReadLine()),
                LastName = v.validateString(Console.ReadLine()),
                DateOfBirth = DateTime.ParseExact(Console.ReadLine(),"yyyymmdd", CultureInfo.InvariantCulture),
                Address = v.validateString(Console.ReadLine()),
                MobileNo = (long.Parse(v.ValidateInteger(Console.ReadLine())))
            };
            fullTimeEmployee.GetEmployeeDetail();
            fullTimeEmployee.CalculateSalary(28,833.33,9.5);
            
            PartTimeEmployee partTimeEmployee = new PartTimeEmployee
            {
                FirstName = v.validateString(Console.ReadLine()),
                LastName = v.validateString(Console.ReadLine()),
                DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "yyyymmdd", CultureInfo.InvariantCulture),
                Address = v.validateString(Console.ReadLine()),
                MobileNo = int.Parse(v.ValidateInteger(Console.ReadLine()))
            };
            partTimeEmployee.GetEmployeeDetail();
            partTimeEmployee.CalculateSalary(28, 833.33, 5.5);

            ContractEmployee contractTimeEmployee = new ContractEmployee
            {
                FirstName = v.validateString(Console.ReadLine()),
                LastName = v.validateString(Console.ReadLine()),
                DateOfBirth = DateTime.ParseExact(Console.ReadLine(), "yyyymmdd", CultureInfo.InvariantCulture),
                Address = v.validateString(Console.ReadLine()),
                MobileNo = int.Parse(v.ValidateInteger(Console.ReadLine()))
            };
            contractTimeEmployee.GetEmployeeDetail();
            contractTimeEmployee.CalculateSalary(28, 633.33, 9.5);
            Console.ReadKey();
            }
    }
}
