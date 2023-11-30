namespace TaskManager.interfaces;

{
    User GetUserByUsername(string username);
    bool UsernameExists(string username);
    bool EmailExists(string email);
    void CreateUser(User user);
    void CreateUserTask(Task task);
    void DeleteUserTaskById(int taskId);
    IEnumerable<Task> GetUserTasksForUser(int userId);
}
