using System;
using System.Net.NetworkInformation;
namespace ConsoleApp
{
    struct Vehicle{
        public string vehicleNumber;
    }
    class ParkingSlot
    {
        public static String[] arr = { "available", "available", "available", "available", "available" };
        public static int availableCount=5;
        public static int reservedCount = 0;
        static void Main(String[] args)
        {
            ParkingSlot p=new ParkingSlot();
            while (true)
            {
                Console.WriteLine("\n1. For Parking");
                Console.WriteLine("2. For removing the vehicle in parking");
                Console.WriteLine("3. For Parking status");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1: parkingSlot();
                        break;
                   case 2: Console.Write("\nEnter Vehicle Number: ");
                            string number = Console.ReadLine();
                        p.makeFreeSlot(number);
                        break;
                   case 3: p.parkingStatus();
                        break;
                   case 4:Console.WriteLine("\nExiting.........."); 
                        Environment.Exit(0);
                        break;
                    default: Console.WriteLine("\nSelect appropriate choice");
                        break;
                }
            }

        }
        public static void parkingSlot()
        {
            bool status = false;
            Vehicle v = new Vehicle();
            Console.Write("\nEnter Vehicle Number: ");
            string number = Console.ReadLine();
            v.vehicleNumber = number;
            for (int i = 0; i < arr.Length; i++)
            {
                 bool verify = false;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j].Equals(v.vehicleNumber))
                    {
                        Console.WriteLine("Duplicate Vehicle Entry");
                        verify = true;
                        return;
                    }
                }
                if (arr[i].Equals("available"))
                {   
                    if (!verify)
                    {
                        arr[i] = v.vehicleNumber;
                        reservedCount++;
                        availableCount--;
                        status = true;
                        break;
                    }
                }
            }
            if (!status)
            {
                Console.WriteLine("Sorry! All slots are booked");
                return;
            }
        }
        public void makeFreeSlot(String vehicleNumber)
        {
            bool found = false;
            for(int k=0;k<arr.Length;k++)
            {
                if (arr[k].Equals(vehicleNumber))
                {
                    found = true;
                    arr[k] = "available";
                    Console.WriteLine("Now you can take your vehicle");
                    availableCount++;
                    reservedCount--;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("your vehicle is not found in our records");
            }
        }
        public void parkingStatus()
        {
            Console.WriteLine("\nTotal Parking slots:"+arr.Length);
            for(int i=0;i<arr.Length;i++)
            {
                if (!arr[i].Equals("available"))
                {
                    Console.WriteLine("Reserved at "+(i+1)+" slot with " + arr[i]);
                }
                else
                {
                    Console.WriteLine(arr[i] +" slot at "+ (i + 1));
                }
            }
        }
    }
}