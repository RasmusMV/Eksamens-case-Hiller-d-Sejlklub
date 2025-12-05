using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub
{
    internal class Engine
    {
        public Engine(string type)
        {
            Type = type;
        }


        public string Type { get; set; }
    }
}
