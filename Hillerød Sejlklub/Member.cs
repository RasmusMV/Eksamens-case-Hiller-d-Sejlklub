using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub.Interfaces;

namespace Hillerød_Sejlklub
{
    public class Member : IUserRepository
    {

        public Member(string name, int age, int id, string mail, int phoneNumber)
        {
            Name = name;
            Age = age;
            ID = id;
            Mail = mail;
            PhoneNumber = phoneNumber;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, age: {Age}, ID: {ID}, Mail: {Mail}, Phonenumber: {PhoneNumber}";
        }

    }
}
