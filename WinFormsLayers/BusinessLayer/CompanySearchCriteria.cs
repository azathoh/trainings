namespace BusinessLayer
{
    public class CompanySearchCriteria
    {
        private string companyName;
        public bool GetAll { get; }

        public CompanySearchCriteria(string name)
        {
    
            if (name != null)
            {
                companyName = name;
                GetAll = false;
            }
            else
            {
                GetAll = true;
            }
        }
    }
}
