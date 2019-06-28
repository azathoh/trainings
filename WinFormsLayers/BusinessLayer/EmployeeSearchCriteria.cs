namespace BusinessLayer
{
    public class EmployeeSearchCriteria
    {
        public string CompanyName { get; }

        public EmployeeSearchCriteria(string companyName)
        {
            this.CompanyName = companyName;
        }
    }
}