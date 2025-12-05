using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub.Repositories;
using Hillerød_Sejlklub.Exceptions;

namespace Hillerød_Sejlklub
{
    public class Booking
    {
        #region static fields
        private static int _id;
        #endregion

        #region constructor
        public Booking(Member member, Boat boat, int startYear, int startMonth, int startDay, int startHour, int startMinute, int endHour, int endMinute)
        {
            Id = MakeId();
            Member = member;
            Boat = boat;
            //we expect the boat to be returned before the end of everyday so the start year, month and day can be re-used for when they're finished
            DateTime dateStart = new DateTime(startYear, startMonth, startDay, startHour, startMinute, 0);
            DateTime dateFinish = new DateTime(startYear, startMonth, startDay, endHour, endMinute, 0);
            try
            {
                DateValidation(dateStart, dateFinish);
            }
            catch(BookingDateTakenException b)
            {
                Console.WriteLine(b);
            }
            DateStart = dateStart;
            DateFinish = dateFinish;
        }
        #endregion

        #region properties
        public Member Member { get; }

        public Boat Boat { get; set; }

        public int Id { get; }

        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }
        #endregion

        #region methods
        private int MakeId()
        {
            int newId = _id;
            _id = _id + 1;
            return newId;
        }

        private void DateValidation(DateTime dateStart, DateTime dateFinish)
        {
            if(dateStart >= DateTime.Now && dateFinish > dateStart)
            {
                foreach (var booking in BookingRepository.GetInstance().BookingList)
                {
                    if (Boat == booking.Value.Boat && dateStart < booking.Value.DateFinish && booking.Value.DateStart < dateFinish)
                    {
                        throw new BookingDateTakenException($"Booking ID: {Id}, has a scheduling conflict with Booking ID: {booking.Value.Id}");
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Member: {Member.ToString()} \nBoat: {Boat.ToString()} \nBooking: ID: {Id}, Start: {DateStart}, Finish: {DateFinish}";
        }
        #endregion

    }
}
