using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Interfaces
{
    public interface IEventRepository
    {
        public Dictionary<int, Event> EventDictionary { get; }

        public void AddEvent(Event evt);

        public void DeleteEvent(Event evt);

        public void UpdateEventName(Event evt, string newName);

        public void UpdateEventDescription(Event evt, string newDescription);

        public List<Event> GetByName(string name);
    }
}
