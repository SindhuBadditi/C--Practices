using System;
using System.Collections.Generic;
using System.Text;
namespace Flight_Ticket_Booking
{
    class Flight
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int TotalSeatCapacity { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }

        public Flight(int id, string number, string source, string destination,
                      int capacity, decimal price)
        {
            FlightId = id;
            FlightNumber = number;
            Source = source;
            Destination = destination;
            TotalSeatCapacity = capacity;
            AvailableSeats = capacity;
            TicketPrice = price;
        }

        public void DisplayFlightDetails()
        {
            Console.WriteLine($"Flight ID: {FlightId}");
            Console.WriteLine($"Flight Number: {FlightNumber}");
            Console.WriteLine($"Source: {Source}");
            Console.WriteLine($"Destination: {Destination}");
            Console.WriteLine($"Total Seats: {TotalSeatCapacity}");
            Console.WriteLine($"Available Seats: {AvailableSeats}");
            Console.WriteLine($"Ticket Price: {TicketPrice}");
        }

        public void BookSeats(int seats)
        {
            if (seats <= 0)
            {
                throw new FlightException("Number of seats must be greater than zero.");
            }

            if (seats > AvailableSeats)
            {
                throw new FlightException($"Only {AvailableSeats} seat are available.");
            }
            if (AvailableSeats == 0)
            {
                Console.WriteLine("Sorry No bookings are available");
                return;
            }

            AvailableSeats -= seats;
        }

        public void ReleaseSeats(int seats)
        {
            if (seats <= 0)
            {
                throw new FlightException("Number of seats must be greater than zero.");
            }

            AvailableSeats += seats;
        }
    }
}
