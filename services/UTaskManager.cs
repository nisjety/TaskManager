using TaskManager.database;
using TaskManager.interfaces;
using TaskManager.models;
using TaskManager.utilities;

namespace TaskManager.services
{
    // Manages user tasks including creation, deletion, and displaying task management options.
    public class UTaskManager : IUTaskManagement
    {
        private readonly SQLiteDatabaseManager _dbManager;
        private readonly InputValidator _inputValidator;

        // Constructor for UTaskManager with database and input validation dependencies.
        public UTaskManager(SQLiteDatabaseManager dbManager, InputValidator inputValidator)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
            _inputValidator = inputValidator ?? throw new ArgumentNullException(nameof(inputValidator));
        }

        // Displays the task management menu and handles user interaction.
        public void DisplayTaskManagementMenu(int userId)
        {
            bool continueManagingTasks = true;
            while (continueManagingTasks)
            {
                Console.WriteLine("\nTask Management Menu:");
                Console.WriteLine("1. Add New Task");
                Console.WriteLine("2. Delete Existing Task");
                Console.WriteLine("3. Return to Previous Menu");

                Console.Write("Enter your choice: ");
                int choice = GetUserChoice();
                switch (choice)
                {
                    case 1:
                        CreateUserTask(userId);
                        break;
                    case 2:
                        DeleteTask(userId);
                        break;
                    case 3:
                        continueManagingTasks = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        // Handles creating a new user task including input validation.
        public void CreateUserTask(int userId)
        {
            Console.WriteLine("Enter the title of the new task:");
            string title = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter a note for the task:");
            string note = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter the due date for the task (YYYY-MM-DD):");
            string dueDateString = Console.ReadLine() ?? string.Empty;

            // Validates the title and due date inputs before creating the task.
            if (!_inputValidator.IsValidTitle(title) || !_inputValidator.IsValidDate(dueDateString, out DateTime dueDate))
            {
                Console.WriteLine("Invalid input for title or date. Task was not created.");
                return;
            }

            try
            {
                // Creates and adds a new task to the database.
                var newUTask = new UTask(title, note, dueDate);
                bool created = _dbManager.CreateUserTask(newUTask);
                Console.WriteLine(created
                    ? "Task created successfully."
                    : "An error occurred while creating the task. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // handle deleting of tasks
        public void DeleteTask(int uTaskId)
        {
            Console.WriteLine("Are you sure you want to delete this task? (yes/no)");
            var confirmation = Console.ReadLine() ?? string.Empty;

            // deletes a user task if the user confirms.
            if (confirmation.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    bool deleted = _dbManager.DeleteUserTaskById(uTaskId);
                    Console.WriteLine(
                        deleted ? "Task deleted successfully." : "Task deletion failed or task not found.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Task deletion canceled.");
            }
        }

        // gets the user's menu choice input.
        private int GetUserChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number.");
                return -1;
            }
        }
    }
}
