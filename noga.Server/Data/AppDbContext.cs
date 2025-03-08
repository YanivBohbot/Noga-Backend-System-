using Microsoft.EntityFrameworkCore;
using NOGA.Server.Models;

namespace NOGA.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contacts> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            DateTime fixedDateTime = new DateTime(2023, 1, 1);
            base.OnModelCreating(modelBuilder);


            // הגדרת יחסים בין הטבלאות
            modelBuilder.Entity<Customers>()
                .HasMany(c => c.Addresses)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Customers>()
                .HasMany(c => c.Contacts)
                .WithOne(co => co.Customer)
                .HasForeignKey(co => co.CustomerId);


            // הגדרת נתוני דוגמה
            var customers = new List<Customers>
                {
                    new Customers
                    {
                        Id = 1,
                        isDeleted = false,
                        CreatedAt = fixedDateTime,
                        Name = "John Doe",
                        CustomerNumber = "123456789"
                    },
                    new Customers
                    {
                        Id = 2,
                        isDeleted = false,
                        CreatedAt = fixedDateTime,
                        Name = "Jane Smith",
                        CustomerNumber = "987654321"
                    },
                    new Customers
                    {
                        Id = 3,
                        isDeleted = false,
                        CreatedAt = fixedDateTime,
                        Name = "Alice Johnson",
                        CustomerNumber ="456789123"
                    },
                    new Customers
                    {
                        Id = 4,
                        isDeleted = false,
                        CreatedAt = fixedDateTime,
                        Name = "Bob Brown",
                        CustomerNumber = "789123456"
                    },
                    new Customers
                    {
                        Id = 5,
                        isDeleted = false,
                        CreatedAt = fixedDateTime,
                        Name = "Charlie Davis",
                        CustomerNumber = "321654987"
                    },
                    new Customers
                    {
                        Id = 6,
                        isDeleted = false,
                        CreatedAt =fixedDateTime,
                        Name = "Eve Wilson",
                        CustomerNumber = "654987321"
                    }
                };

            modelBuilder.Entity<Customers>().HasData(customers);

            var addresses = new List<Address>
                    {
                        // כתובות עבור John Doe
                        new Address { Id = 1, isDeleted = false, CreatedAt = fixedDateTime, City = "Tel Aviv", Street = "Herzl 12", CustomerId = 1 },
                        new Address { Id = 2, isDeleted = false, CreatedAt = fixedDateTime, City = "Jerusalem", Street = "King David 5", CustomerId = 1 },

                        // כתובות עבור Jane Smith
                        new Address { Id = 3, isDeleted = false, CreatedAt = fixedDateTime, City = "Haifa", Street = "Ben Gurion 8", CustomerId = 2 },

                        // כתובות עבור Alice Johnson
                        new Address { Id = 4, isDeleted = false, CreatedAt = fixedDateTime, City = "Beer Sheva", Street = "Allenby 3", CustomerId = 3 },
                        new Address { Id = 5, isDeleted = false, CreatedAt = fixedDateTime, City = "Eilat", Street = "Rothschild 7", CustomerId = 3 }
                    };
             

            modelBuilder.Entity<Address>().HasData(addresses);

         

            var contacts = new List<Contacts>
                    {
                        // אנשי קשר עבור John Doe
                        new Contacts { Id = 1, isDeleted = false, CreatedAt = fixedDateTime, FullName = "Contact 1 for John", OfficeNumber = "03-1234567", Email = "contact1@example.com", CustomerId = 1 },
                        new Contacts { Id = 2, isDeleted = false, CreatedAt = fixedDateTime, FullName = "Contact 2 for John", OfficeNumber = "03-2345678", Email = "contact2@example.com", CustomerId = 1 },

                        // אנשי קשר עבור Jane Smith
                        new Contacts { Id = 3, isDeleted = false, CreatedAt = fixedDateTime, FullName = "Contact 1 for Jane", OfficeNumber = "02-3456789", Email = "contact3@example.com", CustomerId = 2 },
                       

                        // אנשי קשר עבור Alice Johnson
                        new Contacts { Id = 4, isDeleted = false, CreatedAt = fixedDateTime, FullName = "Contact 1 for Alice", OfficeNumber = "04-4567890", Email = "contact4@example.com", CustomerId = 3 },
                        new Contacts { Id = 5, isDeleted = false, CreatedAt = fixedDateTime, FullName = "Contact 2 for Alice", OfficeNumber = "04-5678901", Email = "contact5@example.com", CustomerId = 3 },
                        new Contacts { Id = 6, isDeleted = false, CreatedAt = fixedDateTime, FullName = "Contact 2 for Alice", OfficeNumber = "04-5678901", Email = "contact5@example.com", CustomerId = 6 }
            };

            modelBuilder.Entity<Contacts>().HasData(contacts);
        }



    }





}
