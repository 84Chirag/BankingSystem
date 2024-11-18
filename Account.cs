using System;

namespace BankingSystem
{
    public class Account
    {
        public int Accountnumber { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public decimal Balance { get; private set; }

        public Account(int accountNumber, string name, string password, decimal initialBalance)
        {
            Accountnumber = accountNumber;
            Name = name;
            Password = password;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"{amount} deposited successfully. Current balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"{amount} withdrawn successfully. Remaining balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds or invalid amount.");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"\nCurrent balance: {Balance}");
        }
    }
}
