using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [DataContract]
    public class Company
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public IEnumerable<Employee> Employees { get; set; }

        protected bool Equals(Company other)
        {
            return string.Equals(Name, other.Name) && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is Company company)
            {
                return Equals(company);
            }
            else
            {
                throw new Exception("Cannot compare to object other than company");
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                return hashCode;
            }
        }
    }
}
