using AnApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace AnApp.Server.Models

{
   
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }

            public DbSet<Agent> Agents => Set<Agent>();
            public DbSet<Department> Departments => Set<Department>();
            public DbSet<Upload> Uploads => Set<Upload>();
            public DbSet<User> Users => Set<User>();
        }
    }

