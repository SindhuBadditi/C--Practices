using System;

class Hotel
{
    public static Room[] rooms = new Room[10];

    static void Main(string[] args)
    {
        // Create 5 Standard Rooms
        for (int i = 0; i < 5; i++)
        {
            rooms[i] = new StandardRoom(i + 1);
        }

        // Create 5 Deluxe Rooms
        for (int i = 5; i < 10; i++)
        {
            rooms[i] = new DeluxeRoom(i + 1);
        }

        Hotel h = new Hotel();

        while (true)
        {
            Console.WriteLine("\n===== HOTEL BOOKING SYSTEM =====");
            Console.WriteLine("1. View available rooms");
            Console.WriteLine("2. Book a room");
            Console.WriteLine("3. Cancel a booking");
            Console.WriteLine("4. View booking details");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nViewing available rooms...");
                    h.DisplayDetails();
                    break;

                case 2:
                    Console.WriteLine("\nBooking a room...");
                    Console.Write("\nEnter room number: ");
                    int roomNo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter customer name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter customer mobile number: ");
                    long mobile = Convert.ToInt64(Console.ReadLine());

                    Console.Write("Enter number of days: ");
                    int days = Convert.ToInt32(Console.ReadLine());

                    Customer customer = new Customer(name, mobile, days);

                    h.BookRoom(roomNo, customer);
                    break;

                case 3:
                    Console.WriteLine("\nCancelling a booking...");
                    Console.Write("\nEnter room number: ");
                    int cancelRoom = Convert.ToInt32(Console.ReadLine());

                    h.CancelBooking(cancelRoom);
                    break;

                case 4:
                    Console.WriteLine("\nViewing booking details...");
                    Console.Write("\nEnter room number: ");
                    int bookingRoom = Convert.ToInt32(Console.ReadLine());

                    h.ViewBookingDetails(bookingRoom);
                    break;

                case 5:
                    Console.WriteLine("Thank you for using the Hotel Booking System.");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    // Display available rooms
    public void DisplayDetails()
    {
        Console.WriteLine("\nAvailable Rooms:");

        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].IsAvailable)
            {
                Console.WriteLine(
                    $"Room {rooms[i].RoomNumber} - {rooms[i].RoomType}");
            }
        }
    }

    // Book a room
    public void BookRoom(int roomNo, Customer customer)
    {
        if (roomNo < 1 || roomNo > rooms.Length)
        {
            Console.WriteLine("Invalid room number.");
            return;
        }

        Room room = rooms[roomNo - 1];

        if (!room.IsAvailable)
        {
            Console.WriteLine("Room is already booked.");
            return;
        }

        room.BookRoom(customer);
    }

    // Cancel booking
    public void CancelBooking(int roomNo)
    {
        if (roomNo < 1 || roomNo > rooms.Length)
        {
            Console.WriteLine("Invalid room number.");
            return;
        }

        Room room = rooms[roomNo - 1];

        if (room.IsAvailable)
        {
            Console.WriteLine("This room is not booked.");
            return;
        }

        room.CancelBooking();

        Console.WriteLine("Booking cancelled successfully.");
    }

    // View booking details
    public void ViewBookingDetails(int roomNo)
    {
        if (roomNo < 1 || roomNo > rooms.Length)
        {
            Console.WriteLine("Invalid room number.");
            return;
        }

        Room room = rooms[roomNo - 1];

        if (room.IsAvailable)
        {
            Console.WriteLine("This room is not booked.");
            return;
        }

        Console.WriteLine("\n===== BOOKING DETAILS =====");
        Console.WriteLine($"Room Number : {room.RoomNumber}");
        Console.WriteLine($"Room Type   : {room.RoomType}");
        Console.WriteLine(room.Customer);
        Console.WriteLine($"Total Amount: {room.CalculateAmount():F2}");
    }
}


// Base Room class
abstract class Room
{
    public int RoomNumber { get; }

    public bool IsAvailable { get; private set; }

    public Customer Customer { get; private set; }

    public abstract string RoomType { get; }

    protected Room(int roomNumber)
    {
        RoomNumber = roomNumber;
        IsAvailable = true;
    }

    public void BookRoom(Customer customer)
    {
        Customer = customer;
        IsAvailable = false;

        Console.WriteLine("Room booked successfully.");
        Console.WriteLine($"Total Amount: {CalculateAmount():F2}");
    }

    public void CancelBooking()
    {
        Customer = null;
        IsAvailable = true;
    }

    public abstract decimal CalculateAmount();
}


// Standard Room
class StandardRoom : Room
{
    public StandardRoom(int roomNumber) : base(roomNumber)
    {
    }

    public override string RoomType
    {
        get
        {
            return "Standard Room";
        }
    }

    public override decimal CalculateAmount()
    {
        return 2000 * Customer.NoOfDaysStay;
    }
}


// Deluxe Room
class DeluxeRoom : Room
{
    public DeluxeRoom(int roomNumber) : base(roomNumber)
    {
    }

    public override string RoomType
    {
        get
        {
            return "Deluxe Room";
        }
    }

    public override decimal CalculateAmount()
    {
        decimal roomAmount = 3500 * Customer.NoOfDaysStay;
        decimal serviceCharge = roomAmount * 10 / 100;

        return roomAmount + serviceCharge;
    }
}


// Customer class
class Customer
{
    public string Cname { get; set; }

    public long Mobile { get; set; }

    public int NoOfDaysStay { get; set; }

    public Customer(string cname, long mobile, int noOfDaysStay)
    {
        Cname = cname;
        Mobile = mobile;
        NoOfDaysStay = noOfDaysStay;
    }

    public override string ToString()
    {
        return $"Customer Name: {Cname}\n" +
               $"Mobile: {Mobile}\n" +
               $"Days Stayed: {NoOfDaysStay}";
    }
}