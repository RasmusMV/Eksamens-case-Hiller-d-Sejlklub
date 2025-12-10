using Hillerød_Sejlklub;
using Hillerød_Sejlklub.Exceptions;
using Hillerød_Sejlklub.Repositories;
BookingRepository bookinger = BookingRepository.GetInstance();

//Initialize boats
Boat skipper = new Boat("Skipper", 5341, "Clipper", "Sagitarius", 1534, 300, 1000, 4000);
Boat chopper = new Boat("Chopper", 9524, "Tanker", "Venus", 1971, 3000, 2000, 9000);

//Initialize members
Member mathias = new Member("Mathias", 36, 1, "Mathi@gmail.com", 19875634);
Member henrik = new Member("Henrik", 56, 2, "Henrik@gmail.com", 65874125);
/*
//Initialize the first booking objects
Booking booking1 = new Booking(mathias, skipper, "Hvide sande", 2025, 12, 7, 18, 0, 23, 59);
Booking booking2 = new Booking(henrik, skipper, "Stillinge strand", 2025, 12, 7, 21, 30, 23, 30);
Booking booking3 = new Booking(henrik, chopper, "Bjerge", 2025, 12, 7, 5, 0, 10, 30);
Booking booking4 = new Booking(mathias, chopper, "Hvide sande", 2025, 12, 20, 16, 0, 23, 59);
*/

bookinger.AddBooking(mathias, skipper, "Hvide sande", 2025, 12, 7, 18, 0, 23, 59);

/*
Add the second booking object to the bookingrepository,
however as this object has an overlapping time interval with booking1 a BookingDateTakenException will fire
and the object won't be added to the list
*/

bookinger.AddBooking(henrik, skipper, "Stillinge strand", 2025, 12, 7, 21, 30, 23, 30);
bookinger.AddBooking(henrik, chopper, "Bjerge", 2025, 12, 7, 5, 0, 10, 30);
bookinger.AddBooking(mathias, chopper, "Hvide sande", 2025, 12, 20, 16, 0, 23, 59);

Console.WriteLine($"\nWrite out all bookings currently placed in bookingrepository\n");

foreach (var keyValuePair in bookinger.BookingList)
{
    Console.WriteLine(keyValuePair.Value.ToString());
}

Console.WriteLine($"Activating bookings and looking if any are returning late\n");

bookinger.BookingList[0].ActivateBooking();
bookinger.BookingList[2].ActivateBooking();

foreach (var booking in bookinger.CurrentlySailing())
{
    Console.WriteLine($"{booking.ToString()}\n");
}

Console.WriteLine($"Deactivating the active bookings \n");

bookinger.BookingList[0].DeactivateBooking();
bookinger.BookingList[2].DeactivateBooking();

Console.WriteLine($"Deleting booking3 and writing out the remaining bookings \n");

bookinger.DeleteBooking(bookinger.BookingList[2]);

foreach (var keyValuePair in bookinger.BookingList)
{
    Console.WriteLine(keyValuePair.Value.ToString());
}

Console.WriteLine($"Updating the date of booking1 \n");

bookinger.UpdateBookingDate(bookinger.BookingList[0], 2025, 12, 20, 16, 0, 23, 59);

foreach (var keyValuePair in bookinger.BookingList)
{
    Console.WriteLine(keyValuePair.Value.ToString());
}

Console.WriteLine($"Updating the boat in booking1 is using, however that time slot is already occupied by booking4 \n");

bookinger.UpdateBookingBoat(bookinger.BookingList[0], chopper);

foreach (var keyValuePair in bookinger.BookingList)
{
    Console.WriteLine(keyValuePair.Value.ToString());
}

Console.WriteLine($"Updating the boat in booking1 but this time changing the date to a non-occupied time \n");


bookinger.UpdateBookingDate(bookinger.BookingList[0], 2025, 12, 20, 10, 0, 14, 30);

bookinger.UpdateBookingBoat(bookinger.BookingList[0], chopper);

foreach (var keyValuePair in bookinger.BookingList)
{
    Console.WriteLine(keyValuePair.Value.ToString());
}

Console.WriteLine($"How many times each boat has been booked in BookingRepository \n");

bookinger.BoatBookings();

Console.WriteLine($"How many times each member has made a booking in BookingRepository \n");

bookinger.MemberBookings();
