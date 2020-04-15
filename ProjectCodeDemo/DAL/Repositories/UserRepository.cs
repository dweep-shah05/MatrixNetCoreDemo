using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : CmnRepository<User>, IUserRepository
    {
        public UserRepository(ProjectCodeDemoDBContext context) : base(context)
        { }

        public IEnumerable<User> GetTopUsersCount(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUserData()
        {
            return _appContext.Users.OrderBy(c => c.Name)
                .ToList();
        }

        public User GetUser(int id)
        {
            return _appContext.Users.Where(x => x.Id == id).FirstOrDefault() ;
                
        }

        public bool SaveUser(User user)
        {
            if (user != null)
            {
                _appContext.Users.Add(user);
            }
            return false;
        }
        public bool EditUser(User user) { return false; }
        public bool DeleteUser(int id) { return false; }
        private ProjectCodeDemoDBContext _appContext => (ProjectCodeDemoDBContext)_context;
    }
}
