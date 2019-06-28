using System.Collections.Generic;
using System.ServiceModel;

namespace Contracts
{
    
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void Signal();
    }

    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface ICRMRepository
    {
        [OperationContract]
        IEnumerable<Company> GetAllCompanies();

        [OperationContract]
        IEnumerable<Employee> GetAllEmployees();

        [OperationContract]
        IEnumerable<Employee> GetEmployeesByCompany(string companyName);
       
        [OperationContract]
        void AddCompany(Company company);
        
        [OperationContract]
        void AddEmployee(Employee employee);

        [OperationContract]
        void AddEmployeeToCompany(Employee employee, Company company);

        [OperationContract(IsOneWay = true)]
        void KeepAlive();
    }
}