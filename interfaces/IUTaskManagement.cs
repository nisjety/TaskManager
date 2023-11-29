namespace TaskManager.interfaces
{
    public interface IUTaskManagement
    {
        void DeleteTask(int uTaskId);
        void CreateUserTask(int userId);
    }
}