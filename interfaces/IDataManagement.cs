using TaskManager.models;

namespace TaskManager.interfaces;

public interface IDataManagement
{
    User GetUserByUsername(string username);
    bool UsernameExists(string username);
    bool EmailExists(string email);
    void CreateUser(User user);
    bool CreateUserTask(Task task);
    bool DeleteUserTaskById(int taskId);
    IEnumerable<Task> GetUserTasksForUser(int userId);
}
