using System;
using System.Collections.Generic;
using System.Text;
using UnibetBLL.Models;
using UnibetDAL;
using UnibetInterfaces;

namespace UnibetBLL
{
    public class UserLogic
    {
        public UserLogic(IUserContext context)
        {
            Repository = new UserRepository(context);
        }

        private UserRepository Repository { get; }

        public void AddUser(string username, string password, string email)
        {
            var person = new User
            { Username = username, Password = password, Email = email, BankBalance = 0.00m };
            Repository.Add(person);
        }

        public void Edit(int id, string username, string email, decimal amount)
        {
            var person = new User
            {Id = id, Username = username, Email = email, BankBalance = amount };
            Repository.Edit(person);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return Repository.GetAll();
        }
    }
}
