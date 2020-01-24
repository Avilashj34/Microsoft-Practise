using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementCore.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> listEmployee=new List<Employee>();
        public MockEmployeeRepository()
        {
            listEmployee = new List<Employee>()
                            {
                                new Employee { Id=1,Name="Avilash",Course="Java"}  ,
                                new Employee { Id=2, Name="Priyal",Course=".Net"}
                            };
        }

        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int id)
        {
            listEmployee.FirstOrDefault(e => e.Id == id);
            return null;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            return listEmployee.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
