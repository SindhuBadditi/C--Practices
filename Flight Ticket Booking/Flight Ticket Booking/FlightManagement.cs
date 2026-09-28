using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Ticket_Booking
{
    using System;
    using System.Collections.Generic;

    class FlightManagement
    {
        private List<Flight> flights = new List<Flight>();
        private List<Passenger> passengers = new List<Passenger>();
        private List<Booking> bookings = new List<Booking>();

        private int nextBookingId = 1;

        public void AddFlight(Flight flight)
        {
            if (FindFlight(flight.FlightId) != null)
            {
                throw new FlightException("Flight ID already exists.");
            }

            flights.Add(flight);
        }

        public void ViewFlights()
        {
            if (flights.Count == 0)
            {
                Console.WriteLine("No flights are available.");
                return;
            }

            foreach (Flight flight in flights)
            {
                flight.DisplayFlightDetails();
                Console.WriteLine("----------------------");
            }
        }

        public void RegisterPassenger(Passenger passenger)
        {
            if (FindPassenger(passenger.PassengerId) != null)
            {
                throw new BookingException("Passenger ID already exists.");
            }

            if (passenger.Age <= 0)
            {
                throw new BookingException("Age must be greater than zero.");
            }

            passengers.Add(passenger);
        }

        public void ViewPassengers()
        {
            if (passengers.Count == 0)
            {
                Console.WriteLine("No passengers are registered.");
                return;
            }

            foreach (Passenger passenger in passengers)
            {
                passenger.DisplayPassengerDetails();
                Console.WriteLine("----------------------");
            }
        }

        public void BookTicket(int passengerId, int flightId, int seats)
        {
            Passenger passenger = FindPassenger(passengerId);

            if (passenger == null)
            {
                throw new BookingException("Passenger not found.");
            }

            Flight flight = FindFlight(flightId);

            if (flight == null)
            {
                throw new BookingException("Flight not found.");
            }

            if (seats <= 0)
            {
                throw new BookingException("Number of seats must be greater than zero.");
            }
            foreach (Booking book in bookings)
            {
                if (book.PassengerId == passengerId &&
                    book.FlightId == flightId &&
                    book.BookingStatus == "Active")
                {
                    throw new BookingException("Passenger already has an active booking for this flight.");
                }
            }
            flight.BookSeats(seats);
            Booking booking = new Booking(nextBookingId,passengerId,flightId,seats);
            booking.CalculateTotalAmount(flight.TicketPrice);
            bookings.Add(booking);
            Console.WriteLine($"Ticket booked successfully. Booking ID: {nextBookingId}");
            nextBookingId++;
        }

        public void CancelBooking(int bookingId)
        {
            Booking booking = FindBooking(bookingId);

            if (booking == null)
            {
                throw new BookingException("Booking not found.");
            }
            booking.CancelBooking();

            Flight flight = FindFlight(booking.FlightId);

            flight.ReleaseSeats(booking.NumberOfSeats);

            Console.WriteLine("Booking cancelled successfully.");
        }

        public void CheckIn(int bookingId)
        {
            Booking booking = FindBooking(bookingId);

            if (booking == null)
            {
                throw new BookingException("Booking not found.");
            }

            booking.CheckIn();

            Console.WriteLine("Check-in completed successfully.");
        }

        public void ViewBooking(int bookingId)
        {
            Booking booking = FindBooking(bookingId);

            if (booking == null)
            {
                throw new BookingException("Booking not found.");
            }

            booking.DisplayBookingDetails();

            Passenger passenger = FindPassenger(booking.PassengerId);
            Flight flight = FindFlight(booking.FlightId);

            Console.WriteLine("\nPassenger Details");
            passenger.DisplayPassengerDetails();

            Console.WriteLine("\nFlight Details");
            flight.DisplayFlightDetails();
        }

        private Flight FindFlight(int flightId)
        {
            foreach (Flight flight in flights)
            {
                if (flight.FlightId == flightId)
                {
                    return flight;
                }
            }
            return null;
        }
        private Passenger FindPassenger(int passengerId)
        {
            foreach (Passenger passenger in passengers)
            {
                if (passenger.PassengerId == passengerId)
                {
                    return passenger;
                }
            }
            return null;
        }
        private Booking FindBooking(int bookingId)
        {
            foreach (Booking booking in bookings)
            {
                if (booking.BookingId == bookingId)
                {
                    return booking;
                }
            }
            return null;
        }
    }
}
