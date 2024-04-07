using FileDbGroup.App.Brokers.Storages;
using FileDbGroup.App.Modals.Users;

namespace FileDbGroup.App.Services.Identities
{
    internal sealed class IdentityService
    {
        private static IdentityService instance;
        private readonly IStoragesBroker storagesBroker;

        private IdentityService()
        {
            this.storagesBroker = new FileStorageBroker();
        }

        public static IdentityService GetIdentityService()
        {
            if (instance == null)
            {
                instance = new IdentityService();
            }
            return instance;
        }

        public int GetNewId()
        {
            List<User> users = this.storagesBroker.ReadAllUsers();

            return users.Count is not 0
                ? IncrementListUsersId(users)
                : 1;
        }

        private static int IncrementListUsersId(List<User> users)
        {
            return users[users.Count - 1].Id + 1;
            
        }
        
    }
}
