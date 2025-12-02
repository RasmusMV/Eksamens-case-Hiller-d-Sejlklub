using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub.Interfaces;

namespace Hillerød_Sejlklub
{
    public class Member : IUserRepository
    {
        public string Name { get; set; }
    }
}
