using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub.Repositories;

namespace Hillerød_Sejlklub.Interfaces
{
    public class IBookingRepository
    {
        private static BookingRepository _instance;

        Dictionary<int, Booking> _bookings;

        public Dictionary<int, Booking> BookingList;

        public static BookingRepository GetInstance() { return _instance; }

        public void AddBooking(Booking booking) { }

        public void DeleteBooking(Booking booking) { _bookings.Remove(booking.Id); }

        public void UpdateBookingDate(Booking booking, int startYear, int startMonth, int startDay, int startHour, int startMinute, int finishHour, int finishMinute) { }

        public void UpdateBookingBoat(Booking booking, Boat newBoat) { }

        public List<Booking> CurrentlySailing() { return new List<Booking>(); }

        private bool DateValidation(Booking newBooking) { return true; }
    }
}
