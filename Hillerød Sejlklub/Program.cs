using Hillerød_Sejlklub;
using Hillerød_Sejlklub.Repositories;
BookingRepository bookinger = BookingRepository.GetInstance();

Boat skipper = new Boat("Skipper", 5341, "Clipper", "Sagitarius", 1534, 300, 1000, 4000);
Boat chopper = new Boat("Chopper", 9524, "Tanker", "Venus", 1971, 3000, 2000, 9000);

Member mathias = new Member("Mathias", 36, 12, "Mathi@gmail.com", 19875634);
Member henrik = new Member("Henrik", 56, 2, "Henrik@gmail.com", 65874125);

//Initialize the first booking object
Booking booking1 = new Booking(mathias, skipper, "Hvide sande", 2025, 12, 5, 18, 30, 22, 30);

bookinger.AddBooking(booking1);


Booking booking2 = new Booking(henrik, skipper, "Stillinge strand", 2025, 12, 5, 21, 30, 23, 30);
/*
Add the second booking object to the bookingrepository,
however as this object has an overlapping time interval with booking1 a BookingDateTakenException will fire
*/
bookinger.AddBooking(booking2);

foreach (var keyValuePair in bookinger.BookingList)
{
    Console.WriteLine(keyValuePair.Value.ToString());
}

