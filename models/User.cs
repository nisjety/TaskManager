namespace TaskManager.models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; private set; } = string.Empty; 
    public string Email { get; set; } = string.Empty;
    
    public int TaskId { get; set; }
    public UTask? UTask { get; set; }
    
    // Constructor to initialize a User object with mandatory fields
    public User(string username, string password, string email)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Username, password, and email cannot be null or empty.");
        }

        Username = username;
        Password = password;
        Email = email;
    }
}