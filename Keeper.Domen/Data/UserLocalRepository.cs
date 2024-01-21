using Keeper.Domen.Interfaces;
using Keeper.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keeper.Domen.Data
{


    public class UserLocalRepository : IUserRepository
    {

        private readonly List<User> users = new List<User>();
        public UserLocalRepository()
        {
            //users = new List<User>() { };
            Console.WriteLine("Создался новый объект репозитория!");
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User Create()
        {
           return new User() { Id = 1, Email = "test@test.ru", Login = "test", Password = "test"};
        }

        public IEnumerable<User> Users()
        {
            return users;
        }

        public int CountUsers()
        {
            return users.Count();
        }


    }
}
