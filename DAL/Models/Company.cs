namespace DAL.Models
{
    public sealed class Company
    {
        public Company(int Id, string Name, string OrganizationalAndLegalForm, int CountEmployees)
        {
            this.Id = Id;
            this.Name = Name;
            this.OrganizationalAndLegalForm = OrganizationalAndLegalForm;
            this.CountEmployees = CountEmployees;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string OrganizationalAndLegalForm { get; set; }

        public int CountEmployees { get; set; }
    }
}
