using System;

class bankAccount
{
    private decimal balance = 500;
    private string accountNumber;
    private string accountHolder;

    public bankAccount(string acno, string accountHolder)
    {
        accountNumber = acno;
        this.accountHolder = accountHolder;
    }

    public decimal Balance
    {
        get { return balance; }
    }

    public void ValidateAccount(string accountNo)
    {
        if (accountNo != accountNumber)
        {
            throw new AccountNotFoundException(
                "Account with number " + accountNo + " was not found.");
        }
    }

    public string depositMoney(decimal amount)
    {
        if (amount <= 0)
        {
            throw new InvalidAmountException(
                "Amount should be greater than zero.");
        }

        balance += amount;

        return amount + " Rs Deposited successfully!!";
    }

    public string withdrawMoney(decimal amount)
    {
        if (amount <= 0 || amount > balance)
        {
            throw new InvalidAmountException(
                "Withdrawal amount must be greater than zero " +
                "and should not exceed the available balance.");
        }

        balance -= amount;

        return amount + " Rs Debited successfully!!";
    }

    public string checkBalance(string accountNo)
    {
        ValidateAccount(accountNo);

        return "Your current balance is " + balance + " Rs";
    }

    public string ViewAccountDetails(string accountNo)
    {
        ValidateAccount(accountNo);

        return "\n--- Account Details ---" +
               "\nAccount Number: " + accountNumber +
               "\nAccount Holder: " + accountHolder +
               "\nCurrent Balance: " + balance + " Rs";
    }
}

class Banking
{
    static void Main(string[] args)
    {
        bankAccount bank = null;

        while (true)
        {
            Console.WriteLine("\n--- Banking Menu ---");
            Console.WriteLine("1. Add Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. View Account Details");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("\nAdding Account");

                        Console.Write("Enter Account Number: ");
                        string accountNumber = Console.ReadLine();

                        Console.Write("Enter Account Holder Name: ");
                        string name = Console.ReadLine();

                        bank = new bankAccount(accountNumber, name);

                        Console.WriteLine(
                            "Account created successfully.");

                        break;
                    }

                case 2:
                    {
                        try
                        {
                            Console.WriteLine("\nDepositing Money");

                            Console.Write("Enter Account Number: ");
                            string accountNo = Console.ReadLine();

                            bank.ValidateAccount(accountNo);

                            Console.Write("Enter deposit amount: ");
                            decimal amount =
                                decimal.Parse(Console.ReadLine());

                            Console.WriteLine(
                                bank.depositMoney(amount));
                        }
                        catch (AccountNotFoundException ex)
                        {
                            Console.WriteLine(
                                "Exception-Message: " + ex.Message);
                        }
                        catch (InvalidAmountException ex)
                        {
                            Console.WriteLine(
                                "Exception-Message: " + ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine(
                                "Deposit operation completed.");
                        }

                        break;
                    }

                case 3:
                    {
                        try
                        {
                            Console.WriteLine("\nWithdrawing Money");

                            Console.Write("Enter Account Number: ");
                            string accountNo = Console.ReadLine();

                            bank.ValidateAccount(accountNo);

                            Console.Write("Enter withdrawal amount: ");
                            decimal amount =
                                decimal.Parse(Console.ReadLine());

                            Console.WriteLine(
                                bank.withdrawMoney(amount));
                        }
                        catch (AccountNotFoundException ex)
                        {
                            Console.WriteLine(
                                "Exception-Message: " + ex.Message);
                        }
                        catch (InvalidAmountException ex)
                        {
                            Console.WriteLine(
                                "Exception-Message: " + ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine(
                                "Withdrawal operation completed.");
                        }

                        break;
                    }

                case 4:
                    {
                        try
                        {
                            Console.WriteLine("\nChecking Balance");

                            Console.Write("Enter Account Number: ");
                            string accountNo = Console.ReadLine();

                            Console.WriteLine(
                                bank.checkBalance(accountNo));
                        }
                        catch (AccountNotFoundException ex)
                        {
                            Console.WriteLine(
                                "Exception-Message: " + ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine(
                                "Balance checking operation completed.");
                        }

                        break;
                    }

                case 5:
                    {
                        try
                        {
                            Console.WriteLine(
                                "\nViewing Account Details");

                            Console.Write("Enter Account Number: ");
                            string accountNo = Console.ReadLine();

                            Console.WriteLine(
                                bank.ViewAccountDetails(accountNo));
                        }
                        catch (AccountNotFoundException ex)
                        {
                            Console.WriteLine(
                                "Exception-Message: " + ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine(
                                "Account viewing operation completed.");
                        }

                        break;
                    }

                case 6:
                    {
                        Console.WriteLine("Exiting.....");
                        return;
                    }

                default:
                    {
                        Console.WriteLine("Invalid choice!!!!");
                        break;
                    }
            }
        }
    }
}

class InvalidAmountException : ApplicationException
{
    public InvalidAmountException(string message)
        : base(message)
    {
    }
}

class AccountNotFoundException : ApplicationException
{
    public AccountNotFoundException(string message)
        : base(message)
    {
    }
}