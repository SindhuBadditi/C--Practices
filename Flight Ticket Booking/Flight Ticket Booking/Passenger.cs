using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Ticket_Booking
{
    class Passenger
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public int Age { get; set; }
        public string PassportNumber { get; set; }

        public Passenger(int id, string name, int age, string passport)
        {
            PassengerId = id;
            PassengerName = name;
            Age = age;
            PassportNumber = passport;
        }

        public void DisplayPassengerDetails()
        {
            Console.WriteLine($"Passenger ID: {PassengerId}");
            Console.WriteLine($"Passenger Name: {PassengerName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Passport Number: {PassportNumber}");
        }
    }
}
