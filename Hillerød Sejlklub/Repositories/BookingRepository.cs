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
                if (DateValidation(booking) == true)
                {
                    _bookings.Add(booking.Id, booking);
                }
            }
            catch(BookingDateTakenException b)
            {
                Console.WriteLine(b);
            }

        }

        public void DeleteBooking(Booking booking)
        {
            _bookings.Remove(booking.Id);
        }

        public void UpdateBookingDate(Booking booking, int startYear, int startMonth, int startDay, int startHour, int startMinute, int finishHour, int finishMinute)
        {
            DateTime newStartDate = new DateTime(startYear, startMonth, startDay, startHour, startMinute, 0);
            DateTime newFinishDate = new DateTime(startYear, startMonth, startDay, finishHour, finishMinute, 0);
            if(newStartDate < newFinishDate)
            {
                _bookings[booking.Id].DateStart = newStartDate;
                _bookings[booking.Id].DateFinish = newFinishDate;
            }
            else
            {
                throw new BookingUpdateException($"Your new start date is later than you finish. Did you mean to change when you finish?");
            }
        }

        //Method returning a list of all the currently active bookings 
        public List<Booking> CurrentlySailing()
        {
            List<Booking> currentSailors = new List<Booking>();

            foreach (var booking in _bookings)
            {
                if(booking.Value.Active == true && booking.Value.DateFinish >= DateTime.Now)
                {
                    currentSailors.Add(booking.Value);
                }
                else if(booking.Value.Active == true && booking.Value.DateFinish <= DateTime.Now)
                {
                    Console.WriteLine($"{booking.Value.ToString()}is currently missing send a search party\n");
                }
            }

            return currentSailors;

        }


        //Private helper method to check whether any current bookings in the bookingrepository has the same boat and overlapping booking time
        private bool DateValidation(Booking newBooking)
        {
            foreach (var booking in _bookings.Values)
            {
                if (booking.Boat == newBooking.Boat && newBooking.DateStart < booking.DateFinish && booking.DateStart < newBooking.DateFinish)
                {
                    throw new BookingDateTakenException($"Booking ID: {newBooking.Id}, has a scheduling conflict with Booking ID: {booking.Id}");
                }
            }
            return true;
        }
        #endregion
    }
}
