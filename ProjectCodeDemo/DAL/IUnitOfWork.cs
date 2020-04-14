using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        int SaveChanges();
    }
}
