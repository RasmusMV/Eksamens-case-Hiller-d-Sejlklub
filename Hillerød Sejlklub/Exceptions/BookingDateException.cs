using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Exceptions
{
    public class BookingDateException : Exception
    {
        public BookingDateException(string message) : base(message) { }
    }
}
