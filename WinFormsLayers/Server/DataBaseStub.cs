using System;
using System.Collections.Generic;
using Contracts;

namespace Server
{
    public class DataBaseStub
    {

        private readonly object lck1 = new object();
        private readonly object lck2 = new object();
        private readonly object lck3 = new object();
        private readonly List<Employee> _employees;
        private readonly List<Company> _companies;
        private readonly List<Tuple<long, long>> _companyEmployeeAssocation;

        public List<Employee> Employees
        {
            get
            {
                lock (lck1)
                {
                    return _employees;
                }
            }
        }

        public List<Company> Companies
        {
            get
            {
                lock (lck2)
                {
                    return _companies;
                }
            }
        }

        public List<Tuple<long, long>> CompanyEmployeeAssociation
        {
            get
            {
                lock (lck3)
                {
                    return _companyEmployeeAssocation;
                }
            }
        }


        public DataBaseStub()
        {
            _employees = new List<Employee>
            {
                new Employee {Id = 1, Name = "Andrzej", Surname = "Nowak"},
                new Employee {Id = 2, Name = "Stefan", Surname = "Machel"},
                new Employee {Id = 3, Name = "Roman", Surname = "Kostrzewski"}
            };
            _companies = new List<Company>
            {
                new Company {Name = "TSA", Id = 1},
                new Company {Name = "KAT", Id = 2}
            };
            _companyEmployeeAssocation = new List<Tuple<long, long>>
            {
                new Tuple<long, long>(1, 1),
                new Tuple<long, long>(1, 2),
                new Tuple<long, long>(1,3),
                new Tuple<long, long>(2, 3)
            };

        }
    }
}