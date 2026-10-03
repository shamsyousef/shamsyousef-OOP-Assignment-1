namespace Part2_HotelReservationSystem.Entities;

public class Room
{
    public int RoomNumber { get; }
    public RoomType RoomType { get; }

    public decimal NightlyRate { get; private set; }

    public bool IsUnderMaintenance { get; private set; }

    private readonly List<Reservation> _reservations = new();

    public IReadOnlyList<Reservation> Reservations => _reservations;

    public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
    {
        if (nightlyRate <= 0)
            throw new ArgumentException("Nightly rate must be positive.");

        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
    }

    public void UpdateNightlyRate(decimal newRate)
    {
        if (newRate <= 0)
            throw new ArgumentException("Nightly rate must be positive.");

        NightlyRate = newRate;
    }

    public void StartMaintenance()
    {
        IsUnderMaintenance = true;
    }

    public void EndMaintenance()
    {
        IsUnderMaintenance = false;
    }

    internal void AddReservation(Reservation reservation)
    {
        bool hasOverlap = _reservations.Any(existing =>
            existing.Status != ReservationStatus.Cancelled &&
            existing.Status != ReservationStatus.CheckedOut &&
            reservation.CheckInDate < existing.CheckOutDate &&
            reservation.CheckOutDate > existing.CheckInDate);

        if (hasOverlap)
            throw new InvalidOperationException(
                "Room already has an active reservation during this period.");

        _reservations.Add(reservation);
    }
}