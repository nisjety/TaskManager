namespace TaskManager.database;

#if false
public class SQLiteDatabaseManager : IDataManagement
{
    private readonly DbContext _context;

    public SQLiteDatabaseManager(DbContext context)
    {
        _context = context;
    }

    public User GetUserByUsername(string username)
    {
        return _context.Set<User>().FirstOrDefault(u => u.UserName == username);
    }

    public bool UsernameExists(string username)
    {
        return _context.Set<User>().Any(u => u.UserName == username);
    }

    public bool EmailExists(string email)
    {
        return _context.Set<User>().Any(u => u.Email == email);
    }

    public void CreateUser(User user)
    {
        _context.Set<User>().Add(user);
        _context.SaveChanges();
    }

    public void CreateUserTask(Task task)
    {
        _context.Set<Task>().Add(task);
        _context.SaveChanges();
    }

    public void DeleteUserTaskById(int taskId)
    {
        var task = _context.Set<Task>().Find(taskId);
        if (task != null)
        {
            _context.Set<Task>().Remove(task);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Task> GetUserTasksForUser(int userId)
    {
        return _context.Set<Task>().Where(t => t.UserId == userId).ToList();
    }
}
#endif
