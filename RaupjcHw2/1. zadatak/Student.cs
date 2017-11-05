    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.zadatak
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        protected bool Equals(Student other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Jmbag, other.Jmbag) && Gender == other.Gender;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name.GetHashCode();
                hashCode = (hashCode * 397) ^ Jmbag.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) Gender;
                return hashCode;
            }
        }

        public static bool operator ==(Student a, Student b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Student a, Student b)
        {
            return !a.Equals(b);
        }
    }

    
}
