using System;

namespace DAL.Models
{
    public sealed class Employee
    {
        public Employee(
            int Id,
            string Surname,
            string Name,
            string MiddleName,
            DateTime EmploymentDate,
            int CompanyId,
            string Position,
            string CompanyName)
        {
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.MiddleName = MiddleName;
            this.EmploymentDate = EmploymentDate;
            this.CompanyId = CompanyId;
            this.Position = Position;
            this.CompanyName = CompanyName;
        }

        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public DateTime EmploymentDate { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }
    }
}

