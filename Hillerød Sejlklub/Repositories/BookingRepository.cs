using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub.Exceptions;

namespace Hillerød_Sejlklub.Repositories
{
    public class BookingRepository
    {
        #region static fields
        private static BookingRepository _instance = null;
        #endregion

        #region instance fields
        Dictionary<int, Booking> _bookings;
        #endregion

        #region constructor
        private BookingRepository()
        {
            _bookings = new Dictionary<int, Booking>();
        }
        #endregion

        #region properties
        public Dictionary<int, Booking> BookingList
        {
            get { return _bookings; }
        }
        #endregion

        #region methods
        public static BookingRepository GetInstance()
        {
            if(_instance == null)
            {
                _instance = new BookingRepository();
            }
            return _instance;
        }

        public void AddBooking(Booking booking)
        {
            try
            {
                DateValidation(booking);
            }
            catch(BookingDateTakenException b)
            {
                Console.WriteLine(b);
            }

            _bookings.Add(booking.Id, booking);
        }

        public void DeleteBooking(Booking booking)
        {
            _bookings.Remove(booking.Id);
        }

        public void UpdateBookingStartDate(Booking booking, DateTime newStartDate)
        {
            _bookings[booking.Id].DateStart = newStartDate;
        }

        public void UpdateBookingFinishDate(Booking booking, DateTime newFinishDate)
        {
            _bookings[booking.Id].DateFinish = newFinishDate;
        }

        //Private helper method to check whether any current bookings in the bookingrepository has the same boat and overlapping booking time
        private void DateValidation(Booking newBooking)
        {
            foreach (var booking in _bookings.Values)
            {
                if (booking.Boat == newBooking.Boat && newBooking.DateStart < booking.DateFinish && booking.DateStart < newBooking.DateFinish)
                {
                    throw new BookingDateTakenException($"Booking ID: {newBooking.Id}, has a scheduling conflict with Booking ID: {booking.Id}");
                }
            }
        }
        #endregion
    }
}
