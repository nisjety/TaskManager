using TaskManager.models;
namespace TaskManagerTests.testModels;

public class UserTests
{
    public void TestUserConstructor_ValidParameters()
    {
        var user = new User("testUser", "testPass", "test@example.com");
        Console.WriteLine(user != null ? "id Pass" : "id Fail");
        Console.WriteLine(user?.Username == "" ? "Username Pass" : "Username Fail");// making it fail to see if it works
        Console.WriteLine(user?.Password == "testPass" ? "Password Pass" : "Password Fail");
        Console.WriteLine(user?.Email == "test@example.com" ? "Email Pass" : "Email Fail");
    }

    public void TestUserConstructor_InvalidParameters()
    {
        try
        {
            var user = new User("", "testPass", "test@example.com");
            Console.WriteLine("Fail");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Pass");
        }
    }
}
//test Passed

