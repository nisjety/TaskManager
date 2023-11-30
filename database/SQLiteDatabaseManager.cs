using Microsoft.EntityFrameworkCore;
using TaskManager.models;
using TaskManager.interfaces;

namespace TaskManager.database;

public class SQLiteDatabaseManager : IDataManagement
{
    private readonly DbContext _context;

    public SQLiteDatabaseManager(DbContext context)
    {
        _context = context;
    }

    public User GetUserByUsername(string username)
    {
        try
        {
            return _context.Set<User>().FirstOrDefault(u => u.Username == username);
        }
        catch (Exception ex)
        {
            // Handle exception
            throw new InvalidOperationException("Error fetching user by username.", ex);
        }
    }

    public bool UsernameExists(string username)
    {
        return !UsernameMissing(username) && _context.Set<User>().Any(u => u.Username == username);
    }

    public bool EmailExists(string email)
    {
        return !EmailMissing(email) && _context.Set<User>().Any(u => u.Email == email);
    }

    public void CreateUser(User user)
    {
        if (!UsernameMissing(user.Username) && !EmailMissing(user.Email))
        {
            try
            {
                _context.Set<User>().Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new InvalidOperationException("Error creating user.", ex);
            }
        }
    }

    public bool CreateUserTask(Task task)
    {
        throw new NotImplementedException();
    }

    public bool CreateUserTask(UTask utask)
    {
        try
        {
            _context.Set<UTask>().Add(utask);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            // Handle exception
            throw new InvalidOperationException("Error creating user task.", ex);
        }

        return false;
    }

    public bool DeleteUserTaskById(int taskId)
    {
        try
        {
            var task = _context.Set<Task>().Find(taskId);
            if (task != null)
            {
                _context.Set<Task>().Remove(task);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            throw new InvalidOperationException("Error deleting user task.", ex);
        }

        return false;
    }

    public IEnumerable<Task> GetUserTasksForUser(int userId)
    {
        try
        {
            return _context.Set<Task>().Where(t => t.Id == userId).ToList();
        }
        catch (Exception ex)
        {
            // Handle exception
            throw new InvalidOperationException("Error fetching tasks for user.", ex);
        }
    }

    private bool UsernameMissing(string? username)
    {
        return string.IsNullOrEmpty(username);
    }

    private bool EmailMissing(string? email)
    {
        return string.IsNullOrEmpty(email);
    }
}