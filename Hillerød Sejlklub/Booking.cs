using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub.Repositories;
using Hillerød_Sejlklub.Exceptions;
using System.Reflection.Metadata.Ecma335;

namespace Hillerød_Sejlklub
{
    public class Booking
    {
        #region static fields
        private static int _id;
        #endregion

        #region constructor
        public Booking(Member member, Boat boat, string destination ,int startYear, int startMonth, int startDay, int startHour, int startMinute, int endHour, int endMinute)
        {
            Id = MakeId();
            Member = member;
            Boat = boat;
            Destination = destination;
            //we expect the boat to be returned before the end of everyday so the start year, month and day can be re-used for when they're finished
            DateStart = new DateTime(startYear, startMonth, startDay, startHour, startMinute, 0);
            DateFinish = new DateTime(startYear, startMonth, startDay, endHour, endMinute, 0);
        }
        #endregion

        #region properties
        public Member Member { get; }

        public Boat Boat { get; set; }

        public string Destination { get; set; }

        public int Id { get; }

        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }

        public bool Active { get; private set; }
        #endregion

        #region methods
        //Private helper method to automatically assign a id to new bookings
        private int MakeId()
        {
            int newId = _id;
            _id = _id + 1;
            return newId;
        }

        //Activates the booking, making the CurrentlySailing method in BookingRepository show that you are currently using the boat
        public void ActivateBooking()
        {
            if (DateStart <= DateTime.Now && DateFinish >= DateTime.Now)
            {
                Active = true;
            }
        }

        //Deactivates the booking when you are done sailing
        public void FinishedBooking()
        {
            Active = false;
        }

        //Overwritten tostring method combining the information of the member, boat and the bookings own properties to return all information of the booking
        public override string ToString()
        {
            return $"Member: {Member.ToString()} \nBoat: {Boat.ToString()} \nBooking: ID: {Id}, Destination: {Destination}, Start: {DateStart}, Finish: {DateFinish}";
        }
        #endregion

    }
}
