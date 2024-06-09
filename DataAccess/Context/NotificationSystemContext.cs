using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Core.Entities.Concrete;
using Entities.Concretes;

namespace DataAccess.Context
{
    public class NotificationSystemContext : DbContext
    {
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }

        protected IConfiguration Configuration { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }

        public NotificationSystemContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
