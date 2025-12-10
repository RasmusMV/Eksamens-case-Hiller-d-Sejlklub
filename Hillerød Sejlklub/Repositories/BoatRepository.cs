using Hillerød_Sejlklub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Hillerød_Sejlklub.Repositories
{
    public class BoatRepository : IBoatRepository
    {

        private Dictionary<string, Boat> _boat;

        private BoatRepository()
        {
            _boat = new Dictionary<string, Boat>();
        }

        public void AddBoat(Boat boat)
        {
            _boat.Add(boat.SailNumber, boat);
        }

        public void RemoveBoat(string sailNumber)
        {
            _boat.Remove(sailNumber);
        }

        public void UpdateBoatName(Boat boat, string newName)
        {
            boat.Name = newName;
        }

        public void WriteMaintenanceLog(Boat boat)
        {
            throw new NotImplementedException();
        }

        public Boat GetBoatBy(Boat boat, string key)
        {
            return _boat[key];
        }

    }
}
