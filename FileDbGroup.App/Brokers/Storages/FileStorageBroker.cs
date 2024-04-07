﻿using FileDbGroup.App.Modals.Users;
using System.Diagnostics;

namespace FileDbGroup.App.Brokers.Storages
{
    internal class FileStorageBroker : IStoragesBroker
    {
        private const string FILEPATH = "../../../Users.txt";
        public FileStorageBroker()
        {
            EnsureFileExists();
        }
        public User AddUser(User user)
        {
            string userLine = $"{user.Id}*{user.Name}\n";

            File.AppendAllText(FILEPATH, userLine);
            return user;
        }
        public void UpdateUser(User user)
        {
            List<User> users = ReadAllUsers();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == user.Id)
                {
                    users[i] = user;
                    break;
                }
            }
            File.WriteAllText(FILEPATH, string.Empty);
            foreach (User user1 in users)
            {
                AddUser(user1);
            }
        }
        public List<User> ReadAllUsers()
        {
            string[] userLines = File.ReadAllLines(FILEPATH);
            List<User> users = new List<User>();

            foreach(string userLine  in userLines)
            {
                string[] userProperties = userLine.Split("*");
                User user = new User
                {
                    Id = Convert.ToInt32(userProperties[0]),
                    Name = userProperties[1],
                };
                users.Add(user);
            }

            return users;
        }
        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FILEPATH);
            if (fileExists is false)
            {
                File.Create(FILEPATH).Close();
            }
        }

        public void DeleteUser(int id)
        {
            List<User> users = this.ReadAllUsers();
            File.WriteAllText(FILEPATH, string.Empty);

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id != id)
                {
                    this.AddUser(users[i]);
                }
            }
        }

    }
}
