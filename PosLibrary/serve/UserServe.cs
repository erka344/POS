using PosLibrary.model;
using PosLibrary.repo;
using PosLibrary.repo.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.serve
{
    public class UserServe
    {
        private readonly IUserRepo userRepo;

        public UserServe(string connectionString) 
        { 
            userRepo = new UserRepo(connectionString); 
        }

        public User GetUserById(int id)
        {
            return userRepo.GetUserById(id);
        }

        public void AddUser(User user)
        { 
            userRepo.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            userRepo.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            userRepo.DeleteUser(id);
        }

        public User Authentication(string username, string password)
        {
            User user = userRepo.GetUserByName(username);
            if (user == null && user.Password == password)
            {
                return user;
            }
            return null;
        }
    }
}
