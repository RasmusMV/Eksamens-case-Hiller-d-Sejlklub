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
            _boat = new Dictionary<string, Boat>()
            {
                {"1105", new Boat("Plopper", "1105", "Clipper", "Sagitarius", 1534, 300, 1000, 4000, "None", 0, "None") }
            };
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

        public Boat GetBoatByName(string name)
        {
            foreach (var boat in _boat)
            {
                if(name == boat.Value.Name)
                {
                    return boat.Value;
                }
            }
            return null;
        }

        public List<Boat> SearchBoatByName(string name)
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
