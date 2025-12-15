using Hillerød_Sejlklub;
using Hillerød_Sejlklub.Exceptions;
using Hillerød_Sejlklub.Repositories;
using System.Xml.Linq;
BookingRepository bookinger = BookingRepository.GetInstance();
UserRepository members = UserRepository.GetInstance();

//Initialize boats
Boat skipper = new Boat("Skipper", "5341", "Clipper", "Sagitarius", 1534, 300, 1000, 4000, "None", 0, "None");
Boat chopper = new Boat("Chopper", "9524", "Tanker", "Venus", 1971, 3000, 2000, 9000, "Inboard", 50, "Yamaha");
  
//Initialize members
Member mathias = new Member("Mathias", new DateTime(1995,10,3),  "Mathi@gmail.com", 19875634);
Member henrik = new Member("Henrik", new DateTime(1940,11,24),  "Henrik@gmail.com", 65874125);
/*
//Initialize the first booking objects
Booking booking1 = new Booking(mathias, skipper, "Hvide sande", 2025, 12, 7, 18, 0, 23, 59);
Booking booking2 = new Booking(henrik, skipper, "Stillinge strand", 2025, 12, 7, 21, 30, 23, 30);
Booking booking3 = new Booking(henrik, chopper, "Bjerge", 2025, 12, 7, 5, 0, 10, 30);
Booking booking4 = new Booking(mathias, chopper, "Hvide sande", 2025, 12, 20, 16, 0, 23, 59);
*/

bookinger.AddBooking(mathias, skipper, "Hvide sande", new DateTime(2025, 12, 7, 18, 0, 0), new DateTime(2025, 12, 7, 23, 59, 0));

/*
Add the second booking object to the bookingrepository,
however as this object has an overlapping time interval with booking1 a BookingDateTakenException will fire
and the object won't be added to the list
*/

bookinger.AddBooking(henrik, skipper, "Stillinge strand", new DateTime(2025, 12, 7, 21, 30, 0), new DateTime(2025, 12, 7, 23, 30, 0));
bookinger.AddBooking(henrik, chopper, "Bjerge", new DateTime(2025, 12, 7, 5, 0, 0), new DateTime(2025, 12, 7, 10, 30, 0));
bookinger.AddBooking(mathias, chopper, "Hvide sande", new DateTime(2025, 12, 20, 16, 0, 0), new DateTime(2025, 12, 20, 23, 59, 0));

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

bookinger.UpdateBookingDate(bookinger.BookingList[0], new DateTime(2025, 12, 20, 16, 0, 0), new DateTime(2025, 12, 20, 23, 59, 0));

foreach (var keyValuePair in bookinger.BookingList)
{
    Console.WriteLine(keyValuePair.Value.ToString());
}

Console.WriteLine($"Updating the boat a booking is using, however that time slot is already occupied by another booking with that boat \n");

bookinger.UpdateBookingBoat(bookinger.BookingList[0], chopper);

foreach (var keyValuePair in bookinger.BookingList)
{
    Console.WriteLine(keyValuePair.Value.ToString());
}

Console.WriteLine($"Updating the boat in the same booking again, but this time changing the date to a non-occupied time \n");


bookinger.UpdateBookingDate(bookinger.BookingList[0], new DateTime(2025, 12, 20, 10, 0, 0), new DateTime(2025, 12, 20, 14, 30, 0));

bookinger.UpdateBookingBoat(bookinger.BookingList[0], chopper);

foreach (var keyValuePair in bookinger.BookingList)
{
    Console.WriteLine(keyValuePair.Value.ToString());
}

Console.WriteLine($"How many times each boat has been booked in BookingRepository \n");

foreach (var boat in bookinger.BoatBookings())
{
    Console.WriteLine($"Boat: {boat.Key.Name} has been booked {boat.Value} times \n");
}

Console.WriteLine($"How many times each member has made a booking in BookingRepository \n");

foreach (var member in bookinger.MemberBookings())
{
    Console.WriteLine($"Member: {member.Key.Name} has made {member.Value} bookings \n");
}

//member


UserRepository memberRepository = UserRepository.GetInstance();

List<Member> membersList = memberRepository.GetAll();

//Tilføj nyt medlem

membersList.Add(new Member("Hans", new DateTime(1955,6,29), "Hans@gmail.com", 22222222));

//Vis antal medlemmer
Console.WriteLine("Total members:" + membersList.Count() + "\n\n");


//Liste over alle medlemmer
foreach (Member member in membersList)
{
Console.WriteLine($"Name: {member.Name}\nAge:{member.Age}\nID:{member.ID}\nmail:{member.Mail}\nPhone:{member.PhoneNumber}\n\n");
}



//delete member
try
{
    bool del = memberRepository.Delete("Buller");
    if (del == true)
    {
        Console.WriteLine("Buller has been deleted");
    }
}

catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//Get by name
Member member1 = memberRepository.GetByName("Hans");
if (member1 != null)
{
    Console.WriteLine($"{member1.ToString}");
}
else
{
    Console.WriteLine("Member could not be found");
}



Console.WriteLine($"\nEvent testing\n");

EventRepository events = EventRepository.GetInstance();

events.AddEvent(new Event("Sommer standerhejsning", "Vi hejser stander flaget for at insinuere starten på en ny sæson", new DateTime(2026, 6, 6, 12, 0, 0)));
events.AddEvent(new Event("Sommer arbejdsdag", "Vi samles i klubben for at gøre bådene klar for sæsonen", new DateTime(2026, 6, 1, 8, 0, 0)));
events.AddEvent(new Event("Sommerfrokost", "Vi samles for at nyde afslutningen af sommer sæsonen", new DateTime(2026, 9, 30, 11, 30, 0)));
events.AddEvent(new Event("Efterårsfrokost", "Vi samles for at nyde afslutningen af efterårs sæsonen", new DateTime(2026, 11, 30, 11, 29, 0)));
events.AddEvent(new Event("Efteråts arbejdsdag", "Vi samles i klubben for at gøre rent, og samle affald inden vinter", new DateTime(2026, 6, 1, 8, 0, 0)));

Console.WriteLine("Write out all events\n");

foreach (var evt in events.EventList)
{
    Console.WriteLine(evt.ToString());
}

Console.WriteLine($"\nNow write out all who has sommer in their name\n");

foreach (var evt in events.GetByName("sommer"))
{
    Console.WriteLine(evt.ToString());
}








BoatRepository boatRepository = new BoatRepository();

List<Boat> boats = boatRepository.GetAll();

//Tilføj ny boat

boats.Add(new Boat("Fenja", "ABC123", "SailBoat", "Civilian", 2005, 15, 30, 25, "None", 0, "None"));



//Vis antal af boats
Console.WriteLine("Total Boats:" + boats.Count() + "\n\n");


//Liste over alle boats
foreach (Boat boat in boats)
{
    Console.WriteLine(boat.ToString());
}


//delete Boat

boatRepository.RemoveBoat("ABC123");

//Get by name
foreach(Boat boat in boatRepository.GetBoatByName("Fenja"))
{
    Console.WriteLine(boat);
}

