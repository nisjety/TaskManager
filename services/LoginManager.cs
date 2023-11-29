/*using TaskManager.database;
using TaskManager.utilities;

namespace TaskManager.services
{
    // Manages user login process, interfacing with database and authentication services.
    public class LoginManager
    {
        private readonly SQLiteDatabaseManager _dbManager;
        private readonly AuthenticationService _authService;

        // Initializes a new instance of LoginManager with required dependencies.
        public LoginManager(SQLiteDatabaseManager dbManager)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
            _authService = new AuthenticationService(dbManager);
        }

        // Handles the process of user login including input validation and authentication.
        public int LoginHandler()
        {
            Console.WriteLine("Please enter your username:");
            var username = Console.ReadLine();
            
            // Validates that the username is not null or empty.
            if (username == null)
            {
                Console.WriteLine("Username cannot be empty.");
                return -1;
            }

            Console.WriteLine("Please enter your password:");
            var password = Console.ReadLine();

            // Validates that the password is not null or empty.
            if (password == null)
            {
                Console.WriteLine("Password cannot be empty.");
                return -1;
            }

            try
            {
                // Authenticates the user against stored credentials.
                var user = _dbManager.GetUserByUsername(username);

                if (_authService.VerifyLogin(username, password))
                {
                    Console.WriteLine("Login successful.");
                    return user.UserId; // Returns the authenticated user's ID.
                }
                else
                {
                    Console.WriteLine("Login failed. Username or password is incorrect.");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1; // Indicates failure due to an exception.
            }
        }
    }
}
*/