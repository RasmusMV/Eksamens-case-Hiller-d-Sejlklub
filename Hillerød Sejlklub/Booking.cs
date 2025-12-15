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
        public Booking(Member member, Boat boat, string destination, DateTime start, DateTime finish)
        {
            Id = MakeId();
            Member = member;
            Boat = boat;
            Destination = destination;
            DateStart = start;
            DateFinish = finish;
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
            Active = true;
            /* This is what a potential start of the booking could look like
            if (DateStart <= DateTime.Now && DateFinish >= DateTime.Now)
            {
                Active = true;
            }
            */
        }

        //Deactivates the booking when you are done sailing
        public void DeactivateBooking()
        {
            Active = false;
        }

        //Overwritten tostring method combining the information of the member, boat and the bookings own properties to return all information of the booking
        public override string ToString()
        {
            return $"Member: {Member.ToString()} \nBoat: {Boat.ToString()} \nBooking: ID: {Id}, " +
                $"Destination: {Destination}, Start: {DateStart}, Finish: {DateFinish}\n";
        }
        #endregion

    }
}
