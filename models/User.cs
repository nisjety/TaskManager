namespace TaskManager.models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; private set; }
    public string Email { get; set; }
    
    public int TaskId { get; set; }
    public UTask? UTask { get; set; }
    
    // Constructor to initialize a User object with mandatory fields
    public User(string username, string password, string email)
    {//using method IsNullOrWhiteSpace to check if the strings are not null or has whitespace characters if so it throws an error
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Username, password, and email cannot be null or empty.");
        }
        

        Username = username;
        Password = password;
        Email = email;
    }
}