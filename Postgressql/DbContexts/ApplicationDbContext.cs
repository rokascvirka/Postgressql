
using Microsoft.EntityFrameworkCore;
using Postgressql.Models;

namespace Postgressql.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<TestItem> TestItems { get; set; }


    }
}
