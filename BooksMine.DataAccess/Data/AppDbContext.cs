using BooksMine.Models;
using BooksMine.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksMineWeb.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> appUsers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Publisher> publishers { get; set; }

        public DbSet<Author> authors { get; set; }

        public DbSet<City> cities { get; set; }

        public DbSet<Country> countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { 
                    Id = 1,
                    name = "Horror" ,
                    description = "This Category Include The Scariest Adventures One Can Ever Expreince"
                },
                new Category {
                    Id = 2, 
                    name = "Drama",
                    description = "This Category Include The Greatest Novels Ever Wrote in History"

                },
                new Category { 
                    Id = 3, 
                    name = "Sci-FI",
                    description = "This Category Include Adventures Beyond Imagination"

                }
            );

            // Seed cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, name = "London" },
                   new City { Id = 2, name = "Paris" }
            );


            // Seed countries
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, name = "England" },
                   new Country { Id = 2, name = "France" }
            );

            // Seed publishers
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { 
                    Id = 1, 
                    name = "pegasus",
                    address = "Sheraton House, Castle Park, Cambridge, CB3 0AX,",
                    email = "editors@pegasuspublishers.com",
                    phone = "01223665568",
                    cityId = 1,
                    countryId = 1,
                }
            );

            // Seed authors
            modelBuilder.Entity<Author>().HasData(
                new Author { 
                    Id = 1,
                    firstName = "Charles",
                    lastName = "Dickens",
                    cityId = 1,
                    countryId = 1
                },
                 new Author
                 {
                     Id = 2,
                     firstName = "William",
                     lastName = "Shakespear",
                     cityId = 1,
                     countryId = 1
                 }
            );

            // Seed books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    title = "A Tale of Two Cities",
                    description = "A Tale of Two Cities is a historical novel published in 1859 by English author Charles Dickens, set in London and Paris before and during the French Revolution.",
                    edition = 10,
                    catId = 2,
                    price = 560,
                    noInStock = 5,
                    authId= 1,
                    pubId= 1,
                    imgUrl = "test.jpg"
                },
                new Book
                {
                    Id = 2,
                    title = "Julius Caesar",
                    description = "The Tragedy of Julius Caesar (First Folio title: The Tragedie of Ivlivs Cæsar), often shortened to Julius Caesar, is a history play and tragedy by William Shakespeare first performed in 1599.",
                    edition = 9,
                    catId = 2,
                    price = 360,
                    noInStock = 12,
                    authId = 2,
                    pubId = 1,
                    imgUrl = "test2.jpg"

                }

            );

        }
    }
}
