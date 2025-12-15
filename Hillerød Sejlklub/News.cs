using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hillerød_Sejlklub
{
    public class News
    {

        private static int _id;

        public News(string newsName, string newsDescription)
        {
            Name = newsName;
            Id = MakeId();
            Description = newsDescription;
            CreationDate = DateTime.Now;
        }
       
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; }
        public DateTime CreationDate { get; }

        private int MakeId()
        {
            int newId = _id;
            _id = _id + 1;
            return newId;
        }

        public override string ToString()
        {
            return $"Event: {Name}, Time of posting {CreationDate} \nDescription: {Description}";
        }
    }
}
