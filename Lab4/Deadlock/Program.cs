using System.ComponentModel;
using System.Transactions;
using System;
using System.Data.SqlClient;

namespace Deadlock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = @"Data Source=SKY-PC;Initial Catalog=EarthNew;Integrated Security=True";

            int retryCount = 0;
            bool success = false;

            while (!success && retryCount < 3)
            {
                Console.WriteLine("Retry count: " + retryCount);

                Thread thread1 = new Thread(() =>
                {
                    Console.WriteLine("Thread1 is running!");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Set the deadlock priority to HIGH
                        using (SqlCommand setDeadlockPriorityCommand = connection.CreateCommand())
                        {
                            setDeadlockPriorityCommand.CommandText = "SET DEADLOCK_PRIORITY HIGH";
                            setDeadlockPriorityCommand.ExecuteNonQuery();
                        }

                        // Create a new transaction
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                using (SqlCommand command = connection.CreateCommand())
                                {
                                    command.Transaction = transaction;

                                    // Update statement 1
                                    command.CommandText = "UPDATE Professions SET profession_name = 'Transaction1' WHERE profession_id = 3";
                                    command.ExecuteNonQuery();

                                    // Delay for 5 seconds
                                    Thread.Sleep(5000);

                                    // Update statement 2
                                    command.CommandText = "UPDATE Religions set religion_name = 'Transaction1' WHERE religion_id = 2";
                                    command.ExecuteNonQuery();
                                }

                                // Commit the transaction
                                transaction.Commit();
                                Console.WriteLine("Transaction committed successfully.");
                                success = true;
                            }
                            catch (SqlException ex)
                            {
                                if (ex.Number == 1205) // Deadlock error number
                                {
                                    // Handle deadlock, rollback the transaction, and retry
                                    Console.WriteLine("Deadlock occurred. Retrying...");

                                    transaction.Rollback();
                                    Console.WriteLine("Transaction rolled back.");
                                    retryCount++;
                                }
                                else
                                {
                                    // Handle other exceptions
                                    Console.WriteLine("Error occurred: " + ex.Message);
                                    transaction.Rollback();
                                    Console.WriteLine("Transaction rolled back.");
                                }
                            }
                        }
                    }
                });

                Thread thread2 = new Thread(() =>
                {
                    Console.WriteLine("Thread2 is running!");
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Create a new transaction
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                using (SqlCommand command = connection.CreateCommand())
                                {
                                    command.Transaction = transaction;

                                    // Update statement 1
                                    command.CommandText = "UPDATE Religions set religion_name = 'Transaction1' WHERE religion_id = 2";
                                    command.ExecuteNonQuery();

                                    // Delay for 5 seconds
                                    Thread.Sleep(5000);

                                    // Update statement 2
                                    command.CommandText = "UPDATE Professions SET profession_name = 'Transaction1' WHERE profession_id = 3";
                                    command.ExecuteNonQuery();
                                }

                                // Commit the transaction
                                transaction.Commit();
                                Console.WriteLine("Transaction committed successfully.");
                                success = true;
                            }
                            catch (SqlException ex)
                            {
                                if (ex.Number == 1205) // Deadlock error number
                                {
                                    // Handle deadlock, rollback the transaction, and retry
                                    Console.WriteLine("Deadlock occurred. Retrying...");

                                    transaction.Rollback();
                                    Console.WriteLine("Transaction rolled back.");
                                    retryCount++;
                                }
                                else
                                {
                                    // Handle other exceptions
                                    Console.WriteLine("Error occurred: " + ex.Message);
                                    transaction.Rollback();
                                    Console.WriteLine("Transaction rolled back.");
                                }
                            }
                        }
                    }
                });

                thread1.Start();
                thread2.Start();
                thread1.Join();
                thread2.Join();
            }

            if (retryCount >= 3)
            {
                Console.WriteLine("Exceeded maximum retry attempts. Aborting.");
            }
            else
            {
                Console.WriteLine("All transactions completed.");
            }
        }
    }
}
