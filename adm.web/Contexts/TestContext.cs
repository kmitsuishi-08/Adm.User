using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adm.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Adm.Web.Contexts
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionUser> PermissionUsers { get; set; }

    }
}
