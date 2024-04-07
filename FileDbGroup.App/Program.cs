using FileDbGroup.App.Services.UserProcessing;

internal class Program
{
    private static void Main(string[] args)
    {
       UserProcessingService userProcessingService = new UserProcessingService();
        Console.Write("Enter name: ");
        string userName = Console.ReadLine();
        userProcessingService.CreateNewUser(userName);
    }
}