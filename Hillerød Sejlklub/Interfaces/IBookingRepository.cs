using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub.Repositories;

namespace Hillerød_Sejlklub.Interfaces
{
    public interface IBookingRepository
    {
        public Dictionary<int, Booking> BookingList { get; }

        public void AddBooking(Member member, Boat boat, string destination, DateTime start, DateTime finish);

        public void DeleteBooking(Booking booking);

        public void UpdateBookingDate(Booking booking, DateTime start, DateTime finish);

        public void UpdateBookingBoat(Booking booking, Boat newBoat);

        public List<Booking> CurrentlySailing();

        public Dictionary<Boat, int> BoatBookings();

        public Dictionary<Member, int> MemberBookings();

    }
}
