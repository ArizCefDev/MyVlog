using Microsoft.EntityFrameworkCore;
using MyVlog.Models.Entity;

namespace MyVlog.Models.Context
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        {

        }
    }
}
