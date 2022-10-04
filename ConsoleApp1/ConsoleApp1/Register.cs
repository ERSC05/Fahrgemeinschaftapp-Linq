using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Register
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Address { get; set; }

        public Register(string firstName, string lastName, string address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            Address = address;
        }
            
    }
}
