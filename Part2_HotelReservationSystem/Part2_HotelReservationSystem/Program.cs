using Part2_HotelReservationSystem.Entities;

var guest = new Guest(
    1,
    "Shams Ashraf",
    "01012345678"
);

var room = new Room(
    101,
    RoomType.Double,
    2000m
);


var reservation = guest.MakeReservation(
    1,
    room,
    new DateTime(2026, 10, 10),
    new DateTime(2026, 10, 13)
);



Console.WriteLine($"Guest: {guest.FullName}");
Console.WriteLine($"Room: {reservation.Room.RoomNumber}");
Console.WriteLine($"Status: {reservation.Status}");
Console.WriteLine($"Total Cost: {reservation.TotalCost}");

reservation.Confirm();

Console.WriteLine($"After Confirm: {reservation.Status}");

reservation.CheckIn();

Console.WriteLine($"After Check-In: {reservation.Status}");

reservation.CheckOut();

Console.WriteLine($"After Check-Out: {reservation.Status}");
