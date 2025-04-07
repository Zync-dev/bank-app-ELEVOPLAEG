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
                    Console.WriteLine("Forbundet til databasen!");

                    while (true)
                    {
                        Console.WriteLine("Velkommen til banken!");

                        Console.WriteLine("\nVælg en mulighed:");
                        Console.WriteLine("1. Log Ind");
                        Console.WriteLine("2. Opret Konto");
                        Console.Write("Indtast dit valg: ");
                        string valg = Console.ReadLine(); Console.Clear();

                        if (valg == "1")
                        {
                            Console.WriteLine("Indtast dit Brugernavn");
                            string username = Console.ReadLine();

                            Console.WriteLine("Indtast dit Password");
                            string password = Console.ReadLine();


                        }
                        else if (valg == "2")
                        {
                            Console.WriteLine("Indtast dit ønskede Brugernavn");
                            string username = Console.ReadLine();

                            Console.WriteLine("Indtast dit ønskede Password");
                            string password = Console.ReadLine();

                            CreateUser(conn, username, password);
                            {

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fejl: " + ex.Message);
                }

                static void CreateUser(MySqlConnection conn, string username, string password)
                {
                    string query = "INSERT INTO users (username, password) VALUES (@username, @password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int rows = cmd.ExecuteNonQuery();
                        Console.WriteLine(rows > 0 ? $"Inserted {username} successfully!" : "Insert failed.");
                    }
                }

                static void LogIn(MySqlConnection conn, string username, string password)
                {
                    
                }
            }
        }


    }
}
