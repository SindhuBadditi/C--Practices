using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<string> parkingArea = new Stack<string>();

        while (true)
        {
            Console.WriteLine("\n1. Park a Vehicle");
            Console.WriteLine("2. Remove Most Recently Parked Vehicle");
            Console.WriteLine("3. Check Vehicle at Exit Position");
            Console.WriteLine("4. Check Whether Vehicle Is Parked");
            Console.WriteLine("5. Display All Parked Vehicles");
            Console.WriteLine("6. Display Total Number of Parked Vehicles");
            Console.WriteLine("7. Clear All Parked Vehicles");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("\nParking a vehicle");
                        Console.Write("Enter vehicle number: ");

                        string vehicle = Console.ReadLine();

                        parkingArea.Push(vehicle);

                        Console.WriteLine("Vehicle parked successfully.");

                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("\nRemoving most recently parked vehicle");

                        if (parkingArea.Count > 0)
                        {
                            string vehicle = parkingArea.Pop();

                            Console.WriteLine("Vehicle removed: " + vehicle);
                        }
                        else
                        {
                            Console.WriteLine("No vehicles are currently parked.");
                        }

                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("\nChecking vehicle at exit position");

                        if (parkingArea.Count > 0)
                        {
                            string vehicle = parkingArea.Peek();

                            Console.WriteLine("Vehicle at exit position: " + vehicle);
                        }
                        else
                        {
                            Console.WriteLine("No vehicles are currently parked.");
                        }

                        break;
                    }

                case 4:
                    {
                        Console.WriteLine("\nChecking whether vehicle is parked");
                        Console.Write("Enter vehicle number: ");

                        string vehicle = Console.ReadLine();

                        bool result = parkingArea.Contains(vehicle);

                        if (result)
                        {
                            Console.WriteLine("Yes. " + vehicle + " is currently parked.");
                        }
                        else
                        {
                            Console.WriteLine("No. " + vehicle + " is not currently parked.");
                        }

                        break;
                    }

                case 5:
                    {
                        Console.WriteLine("\nDisplaying all parked vehicles");

                        if (parkingArea.Count > 0)
                        {
                            IEnumerator<string> enumerator =
                                parkingArea.GetEnumerator();

                            Console.WriteLine("Parked vehicles:");

                            while (enumerator.MoveNext())
                            {
                                Console.WriteLine(enumerator.Current);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No vehicles are currently parked.");
                        }

                        break;
                    }

                case 6:
                    {
                        Console.WriteLine(
                            "\nTotal number of parked vehicles: "
                            + parkingArea.Count);

                        break;
                    }

                case 7:
                    {
                        Console.WriteLine("\nClearing all parked vehicles");

                        parkingArea.Clear();

                        Console.WriteLine("All parked vehicles have been removed.");

                        break;
                    }

                case 8:
                    {
                        Console.WriteLine("Exiting...");
                        return;
                    }

                default:
                    {
                        Console.WriteLine("Invalid choice.");
                        break;
                    }
            }
        }
    }
}