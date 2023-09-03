using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.DataBaseContexts
{
    public class DefaultDataBase : DbContext
    {
		public DefaultDataBase()
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

