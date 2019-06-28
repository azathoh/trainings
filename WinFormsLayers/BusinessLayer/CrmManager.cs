using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using WcfClientLayer;

namespace BusinessLayer
{
    public class CrmManager
    {
        private readonly CRMRepositorySAL repo;
        private bool run;

        public event EventHandler Signal;

        public CrmManager()
        {
            repo = new CRMRepositorySAL();
            repo.SignalFromServer += Repo_SignalFromServer;
        }


        public List<Company> FetchCompanies(CompanySearchCriteria companySearchCriteria)
        {
            if (companySearchCriteria.GetAll)
            {
                return repo.GetAllCompanies();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void Start()
        {
            Thread thread = new Thread(() =>
            {
                while (run)
                {
                    repo.SendKeepalive();
                    Thread.Sleep(5 * 1000);
                }
            });
            run = true;
            thread.Start();
        }

        public void Stop()
        {
            run = false;
        }
        
        private void Repo_SignalFromServer(object sender, EventArgs e)
        {
            Signal?.Invoke(this,e);
        }

        public List<Employee> FetchEmployees(EmployeeSearchCriteria employeeSearchCriteria)
        {
            if (!string.IsNullOrEmpty(employeeSearchCriteria.CompanyName))
            {
                return repo.GetEmployeesByCompany(employeeSearchCriteria.CompanyName);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool Validate(Tuple<long, string> companyTuple)
        {
            return true;
        }
    }
}
