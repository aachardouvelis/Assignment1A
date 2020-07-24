using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1A
{
    class Trainer
    {
        public Trainer(string firstname,string lastname,string subject)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.subject = subject;
        }


        private string firstname, lastname;
        private string subject;//enum?

        public string getFirstName() { return firstname; }
        public void setFirstName(string firstname) { this.firstname = firstname; }
        public string getLastName() { return lastname; }
        public void setLastName(string lastname) { this.lastname = lastname; }

        //do i need a getter/stter for subject?
    }
}
