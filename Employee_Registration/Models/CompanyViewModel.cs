using DAL.Models;
using System.Collections.Generic;

namespace Employee_Registration.Models
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OrganizationalAndLegalForm { get; set; }

        public int CountEmployees { get; set; }

        public Company ToCompany()
        {
            return new Company(Id, Name, OrganizationalAndLegalForm, CountEmployees)
            {
                Id = Id,
                Name = Name,
                OrganizationalAndLegalForm = OrganizationalAndLegalForm,
                CountEmployees = CountEmployees,
            };
        }

        public CompanyViewModel ToCompanyViewModel(Company company)
        {
            if (company == null)
            {
                return null;
            }

            return new CompanyViewModel
            {
                Id = company.Id,
                Name = company.Name,
                OrganizationalAndLegalForm = company.OrganizationalAndLegalForm,
                CountEmployees = company.CountEmployees
            };
        }

        public IEnumerable<CompanyViewModel> ToCompanyViewModels(IEnumerable<Company> companies)
        {
            foreach (var item in companies)
            {
                yield return ToCompanyViewModel(item);
            }
        }
    }
}
