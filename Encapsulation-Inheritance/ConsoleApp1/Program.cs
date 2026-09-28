
using ConsoleApp1;

class checkingData
{
    static void Main(String[] args)
    {
        //-----Encapsulation------
        /*bankAccount bank = new bankAccount("SBIN46556684","John");
        Console.WriteLine(bank.depositMoney(45000));
        Console.WriteLine(bank.withdrawMoney(2000));
        Console.WriteLine(bank.checkBalance("SBIN46556684"));*/

        //-----Inheritance-------
        Car car = new Car("Toyata", "Camry", 2024, 4);
        Bike bike = new Bike("Yamaha", "R15", 2025, true);
        car.displayDetails();
        Console.WriteLine();
        bike.displayDetails();
    }
}       