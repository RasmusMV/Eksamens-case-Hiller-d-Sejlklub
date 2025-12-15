using Hillerød_Sejlklub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub
{
    
  
    public class Member
    {
        #region Static field  
      private static int _id;
        #endregion

        #region Constructor
        public Member(string name, DateTime dateOfBirth, string mail, int phoneNumber)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            ID = MakeId();
            Mail = mail;
            PhoneNumber = phoneNumber;
           

        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public DateTime DateOfBirth { get; }
        public int ID { get; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }
        #endregion

        #region Methods
        private int MakeId()
        {
            int newId = _id;
            _id = _id + 1;
            return newId;
        }

        public int AgeYears
        {
            get
            {
                DateTime today = DateTime.Today;
                int years = today.Year - DateOfBirth.Year;

                if (today < DateOfBirth.AddYears(years))
                {
                    years--;
                }

                return years;
            }
        }


        public int AgeMonths
        {
            get
            {
                DateTime today = DateTime.Today;

                int months = (today.Year - DateOfBirth.Year) * 12
                             + today.Month - DateOfBirth.Month;

                if (today.Day < DateOfBirth.Day)
                {
                    months--;
                }

                return months % 12;
            }
        }
        public string Age
        {
            get
            {
                return $"{AgeYears} years, {AgeMonths} months";
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, age: {Age}, ID: {ID}, Mail: {Mail}, Phonenumber: {PhoneNumber}";
        }
        #endregion

    }


}
