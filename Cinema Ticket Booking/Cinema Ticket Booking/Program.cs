class Booking
{
    protected static decimal totalRevenue = 0;
    static String[] seats = new string[10];
    static string[] customerNames = new string[10];
    static string[] ticketTypes = new string[10];

    static int count = 0;
    private string BookingID;
    private string CustomerName;
    private int SeatNumbe
    static readonly string MovieName="Doraemon";
    private string ticketType;
    public Booking(string name)
    {
        this.CustomerName = name;
    }
    public Booking() { }
    public string BookingId
    {
        get
        {
            return this.BookingID;
        }
    }
    public string Ticket
    {
        get
        {
            return ticketType;
        }
        set
        {
            ticketType= value;
        }
    }
    static void Main(String[] args)
    {
        Array.Fill(seats,"available");
        Booking b=new Booking();
        while (true)
        {
            Console.WriteLine("\n===== TICKET BOOKING SYSTEM =====");
            Console.WriteLine("1. View the current seat status");
            Console.WriteLine("2. Book a ticket");
            Console.WriteLine("3. Cancel a booking");
            Console.WriteLine("4. Search for a booking using the booking ID");
            Console.WriteLine("5. Display booking details");
            Console.WriteLine("6. Display total number of bookings and available seats");
            Console.WriteLine("7. Display total revenue");
            Console.WriteLine("8. Exit the system");

            Console.Write("Enter your choice: ");

            int choice=Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nViewing current seat status...");
                    Console.Write("Enter seat number:");
                    int seat=Convert.ToInt32(Console.ReadLine());
                    b.seatStatus(seat);
                    break;

                case 2:
                    Console.WriteLine("\nBooking a ticket...");
                    Console.Write("Customer Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter seat number: ");
                    int seatNo = Convert.ToInt32(Console.ReadLine());

                    b = new Booking(name);
                    b.BookTicket(seatNo);

                    break;

                case 3:
                    Console.WriteLine("\nCancelling a booking...");
                    Console.Write("Enter your Booking id:");
                    string id = Console.ReadLine();
                    b.CancelTicket(id);
                    break;

                case 4:
                    Console.WriteLine("\nSearching for booking...");
                    Console.Write("Enter your Booking id:");
                    string bookid = Console.ReadLine();
                    b.searchBooking(bookid);
                    break;

                case 5:
                    Console.WriteLine("\nDisplaying booking details...");
                    Console.Write("Enter your Booking id:");
                    string bid=Console.ReadLine();
                    b.bookingDetails(bid);
                    break;

                case 6:
                    Console.WriteLine("\nDisplaying booking count and available seats...");
                    b.bookingCount();
                    break;

                case 7:
                    Console.WriteLine("\nDisplaying total revenue...");
                    Console.WriteLine($"Total revenue {totalRevenue}");
                    break;

                case 8:
                    Console.WriteLine("\nExiting the system...");
                    return;

                default:
                    Console.WriteLine("\nInvalid choice. Please select 1-8.");
                    break;
            }
        }
    }
    public void seatStatus(int seatNumber)
    {
        bool isFound=false;
        for (int i = 0; i < seats.Length; i++)
        {
            if (seatNumber == (i + 1))
            {
                Console.WriteLine($"{seatNumber} is {seats[i]}");
                isFound = true;
                break;
            }
        }
        if (!isFound)
        {
            Console.WriteLine($"{seatNumber} is unavailable");
        }
    }
    public void BookTicket(int seatNo)
    {
        bool isFound = false;
        for (int i = 0; i < seats.Length; i++)
        {
            if (seatNo == (i + 1) && seats[i].Equals("available"))
            {
                BookingID = MovieName.Substring(0, 4) + ++count;

                Console.Write("Customer Ticket Type (GENERAL/PREMIUM): ");
                string type = Console.ReadLine().ToUpper();
                if (type != "GENERAL" && type != "PREMIUM")
                {
                    Console.WriteLine("Invalid ticket type.");
                    return;
                }
                Ticket = type;
                seats[i] = BookingID;
                customerNames[i] = CustomerName;
                ticketTypes[i] = Ticket;
                if (Ticket == "PREMIUM")
                {
                    Premium premium = new Premium();
                    premium.ticketTypeVerify(Ticket);
                }
                else
                {
                    General general = new General();
                    general.ticketTypeVerify(Ticket);
                }
                Console.WriteLine("\nBooking successful!");
                Console.WriteLine($"Booking ID: {BookingID}");
                Console.WriteLine($"Customer: {CustomerName}");
                Console.WriteLine($"Seat Number: {seatNo}");
                Console.WriteLine($"Ticket Type: {Ticket}");
                isFound = true;
                break;
            }
        }
        if (!isFound)
        {
            Console.WriteLine($"{seatNo} is unavailable");
        }
    }
    public void CancelTicket(string id)
    {
        bool isFound = false;
        for (int i = 0; i < seats.Length; i++)
        {
            if (ticketTypes[i] == "PREMIUM")
            {
                totalRevenue -= 250;
            }
            else if (ticketTypes[i] == "GENERAL")
            {
                totalRevenue -= 150;
            }

            if (seats[i] == id)
            {
                seats[i] = "available";
                customerNames[i] = null;
                ticketTypes[i] = null;
                Console.WriteLine("Booking cancelled successfully.");
                isFound = true;
                break;
            }
        }
        if (!isFound)
        {
            Console.WriteLine($"{id}Booking Id not found");
        }
    }
    public void searchBooking(string bid)
    {
        bool isFound = false;
        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i] == bid)
            {
                Console.WriteLine("\nBooking found!");
                Console.WriteLine($"Booking ID: {seats[i]}");
                Console.WriteLine($"Customer: {customerNames[i]}");
                Console.WriteLine($"Seat Number: {i + 1}");
                Console.WriteLine($"Ticket Type: {ticketTypes[i]}");
                isFound = true;
                break;
            }
        }
        if (!isFound)
        {
            Console.WriteLine($"{bid} Booking ID not found.");
        }

    }
    public void bookingDetails(string id)
    {
        bool isFound = false;

        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i] == id)
            {
                Console.WriteLine("\n===== BOOKING DETAILS =====");
                Console.WriteLine($"Movie: {MovieName}");
                Console.WriteLine($"Booking ID: {seats[i]}");
                Console.WriteLine($"Customer Name: {customerNames[i]}");
                Console.WriteLine($"Seat Number: {i + 1}");
                Console.WriteLine($"Ticket Type: {ticketTypes[i]}");

                isFound = true;
                break;
            }
        }

        if (!isFound)
        {
            Console.WriteLine("Booking ID not found.");
        }
    }
    public void bookingCount()
    {
        int availableCount = 0;
        int bookedCount = 0;
        for(int i = 0; i < seats.Length; i++)
        {
            if (seats[i].Equals("available"))
            {
                availableCount++;
            }
            else
            {
                bookedCount++;
            }
        }
        Console.WriteLine($"available seats Count is {availableCount}");
        Console.WriteLine($"Booked seats count is {bookedCount}");
    }

}
class Premium : Booking
{
    decimal ticketCost;
    public Premium() { }
    public Premium(string name) : base(name)
    {
        
    }
    public void ticketTypeVerify(string ticketType)
    {
        if (ticketType == "PREMIUM")
        {
            this.ticketCost = 150;
            Booking.totalRevenue += ticketCost;
        }
        else
        {
            return;
        }
    }
}
class General : Booking
{
    decimal ticketCost;
    public General() { }
    public General(string name) : base(name)
    {
        
    }
    public void ticketTypeVerify(string ticketType)
    {
        if (ticketType != "PREMIUM")
        {
            this.ticketCost = 250;
            Booking.totalRevenue += ticketCost;
        }
        else
        {
            return;
        }
    }
}