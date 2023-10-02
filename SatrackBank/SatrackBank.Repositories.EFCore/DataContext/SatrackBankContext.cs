using Microsoft.EntityFrameworkCore;
using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.Repositories.EFCore.DataContext
{
    public class SatrackBankContext : DbContext
    {
        public SatrackBankContext(DbContextOptions<SatrackBankContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CustomerProducts> CustomerProducts { get; set; }
        public DbSet<Movement> Movement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Properties
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Identification)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Customer>()
                .Property(c => c.CellPhone)
                .IsRequired()
                .HasMaxLength(10);
            modelBuilder.Entity<Customer>()
                .Property(c => c.CreationDate)
                .IsRequired();
            modelBuilder.Entity<Customer>()
              .Property(c => c.LegalRepresentName)
              .IsRequired(false);
            modelBuilder.Entity<Customer>()
              .Property(c => c.LegalRepresentPhone)
              .IsRequired(false);
            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerType)
                .IsRequired();
            modelBuilder.Entity<Customer>()
               .Property(c => c.DocumentType)
               .IsRequired();
            modelBuilder.Entity<Customer>()
               .Property(c => c.Password)
               .IsRequired();

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
               .Property(p => p.Interest)
               .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.CurrentBalance)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.CreationDate)
                .IsRequired();
            modelBuilder.Entity<Product>()
              .Property(p => p.ProductType)
              .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductStatus)
                .IsRequired();

            modelBuilder.Entity<CustomerProducts>()
                .HasKey(cp => new { cp.ProductId, cp.CustomerId });
            modelBuilder.Entity<CustomerProducts>()
                .Property(cp => cp.CustomerId)
                .IsRequired();
            modelBuilder.Entity<CustomerProducts>()
                .Property(cp => cp.ProductId)
                .IsRequired();

            modelBuilder.Entity<Movement>()
               .HasKey(m => m.Id);
            modelBuilder.Entity<Movement>()
               .Property(m => m.MovementType)
               .IsRequired();
            modelBuilder.Entity<Movement>()
               .Property(m => m.ProductId)
               .IsRequired();
            modelBuilder.Entity<Movement>()
               .Property(m => m.Date)
               .IsRequired();
            modelBuilder.Entity<Movement>()
               .Property(m => m.Description)
               .HasMaxLength(200)
               .IsRequired();
            modelBuilder.Entity<Movement>()
             .Property(m => m.PreviousBalance)
             .IsRequired();
            modelBuilder.Entity<Movement>()
             .Property(m => m.Value)
             .IsRequired();

            //Relations
            modelBuilder.Entity<CustomerProducts>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(cp => cp.ProductId);
            modelBuilder.Entity<CustomerProducts>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(cp => cp.CustomerId);
            modelBuilder.Entity<Movement>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(m => m.ProductId);

            //Add data
            string customerId = Guid.NewGuid().ToString();
            string productId = Guid.NewGuid().ToString();
            modelBuilder.Entity<Customer>()
                .HasData(new Customer
                {
                    CellPhone = "3000000000",
                    CreationDate = DateTime.Now,
                    CustomerType = Entities.Enums.CustomerType.Staff,
                    DocumentType = Entities.Enums.DocumentType.CedulaCiudadania,
                    Id = customerId,
                    Identification = "1013666666",
                    Name = "John Doe",
                    Password = "$2a$11$aMvcvJ6t0xJCZZ/TMkfqo.hbGthbZ8l6osZajcJXdEenVKlghatEy"
                });
            modelBuilder.Entity<Product>()
                .HasData(new Product
                {
                    CreationDate = DateTime.Now,
                    CurrentBalance = 1000000,
                    Id = productId,
                    Interest = 0.04,
                    ProductStatus = Entities.Enums.ProductStatus.Active,
                    ProductType = Entities.Enums.ProductType.Ahorros
                });
            modelBuilder.Entity<CustomerProducts>()
                .HasData(new CustomerProducts
                {
                    CustomerId = customerId,
                    ProductId = productId
                });
            modelBuilder.Entity<Movement>()
                .HasData(new Movement
                {
                    ProductId = productId,
                    Date = DateTime.Now,
                    Description = "Creación de cuenta.",
                    Id = Guid.NewGuid().ToString(),
                    MovementType = Entities.Enums.MovementType.Creation,
                    PreviousBalance = 0,
                    Value = 1000000
                });
        }
    }
}
