using FileDbGroup.App.Modals.Users;
using FileDbGroup.App.Services.Identities;
using FileDbGroup.App.Services.UserServices;

namespace FileDbGroup.App.Services.UserProcessing
{
    internal class UserProcessingService
    {
        private readonly IUserService userService;
        private readonly IdentityService identityService;

        public UserProcessingService()
        {
            this.userService = new UserService();
            this.identityService = IdentityService.GetIdentityService();
        }

        public void CreateNewUser(string name)
        {
            User user = new User();
            user.Id = this.identityService.GetNewId();
            user.Name = name;
            this.userService.AddUser(user);
        }

        public void DisplayUsers()
        {
            this.userService.ShowUsers();
        }

        public void UpdateUser(int id, string name)
        {
            User user = new User()
            {
                Id = id,
                Name = name
            };
            this.userService.Update(user);
        }

        public void DeleteUser(int id)
        {
            this.userService.Delete(id);
        }
    }
}