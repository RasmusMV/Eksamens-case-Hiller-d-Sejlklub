using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub.Interfaces;

namespace Hillerød_Sejlklub
{
    public class Member
    {
        protected string _name;


        public Member(string name, int age, int id, string mail, int phoneNumber)
        {
            _name = name;
            Age = age;
            ID = id;
            Mail = mail;
            PhoneNumber = phoneNumber;

        }
        public string Name { get { return _name; } set { _name = value; } }
        public int Age { get; set; }
        public int ID { get; set; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }
    }


}
