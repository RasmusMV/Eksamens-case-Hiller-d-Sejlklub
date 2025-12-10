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
        public void WriteMaintenanceLog(Boat boat);
        public Boat GetBoatBy(Boat boat, string key);
    }
}
