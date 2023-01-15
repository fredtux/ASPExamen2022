using Microsoft.EntityFrameworkCore;

namespace Examen2022.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=examen2022;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, Title = "C1" },
                new Category {Id = 2, Title = "C2" },
                new Category {Id = 3, Title = "C3" }
            );

            modelBuilder.Entity<Article>().HasData(
                new Article {Id = 1, Title = "T1", Content = "CO1", Date = DateTime.Now, CategoryId = 1 },
                new Article {Id = 2, Title = "T2", Content = "CO2", Date = DateTime.Now, CategoryId = 2 },
                new Article {Id = 3, Title = "T3", Content = "CO3", Date = DateTime.Now, CategoryId = 2 }
            );
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
