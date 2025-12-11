using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub
{
    public abstract class Engine
    {
        public Engine(string motorType, int hp, string brand)
        {
            MotorType = motorType;
            HorsePower = hp;
            Brand = brand;
        }


        public string MotorType { get; set; }
        public int HorsePower { get; set; }
        public string Brand { get; set; }

    }
}
