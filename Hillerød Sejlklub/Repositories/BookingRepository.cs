using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub.Exceptions;
using Hillerød_Sejlklub.Interfaces;

namespace Hillerød_Sejlklub.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        #region static fields
        private static BookingRepository _instance = null;
        #endregion

        #region instance fields
        private Dictionary<int, Booking> _bookings;
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
            catch(BookingDateException b)
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

            DateTime oldStartDate = booking.DateStart;
            DateTime oldFinishDate = booking.DateFinish;

            try
            {
                booking.DateStart = newStartDate;
                booking.DateFinish = newFinishDate;
                DateValidation(booking);
            }

            catch (BookingDateTakenException b)
            {
                booking.DateStart = oldStartDate;
                booking.DateFinish = oldFinishDate;
                Console.WriteLine(b);
            }
            catch (BookingDateException b)
            {
                booking.DateStart = oldStartDate;
                booking.DateFinish = oldFinishDate;
                Console.WriteLine(b);
            }
        }

        public void UpdateBookingBoat(Booking booking, Boat newBoat)
        {
            Boat oldBoat = booking.Boat;
            try
            {
                booking.Boat = newBoat;
                DateValidation(booking);
            }

            catch (BookingDateTakenException b)
            {
                booking.Boat = oldBoat;
                Console.WriteLine(b);
            }
            catch (BookingDateException b)
            {
                booking.Boat = oldBoat;
                Console.WriteLine(b);
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

        public void BoatBookings()
        {
            Dictionary<Boat, int> boats = new Dictionary<Boat, int>();
            foreach (var booking in _bookings)
            {
                if(boats.ContainsKey(booking.Value.Boat) == false)
                {
                    boats.Add(booking.Value.Boat, 1);
                }
                else
                {
                    boats[booking.Value.Boat] = boats[booking.Value.Boat] + 1;
                }
            }
            foreach (var boat in boats)
            {
                Console.WriteLine($"Boat: {boat.Key.Name} has been booked {boat.Value} times \n");
            }

        }

        public void MemberBookings()
        {
            Dictionary<Member, int> members = new Dictionary<Member, int>();
            foreach (var booking in _bookings)
            {
                if (members.ContainsKey(booking.Value.Member) == false)
                {
                    members.Add(booking.Value.Member, 1);
                }
                else
                {
                    members[booking.Value.Member] = members[booking.Value.Member] + 1;
                }
            }
            foreach (var member in members)
            {
                Console.WriteLine($"Member: {member.Key.Name} has made {member.Value} bookings \n");
            }

        }


        //Private helper method to check whether any current bookings in the bookingrepository has the same boat and overlapping booking time
        private bool DateValidation(Booking newBooking)
        {
            foreach (var booking in _bookings.Values)
            {
                if (booking.Boat == newBooking.Boat && newBooking.DateStart < booking.DateFinish && booking.DateStart < newBooking.DateFinish && newBooking.Id != booking.Id)
                {
                    throw new BookingDateTakenException($"Booking ID: {newBooking.Id}, has a scheduling conflict with Booking ID: {booking.Id}");
                }
                else if (newBooking.DateStart > newBooking.DateFinish)
                {
                    throw new BookingDateException($"Your start date is later than you finish. Did you mean to change when you finish?");
                }
            }
            return true;
        }
        #endregion
    }
}
