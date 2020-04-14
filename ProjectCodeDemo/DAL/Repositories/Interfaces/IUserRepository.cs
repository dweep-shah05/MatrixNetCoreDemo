using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository : ICmnRepository<User>
    {
        IEnumerable<User> GetTopUsersCount(int count);
        IEnumerable<User> GetAllUserData();

        bool SaveUser(User user);
        bool EditUser(User user);
        bool DeleteUser(int id);
    }
}
