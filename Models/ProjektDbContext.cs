using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace Projekt.Models
{
    public class ProjektDbContext : DbContext
    {
        public ProjektDbContext(DbContextOptions<ProjektDbContext> options): base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Single", Description = "A room assigned to one person. May have one or more beds" },
                new Category { Id = 2, Name = "Double", Description = "A room assigned to two people. May have one or more beds" },
                new Category { Id = 3, Name = "Triple", Description = "A room that can accommodate three persons and has been fitted with three twin beds, one double bed and one twin bed or two double beds." },
                new Category { Id = 4, Name = "Quad", Description = "A room assigned to four people. May have two or more beds." },
                new Category { Id = 5, Name = "Twin", Description = "A room with two twin beds. May be occupied by one or more people." },
                new Category { Id = 6, Name = "Studio", Description = "A room with a studio bed - a couch which can be converted into a bed. May also have an additional bed." },
                new Category { Id = 7, Name = "Suite", Description = "A parlour or living room connected with to one or more bedrooms. (A room with one or more bedrooms and a separate living space.)" },
                new Category { Id = 8, Name = "Connecting rooms", Description = "Rooms with individual entrance doors from the outside and a connecting door between. Guests can move between rooms without going through the hallway." },
                new Category { Id = 9, Name = "Accessible Room", Description = "This room type is mainly designed for disabled guests." }
            );

            modelBuilder.Entity<Room>().HasData(

                new Room { Id = 1, CategoryId = 1, Name = "Room class A", Quantity = 3, Price = 300.00 },
                new Room { Id = 2, CategoryId = 1, Name = "Room class B", Quantity = 5, Price = 200.00 },
                new Room { Id = 3, CategoryId = 1, Name = "Room class C", Quantity = 7, Price = 150.00 },
                new Room { Id = 4, CategoryId = 2, Name = "Room class A", Quantity = 3, Price = 600.00 },
                new Room { Id = 5, CategoryId = 2, Name = "Room class B", Quantity = 5, Price = 400.00 },
                new Room { Id = 6, CategoryId = 2, Name = "Room class C", Quantity = 7, Price = 300.00 },
                new Room { Id = 7, CategoryId = 3, Name = "Room class A", Quantity = 3, Price = 900.00 },
                new Room { Id = 8, CategoryId = 3, Name = "Room class B", Quantity = 5, Price = 600.00 },
                new Room { Id = 9, CategoryId = 3, Name = "Room class C", Quantity = 7, Price = 450.00 }
                );
        }
    }
}
