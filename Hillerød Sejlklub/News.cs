using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private int MakeId()
        {
            int newId = _id;
            _id = _id + 1;
            return newId;
        }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
