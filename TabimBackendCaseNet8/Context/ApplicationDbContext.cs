using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TabimBackendCaseNet8.Entities;

namespace TabimBackendCaseNet8.Context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
