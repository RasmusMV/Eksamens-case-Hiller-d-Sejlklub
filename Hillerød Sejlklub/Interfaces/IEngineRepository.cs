using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Interfaces
{
    public interface IEngineRepository
    {

        public void AddEngine(Engine engine);
        public void RemoveEngine(Engine engine);


    }
}
