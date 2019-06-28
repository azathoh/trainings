using System;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public long Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Employee other)
            {
                return Equals(other);
            }
            throw new Exception("Wrong data type");
            
        }

        protected bool Equals(Employee other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Surname, other.Surname) && Id == other.Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Surname != null ? Surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                return hashCode;
            }
        }
    }
}