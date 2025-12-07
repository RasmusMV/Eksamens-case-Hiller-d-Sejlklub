using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Exceptions
{
    public class BookingUpdateException : Exception
    {
        public BookingUpdateException(string message) : base(message) { }
    }
}
