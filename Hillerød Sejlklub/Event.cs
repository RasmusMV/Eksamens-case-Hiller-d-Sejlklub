using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub
{
    public class Event
    {
        private static int _id;

        public Event(string eventName, string eventDescription)
        {
            Name = eventName;
            Id = MakeId();
            Description = eventDescription;
            CreationTime = DateTime.Now;
        }
        
        public string Name { get; set; }

        public int Id { get; }

        public string Description { get; set; }
        public DateTime CreationTime { get; set; }

        public DateTime CreationDate { get; set; }

        private int MakeId()
        {
            int newId = _id;
            _id = _id + 1;
            return newId;
        }

        public override string ToString()
        {
            return $"Event: {Name} \n{Description}";
        }

    }
}
