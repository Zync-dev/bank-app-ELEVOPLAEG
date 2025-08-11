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

                    while (true)
                    {
                        DisplayMenu();

                        string choice = Console.ReadLine();
                        Console.Clear();

                        switch(choice)
                        {
                            case "1":
                                HandleLogIn(conn);
                                break;
                            case "2":
                                HandleCreateAccount(conn);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl: " + ex.Message);
                }

                Console.ReadLine();
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("Velkommen til banken!");
            Console.WriteLine("\nVælg en mulighed:");
            Console.WriteLine("1. Log Ind");
            Console.WriteLine("2. Opret Konto");
            Console.Write("Indtast dit valg: ");
        }

        static void HandleLogIn(MySqlConnection conn)
        {
            Console.WriteLine("Indtast dit Brugernavn");
            string username = Console.ReadLine();

            Console.WriteLine("Indtast dit Password");
            string password = Console.ReadLine();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Brugernavn og password må ikke være tomme.");
                return;
            }

            LogIn(conn, username, password);
        }

        static void HandleCreateAccount(MySqlConnection conn)
        {
            Console.WriteLine("Indtast dit ønskede Brugernavn");
            string username = Console.ReadLine();

            Console.WriteLine("Indtast dit ønskede Password");
            string password = Console.ReadLine();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Brugernavn og password må ikke være tomme.");
                return;
            }

            CreateUser(conn, username, password);
        }

        static void CreateUser(MySqlConnection conn, string username, string password)
        {
            string query = "INSERT INTO bank (username, password) VALUES (@username, @password)";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? $"Bruger {username} oprettet!" : "Oprettelse mislykkedes.");
            }
        }

        static void LogIn(MySqlConnection conn, string username, string password)
        {
            string query = "SELECT COUNT(*) FROM bank WHERE username = @username AND password = @password";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // Consider hashing the password

                int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine(userCount > 0 ? "Log ind succesfuld!" : "Log ind mislykkedes. Tjek brugernavn og password.");
            }
        }
    }
}
