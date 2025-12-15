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
        private static BoatRepository _instance = null;

        private Dictionary<string, Boat> _boat;

        private BoatRepository()
        {
            _boat = new Dictionary<string, Boat>();
        }

        public static BoatRepository GetInstanceFromBoat()
        {
            if (_instance == null)
            {
                _instance = new BoatRepository();
            }
            return _instance;
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

        public List<Boat> GetAll()
        {
            return _boat.Values.ToList();
        }
        public List<Boat> GetBoatByName(string name)
        {
            List<Boat> boats = new List<Boat>();

            foreach (var boat in _boat)
            {
                if (boat.Value.Name != null && boat.Value.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase) == true)
                {
                    boats.Add(boat.Value);
                }
            }

            return boats;

        }


    }
}
