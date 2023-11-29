/*
using TaskManager.services;
using TaskManager.database;
using TaskManager.utilities;

namespace TaskManager
{
    // Main entry point for the Task Manager application.
    public class Program
    {
        // Initializes database manager and input validator for the application.
        private readonly SQLiteDatabaseManager _dbManager = new SQLiteDatabaseManager();
        private readonly InputValidator _inputValidator = new InputValidator();

        // The main method sets console properties and displays the main menu.
        public void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "Task Manager";
            DisplayMainMenu();
        }

        // Displays the main menu and handles user navigation.
        private void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to Task Manager!");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                int userChoice = GetUserChoice();
                switch (userChoice)
                {
                    case 1:
                        PerformLogin();
                        break;
                    case 2:
                        PerformRegistration();
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        // Validates and returns the user's menu choice.
        private static int GetUserChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice) && choice is >= 1 and <= 3)
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number between 1 and 3.");
                return 0; // Indicates invalid input
            }
        }

        // Handles the login process and transitions to task management if successful.
        private void PerformLogin()
        {
            var loginManager = new LoginManager(_dbManager);
            int userId = loginManager.LoginHandler();

            if (userId != -1)
            {
                UTaskProgram
                    taskProgram =
                        new UTaskProgram(userId, _dbManager, _inputValidator); // Initiates task management for the logged-in user
                taskProgram.DisplayTaskMenu();
            }
            else
            {
                Console.WriteLine("Returning to main menu...");
            }
        }

        // Handles the user registration process.
        private void PerformRegistration()
        {
            var registrationManager = new RegistrationManager(_dbManager);
            bool registrationSuccess = registrationManager.RegisterHandler();
            Console.WriteLine(registrationSuccess
                ? "Registration successful!"
                : "Registration failed or cancelled, returning to main menu...");
        }
    }
}
*/