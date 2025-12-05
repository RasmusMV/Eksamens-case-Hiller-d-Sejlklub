using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Repositories
{
    public class BookingRepository
    {
        #region instance fields
        public static BookingRepository _instance = null;
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
        #endregion
    }
}
