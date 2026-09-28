using Flight_Ticket_Booking;

class FlightTicket
{
    static void Main()
    {
        FlightManagement management = new FlightManagement();
        while (true)
        {
            Console.WriteLine("\n===== Flight Ticket Booking System =====");
            Console.WriteLine("1. Add Flight");
            Console.WriteLine("2. View Flights");
            Console.WriteLine("3. Register Passenger");
            Console.WriteLine("4. View Passengers");
            Console.WriteLine("5. Book Ticket");
            Console.WriteLine("6. Cancel Booking");
            Console.WriteLine("7. Check In");
            Console.WriteLine("8. View Booking");
            Console.WriteLine("9. Exit");
            try
            {
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Flight ID: ");
                        int flightId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Flight Number: ");
                        string flightNumber = Console.ReadLine();

                        Console.Write("Enter Source: ");
                        string source = Console.ReadLine();

                        Console.Write("Enter Destination: ");
                        string destination = Console.ReadLine();

                        Console.Write("Enter Seat Capacity: ");
                        int capacity = int.Parse(Console.ReadLine());

                        Console.Write("Enter Ticket Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        Flight flight = new Flight(flightId,flightNumber,source,destination,capacity,price);

                        management.AddFlight(flight);
                        Console.WriteLine("Flight added successfully.");
                        break;

                    case 2:
                        management.ViewFlights();
                        break;

                    case 3:
                        Console.Write("Enter Passenger ID: ");
                        int passengerId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Passenger Name: ");
                        string passengerName = Console.ReadLine();

                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.Write("Enter Passport Number: ");
                        string passport = Console.ReadLine();

                        Passenger passenger = new Passenger(passengerId,passengerName,age,passport);

                        management.RegisterPassenger(passenger);
                        Console.WriteLine("Passenger registered successfully.");
                        break;

                    case 4:
                        management.ViewPassengers();
                        break;

                    case 5:
                        Console.Write("Enter Passenger ID: ");
                        int bookingPassengerId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Flight ID: ");
                        int bookingFlightId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Number of Seats: ");
                        int seats = int.Parse(Console.ReadLine());

                        management.BookTicket(bookingPassengerId,bookingFlightId,seats);
                        break;

                    case 6:
                        Console.Write("Enter Booking ID: ");
                        int cancelBookingId = int.Parse(Console.ReadLine());

                        management.CancelBooking(cancelBookingId);
                        break;

                    case 7:
                        Console.Write("Enter Booking ID: ");
                        int checkInBookingId = int.Parse(Console.ReadLine());

                        management.CheckIn(checkInBookingId);
                        break;

                    case 8:
                        Console.Write("Enter Booking ID: ");
                        int viewBookingId = int.Parse(Console.ReadLine());

                        management.ViewBooking(viewBookingId);
                        break;

                    case 9:
                        Console.WriteLine("Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter valid input.");
            }
            catch (FlightException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (BookingException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}