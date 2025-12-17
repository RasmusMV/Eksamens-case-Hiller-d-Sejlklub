using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Interfaces
{
    public interface IBoatRepository
    {
        public void AddBoat(Boat boat);
        public void RemoveBoat(string sailNumber);
        public void UpdateBoatName(Boat boat, string newName);
        public Boat GetBoatByName(string boat);
        public List<Boat> SearchBoatByName(string name);
        public List<Boat> GetAll();
    }
}
