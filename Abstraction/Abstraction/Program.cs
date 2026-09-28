abstract class Payment
{
    public abstract void Pay(decimal amount);
}

class CreditCard : Payment
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} using Credit Card");
    }
}

class UPI : Payment
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} using UPI");
    }
}

class Program
{
    static void Main()
    {
        Payment payment;

        payment = new CreditCard();
        payment.Pay(1000);

        payment = new UPI();
        payment.Pay(500);
    }
}