using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public interface IProjectDBInitializer
    {
        Task SeedAsync();
    }

    public class ProjectDBInitializer : IProjectDBInitializer
    {
        private readonly ProjectCodeDemoDBContext _context;
        private readonly ILogger _logger;

        public ProjectDBInitializer(ProjectCodeDemoDBContext context, ILogger<ProjectDBInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Users.AnyAsync())
            {
                _logger.LogInformation("Seeding initial data");

                User user_1 = new User
                {
                    Name = "John Doe",
                    Email = "johndoe@xyz.com",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                User user_2 = new User
                {
                    Name = "John Doe2",
                    Email = "johndoe2@xyz.com",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                _context.Users.Add(user_1);
                _context.Users.Add(user_2);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Seeding initial data completed");
            }
        }

    }

}
