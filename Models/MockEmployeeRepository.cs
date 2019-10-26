using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>() {
                new Employee() { Id = 1, Name = "Chris1", Email = "chris@gmail.com", Department = Dept.Accounting},
                new Employee() { Id = 2, Name = "Chris2", Email = "chris@gmail.com", Department = Dept.HR},
                new Employee() { Id = 3, Name = "Chris3", Email = "chris@gmail.com", Department = Dept.IT},
                //new Employee() { Id = 4, Name = "Chris4", Email = "chris@gmail.com", Department = "EEE"},
            };
        }
        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if(employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;

        }
    }
}