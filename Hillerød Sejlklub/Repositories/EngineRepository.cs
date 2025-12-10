using Hillerød_Sejlklub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Repositories
{
    internal class EngineRepository : IEngineRepository
    {
        private Dictionary<string, Engine> _engine;

        public EngineRepository()
        {
            _engine = new Dictionary<string, Engine>
            {
                { "Diesel", new Engine("Diesel") },
                { "Electic", new Engine("Electric") }


            };
        }

        public void AddEngine(Engine engine)
        {
            _engine.Add(engine.Type,  engine);
        }

        public void RemoveEngine(Engine engine)
        {
            _engine.Remove(engine.Type);
        }
    }
}
