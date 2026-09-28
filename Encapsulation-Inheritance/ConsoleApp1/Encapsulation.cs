using System;

public class bankAccount
{
    private decimal balance=500;
    private string accountNumber;
    private string accountHolder;
    public bankAccount(string acno,string accountHolder)
    {
        accountNumber = acno;
        this.accountHolder = accountHolder;
    }
    public decimal Balance { get { return balance; } }
    public string depositMoney(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount");
            Environment.Exit(0);
        }
        else
        {
            balance += amount;
        }
        return amount + "rs Deposited succefully!!";
    }
    public string withdrawMoney(decimal amount)
    {
        if (amount <= 0 || amount > balance)
        {
            Console.WriteLine("Invalid crediting amount");
            Environment.Exit(0);
        }
        else
        {
            balance -= amount;
        }
        return amount + "rs Credited succefully!!";


    }
    public string checkBalance(string accountNo)
    {
        if (accountNo == this.accountNumber)
        {
            return "Your current balance is " + balance;
        }
        else
        {
            return "Failed to fetch the balance details of an account";
        }
    }
}
