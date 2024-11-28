using System;
using System.IO;

namespace ATM_MachineSimulator_ConsoleApp
{
    class ATM
    {
        static string filePath = "account.txt";

        static void Main()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Creating a new account with a default balance of 1000");
                File.WriteAllText(filePath, "1000");
            }

            Console.WriteLine("Welcome to the ATM!");

            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CheckBalance();
                        break;
                    case "2":
                        DepositMoney();
                        break;
                    case "3":
                        WithdrawMoney();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CheckBalance()
        {
            decimal balance = GetBalance();
            Console.WriteLine($"Your current balance is: {balance:C}");
        }

        static void DepositMoney()
        {
            Console.Write("Enter the amount to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
            {
                decimal balance = GetBalance();
                balance += depositAmount;
                UpdateBalance(balance);
                Console.WriteLine($"Deposit successful! Your new balance is: {balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please try again.");
            }
        }

        static void WithdrawMoney()
        {
            Console.Write("Enter the amount to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount) && withdrawalAmount > 0)
            {
                decimal balance = GetBalance();
                if (withdrawalAmount <= balance)
                {
                    balance -= withdrawalAmount;
                    UpdateBalance(balance);
                    Console.WriteLine($"Withdrawal successful! Your new balance is: {balance:C}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds. Please try a smaller amount.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Please try again.");
            }
        }

        static decimal GetBalance()
        {
            try
            {
                string balanceText = File.ReadAllText(filePath);
                return decimal.Parse(balanceText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading balance: {ex.Message}");
                return 0;
            }
        }

        static void UpdateBalance(decimal balance)
        {
            try
            {
                File.WriteAllText(filePath, balance.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating balance: {ex.Message}");
            }
        }
    }

}
