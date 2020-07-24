using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1A
{
    class Student
    {
        private string firstname, lastname;
        private DateTime dateOfBirth;
        private double tuitionFees;

        public Student(string firstname,string lastname,DateTime dateOfBirth,double tuition_fees)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.dateOfBirth = dateOfBirth;
            this.tuitionFees = tuition_fees;
        }

        public string getFirstName() { return firstname; }
        public void setFirstName(string firstname) { this.firstname = firstname; }
        public string getLastName() { return lastname; }
        public void setLastName(string lastname) { this.lastname = lastname; }
        public DateTime getDateOfBirth() { return dateOfBirth; }
        public void setDateOfBirth(DateTime dateOfBirth) { this.dateOfBirth = dateOfBirth; }
    }
}
