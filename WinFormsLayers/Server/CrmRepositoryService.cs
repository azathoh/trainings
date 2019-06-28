using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using Contracts;

namespace Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.Single)]
    public class CrmRepositoryService : ICRMRepository
    {
       private readonly DataBaseStub dataBaseStub = new DataBaseStub();

        public IEnumerable<Company> GetAllCompanies()
        {
            Console.WriteLine("GetAllCompanies() <-- ");

      

            foreach (var company in dataBaseStub.Companies)
            {
                company.Employees =
                    dataBaseStub.Employees.Where(e =>
                        dataBaseStub.CompanyEmployeeAssociation
                            .Where(t => t.Item1 == company.Id)
                            .Select(t => t.Item2).Contains(e.Id));
                yield return company;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            
            Console.WriteLine("GetAllEmployees() <-- ");
            return dataBaseStub.Employees;
        }

        public IEnumerable<Employee> GetEmployeesByCompany(string companyName)
        {
            Console.WriteLine("GetEmployeesByCompany() <-- ");
    
            var company = dataBaseStub.Companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                throw new Exception($"Company with name : {companyName} not found");
            }

            return dataBaseStub.Employees.Where(e =>
                dataBaseStub.CompanyEmployeeAssociation
                                    .Where(t => t.Item1 == company.Id)
                                    .Select(t => t.Item2)
                                    .Contains(e.Id));
        }

        public void AddCompany(Company company)
        {
            Console.WriteLine("AddCompany() <-- ");

            try
            {
                dataBaseStub.Companies.Add(company);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }     
        }

        public void AddEmployee(Employee employee)
        {
            Console.WriteLine("AddEmployee() <-- ");
            try
            {
                dataBaseStub.Employees.Add(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddEmployeeToCompany(Employee employee, Company company)
        {
            Console.WriteLine("AddEmployeeToCompany() <-- ");

            try
            {
                if (dataBaseStub.Employees.Contains(employee) && dataBaseStub.Companies.Contains(company))
                {
                    dataBaseStub.CompanyEmployeeAssociation.Add(new Tuple<long, long>(company.Id, employee.Id));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

        public void KeepAlive()
        {
            Console.WriteLine("KeepAlive() <-- ");
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            Console.WriteLine("Signal() --> ");
            callback.Signal();
            
        }
    }
}