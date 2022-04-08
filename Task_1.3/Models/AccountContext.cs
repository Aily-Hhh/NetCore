using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Task_1._3.Models
{
    public class AccountContext : IdentityDbContext<Account>
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> People { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("People").HasData(
                    new Person { Id = 1, Name = "Tom", Age = 37 },
                    new Person { Id = 2, Name = "Bob", Age = 41 },
                    new Person { Id = 3, Name = "Sam", Age = 24 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
