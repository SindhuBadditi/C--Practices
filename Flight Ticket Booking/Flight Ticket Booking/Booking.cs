using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Ticket_Booking
{
    class Booking
    {
        public int BookingId { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal TotalAmount { get; set; }
        public string BookingStatus { get; set; }
        public bool CheckInStatus { get; set; }

        public Booking(int bookingId, int passengerId, int flightId, int seats)
        {
            BookingId = bookingId;
            PassengerId = passengerId;
            FlightId = flightId;
            NumberOfSeats = seats;
            BookingStatus = "Active";
            CheckInStatus = false;
        }

        public void CalculateTotalAmount(decimal ticketPrice)
        {
            TotalAmount = NumberOfSeats * ticketPrice;
        }

        public void CancelBooking()
        {
            if (BookingStatus.Equals("cancelled", StringComparison.OrdinalIgnoreCase))
            {
                throw new BookingException("Booking is already cancelled.");
            }

            if (CheckInStatus)
            {
                throw new BookingException("Checked-in booking cannot be cancelled.");
            }
            BookingStatus = "Cancelled";
        }

        public void CheckIn()
        {
            if (BookingStatus == "Cancelled")
            {
                throw new BookingException("Cancelled booking cannot be checked in.");
            }

            if (CheckInStatus)
            {
                throw new BookingException("Passenger is already checked in.");
            }
            CheckInStatus = true;
        }

        public void DisplayBookingDetails()
        {
            Console.WriteLine($"Booking ID: {BookingId}");
            Console.WriteLine($"Passenger ID: {PassengerId}");
            Console.WriteLine($"Flight ID: {FlightId}");
            Console.WriteLine($"Number of Seats: {NumberOfSeats}");
            Console.WriteLine($"Total Amount: {TotalAmount:C}");
            Console.WriteLine($"Booking Status: {BookingStatus}");
            Console.WriteLine($"Check-in Status: {(CheckInStatus ? "Checked In" : "Not Checked In")}");
        }
    }
}
