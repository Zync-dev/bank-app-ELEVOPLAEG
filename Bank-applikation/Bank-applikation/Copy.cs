using System;
using MySql.Data.MySqlClient;

namespace Bank_applikation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connString = "server = localhost; database = bank; user = root; password =;";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Forbundet til databasen!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl: " + ex.Message);
                }

                while(true)
                {

                }
            }

            void DisplayDashboard()
            {
                Console.WriteLine("Welcome.");
                Console.WriteLine("Please select an option:\n");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            void ExitProgram()
            {
                Environment.Exit(0);
            }

            void Deposit()
            {
                Console.WriteLine("Enter the amount to deposit:");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal amount))
                {
                    // Perform deposit logic here
                    Console.WriteLine($"Deposited: {amount}");
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }
            }

            void Withdraw()
            {
                Console.WriteLine("Enter the amount to withdraw:");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal amount))
                {
                    // Perform withdrawal logic here
                    Console.WriteLine($"Withdrew: {amount}");
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }
            }

            void ShowBalance()
            {
                Console.WriteLine("Your current balance is: 1000.00");
            }
        }
    }
}
