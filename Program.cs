using System;
using System.Collections.Generic;

namespace BankingSystem
{
    internal class Program
    {
        static List<Account> accounts = new List<Account>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to the Banking System!");
                Console.WriteLine("1. Create New Account");
                Console.WriteLine("2. Select Account");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateNewAccount();
                        break;

                    case "2":
                        SelectAccount();
                        break;

                    case "3":
                        Console.WriteLine("Thank you for using our banking system. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateNewAccount()
        {
            Console.WriteLine("\nEnter Account Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Account Number:");
            if (!int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Console.WriteLine("Invalid account number.");
                return;
            }

            Console.WriteLine("Enter Account Password:");
            string password = Console.ReadLine();

            Console.WriteLine("Enter Initial Balance:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal initialBalance))
            {
                Console.WriteLine("Invalid balance.");
                return;
            }

            // Check if account number already exists
            foreach (var account in accounts)
            {
                if (account.Accountnumber == accountNumber)
                {
                    Console.WriteLine("An account with this number already exists.");
                    return;
                }
            }

            // Create and add the new account to the list
            Account newAccount = new Account(accountNumber, name, password, initialBalance);
            accounts.Add(newAccount);

            Console.WriteLine("Account created successfully!");
        }

        static void SelectAccount()
        {
            Console.WriteLine("\nEnter Account Number:");
            if (!int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Console.WriteLine("Invalid account number.");
                return;
            }

            // Find the account by account number
            Account selectedAccount = accounts.Find(acc => acc.Accountnumber == accountNumber);
            if (selectedAccount == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }
            Console.WriteLine("\nEnter Account Password:");
            string pass = Console.ReadLine();
            if (selectedAccount.Password != pass)
            {
                Console.WriteLine("Invalid credentials");
                return;
            }

            Console.WriteLine($"Welcome, {selectedAccount.Name}!");
            ManageAccount(selectedAccount);
        }

        static void ManageAccount(Account account)
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Logout");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter deposit amount:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            account.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Enter withdrawal amount:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
                        {
                            account.Withdraw(withdrawalAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "3":
                        account.CheckBalance();
                        break;

                    case "4":
                        Console.WriteLine("Logging out...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
