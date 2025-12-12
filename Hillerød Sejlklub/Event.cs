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
        private List<Member> _attendees = new List<Member>();

        public Event(string eventName, string eventDescription, DateTime dateOf)
        {
            Name = eventName;
            Id = MakeId();
            Description = eventDescription;
            DateOf = dateOf;
            CreationDate = DateTime.Now;
        }
        
        public string Name { get; set; }

        public int Id { get; }

        public string Description { get; set; }

        public DateTime DateOf { get; set; }

        public DateTime CreationDate { get; }

        public List<Member> Attendees
        {
            get { return _attendees; }
        }

        private int MakeId()
        {
            int newId = _id;
            _id = _id + 1;
            return newId;
        }

        public void AddMember(Member member)
        {
            _attendees.Add(member);
        }

        public void RemoveMember(Member member)
        {
            _attendees.Remove(member);
        }

        public override string ToString()
        {
            return $"Event: {Name}, Time of posting {CreationDate}, Date {DateOf}\nDescription: {Description}";
        }

    }
}
