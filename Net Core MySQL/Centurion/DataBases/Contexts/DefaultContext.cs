using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBases.Context
{
    public class DefaultContext : DbContext
    {
		public DefaultContext()
		{
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnexionsStrings.Local);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

