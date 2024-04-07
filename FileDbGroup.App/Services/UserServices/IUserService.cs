using FileDbGroup.App.Modals.Users;

namespace FileDbGroup.App.Services.UserServices
{
    internal interface IUserService
    {
        User AddUser(User user);
        void ShowUsers();
        void Update(User user);
        void Delete(int id);
    }
}
