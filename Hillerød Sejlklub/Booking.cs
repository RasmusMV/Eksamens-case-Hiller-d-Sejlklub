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
        #region instance fields
        private static int _id;
        #endregion

        #region constructor
        public Booking(Member member, Boat boat, DateTime dateStart, DateTime dateFinish)
        {
            Id = MakeId();
            Member = member;
            Boat = boat;
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
            _id = _id++;
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
                        throw new BookingDateTakenException("Your chosen time slot is already occupied");
                    }
                }
            }
        }
        #endregion

    }
}
