namespace TaskManager.interfaces;

public interface IUserManagement
{
    bool Login(string username, string password);
    void Register(string username, string password, string email);
}