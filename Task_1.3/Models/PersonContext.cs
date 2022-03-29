using Microsoft.EntityFrameworkCore;

namespace Task_1._3.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; } = null!;

        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                    new Person { Id = 1, Name = "Tom", Age = 37 },
                    new Person { Id = 2, Name = "Bob", Age = 41 },
                    new Person { Id = 3, Name = "Sam", Age = 24 }
            );
        }
    }
}
