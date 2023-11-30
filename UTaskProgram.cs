using TaskManager.database;
using TaskManager.utilities;
using TaskManager.services;

namespace TaskManager
{
    // Manages the task-related functionalities for a user, including viewing and managing tasks.
    public class UTaskProgram
    {
        private readonly int _userId;
        private readonly SQLiteDatabaseManager _dbManager;
        private readonly InputValidator _inputValidator;

        // Constructor to initialize UTaskProgram with user ID, database manager, and input validator.
        public UTaskProgram(int userId, SQLiteDatabaseManager dbManager, InputValidator inputValidator)
        {
            _userId = userId;
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
            _inputValidator = inputValidator ?? throw new ArgumentNullException(nameof(inputValidator));
        }

        // Displays the task management menu and handles user choices.
        public void DisplayTaskMenu()
        {
            while (true)
            {
                Console.WriteLine("\nTask Dashboard:");
                Console.WriteLine("1. View My Tasks");
                Console.WriteLine("2. Manage Tasks");
                Console.WriteLine("3. Logout");

                Console.Write("Enter your choice: ");
                int choice = GetUserChoice();
                switch (choice)
                {
                    case 1:
                        ViewAllTasksForUser(_userId);
                        break;
                    case 2:
                        UTaskManager taskManager = new UTaskManager(_dbManager, _inputValidator);
                        taskManager.DisplayTaskManagementMenu(_userId);
                        break;
                    case 3:
                        Console.WriteLine("Logging out...");
                        return; // Exit the task dashboard and return to the main menu.
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        // Retrieves and displays all tasks associated with the user.
        private void ViewAllTasksForUser(int userId)
        {
            var uTasks = _dbManager.GetUserTasksForUser(userId);
            var enumerable = uTasks as Task[] ?? uTasks.ToArray();
            if (enumerable.Any())
            {
                Console.WriteLine("\nYour tasks:");
                foreach (var uTask in enumerable)
                {
                    Console.WriteLine("Task ID: " + uTask.Id + ", Title: " + uTask.Title + ", Due Date: " + uTask.DueDate.ToShortDateString());                }
            }
            else
            {
                Console.WriteLine("No tasks found for this user.");
            }
        }

        // Validates and returns the user's menu choice input.
        private int GetUserChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number.");
                return -1; // Indicates invalid input
            }
        }
    }
}