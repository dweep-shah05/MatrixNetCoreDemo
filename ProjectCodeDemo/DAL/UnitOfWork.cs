using DAL.Repositories;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ProjectCodeDemoDBContext _context;

        IUserRepository _users;
        public UnitOfWork(ProjectCodeDemoDBContext context)
        {
            _context = context;
        }

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                    _users = new UserRepository(_context);

                return _users;
            }
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
