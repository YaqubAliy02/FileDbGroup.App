using FileDbGroup.App.Services.UserProcessing;

internal class Program
{
    private static void Main(string[] args)
    {
        UserProcessingService userProcessingService = new UserProcessingService();
        /*Console.Write("Enter name: ");
        string userName = Console.ReadLine();
        userProcessingService.CreateNewUser(userName);
        Console.Write("Update > Enter Id: ");
        int updateId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter new name: ");
        string newName = Console.ReadLine();
        userProcessingService.UpdateUser(updateId,newName);*/
        userProcessingService.DisplayUsers();
        Console.Write("Enter Id for delete >>> ");
        int deleteId = Convert.ToInt32(Console.ReadLine());
        userProcessingService.DeleteUser(deleteId);
        userProcessingService.DisplayUsers();
    }
}