namespace Part2_HotelReservationSystem.Entities;

public class Reservation
{
    public int ReservationId { get; }

    public DateTime CheckInDate { get; }

    public DateTime CheckOutDate { get; }

    public Room Room { get; }

    public ReservationStatus Status { get; private set; }

    public decimal TotalCost
    {
        get
        {
            int numberOfNights =
                (CheckOutDate - CheckInDate).Days;

            return numberOfNights * Room.NightlyRate;
        }
    }

    internal Reservation( int reservationId,Room room,DateTime checkInDate, DateTime checkOutDate)
    {
        if (room == null)
            throw new ArgumentNullException(nameof(room));

        if (checkOutDate <= checkInDate)
            throw new ArgumentException(
                "Check-out date must be after check-in date.");

        if (room.IsUnderMaintenance)
            throw new InvalidOperationException(
                "Cannot reserve a room that is under maintenance.");

        ReservationId = reservationId;
        Room = room;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;

        Status = ReservationStatus.Pending;
    }

    public void Confirm()
    {
        if (Status != ReservationStatus.Pending)
            throw new InvalidOperationException(
                "Only pending reservations can be confirmed.");

        Status = ReservationStatus.Confirmed;
    }

    public void CheckIn()
    {
        if (Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException(
                "Reservation must be confirmed before check-in.");

        Status = ReservationStatus.CheckedIn;
    }

    public void CheckOut()
    {
        if (Status != ReservationStatus.CheckedIn)
            throw new InvalidOperationException(
                "Only checked-in reservations can be checked out.");

        Status = ReservationStatus.CheckedOut;
    }

    public void Cancel()
    {
        if (Status != ReservationStatus.Pending &&
            Status != ReservationStatus.Confirmed)
        {
            throw new InvalidOperationException(
                "Only pending or confirmed reservations can be cancelled.");
        }

        Status = ReservationStatus.Cancelled;
    }
}