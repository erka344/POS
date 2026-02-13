using PosLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.repo.@interface
{
    public interface IUserRepo
    {
        public void AddUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);
        public List<User> GetUsers();
        public User GetUserById(int userId);
        public User GetUserByName(string name);
    }
}
