using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1A
{
    public class Trainer:Identity
    {
        private static int ID_counter;
        public Trainer(string firstname,string lastname,string subject)
        {
            this.ID = ID_counter++;
            this.firstname = firstname;
            this.lastname = lastname;
            this.subject = subject;
        }


        private string firstname, lastname;
        private string subject;//enum?
        public int ID {  get; private set; }

        public string getFirstName() { return firstname; }
        public void setFirstName(string firstname) { this.firstname = firstname; }
        public string getLastName() { return lastname; }
        public void setLastName(string lastname) { this.lastname = lastname; }
        public override string ToString()
        {
            return String.Format("ID:{0} Name:{1} {2}", ID, firstname, lastname);
        }

        //do i need a getter/stter for subject?
    }
}
