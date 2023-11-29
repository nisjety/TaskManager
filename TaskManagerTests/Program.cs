using TaskManagerTests.testModels;

class Program
{
    static void Main(string[] args)
    {
        var userTests = new UserTests();
        userTests.TestUserConstructor_ValidParameters();
        userTests.TestUserConstructor_InvalidParameters();
        
        var uTaskTests = new UTaskTests();
        uTaskTests.TestUTaskConstructor_ValidParameters();
        uTaskTests.TestUTaskConstructor_InvalidParameters();
        uTaskTests.TestUpdateTitle();
        uTaskTests.TestUpdateNote();
        uTaskTests.TestUpdateDueDate();
       
        var inputValidatorTests = new InputValidatorTests();
        inputValidatorTests.TestIsValidUsername();
        inputValidatorTests.TestIsValidPassword();
        inputValidatorTests.TestIsValidEmail();
        inputValidatorTests.TestIsValidTitle();
        inputValidatorTests.TestIsValidNote();
        inputValidatorTests.TestIsValidDate();
        

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}