using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub.Interfaces;

namespace Hillerød_Sejlklub.Repositories
{
    public class EventRepository : IEventRepository
    {
        private static EventRepository _instance = null;

        private Dictionary<int, Event> _events;

        private EventRepository()
        {
            _events = new Dictionary<int, Event>();
        }

        public Dictionary<int, Event> EventList { get; }

        public static EventRepository GetInstance()
        {
            if(_instance == null)
            {
                _instance = new EventRepository();
            }
            return _instance;
        }

        public void AddEvent(Event evt)
        {
            _events.Add(evt.Id, evt);
        }

        public void DeleteEvent(Event evt)
        {
            _events.Remove(evt.Id);
        }
    }
}
