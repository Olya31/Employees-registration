using DAL.Models;
using System;
using System.Collections.Generic;

namespace Employee_Registration.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public DateTime EmploymentDate { get; set; }

        public int CompanyId { get; set; }

        public string Position { get; set; }

        public string CompanyName { get; set; }

        public Employee ToEmployee()
        {
            return new Employee(Id, Surname, Name, MiddleName, EmploymentDate, CompanyId, Position, CompanyName)
            {
                Id = Id,
                Surname = Surname,
                Name = Name,
                MiddleName = MiddleName,
                EmploymentDate = EmploymentDate,
                CompanyId = CompanyId,
                Position = Position,
                CompanyName = CompanyName
            };
        }

        public EmployeeViewModel ToEmployeeViewModel(Employee employee)
        {
            if (employee == null)
            {
                return null;
            }

            return new EmployeeViewModel
            {
                Id = employee.Id,
                Surname = employee.Surname,
                Name = employee.Name,
                MiddleName = employee.MiddleName,
                EmploymentDate = employee.EmploymentDate,
                CompanyId = employee.CompanyId,
                Position = employee.Position,
                CompanyName = employee.CompanyName
            };
        }

        public IEnumerable<EmployeeViewModel> ToEmployeeViewModels(IEnumerable<Employee> employees)
        {
            var result = new List<EmployeeViewModel>();

            foreach (var item in employees)
            {
                result.Add(ToEmployeeViewModel(item));
            }

            return result;
        }
    }
}
