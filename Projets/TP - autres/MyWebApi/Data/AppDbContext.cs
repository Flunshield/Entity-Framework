using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<PriceHistory> PriceHistories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuration des tables
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<PriceHistory>().ToTable("PriceHistories");

        // Configuration des relations et contraintes pour Category
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.HasIndex(e => e.Name).IsUnique();
            
            // Configuration des données initiales pour Category
            entity.HasData(
                new Category { Id = 1, Name = "Électronique", Description = "Produits électroniques et gadgets" },
                new Category { Id = 2, Name = "Vêtements", Description = "Articles vestimentaires pour hommes et femmes" },
                new Category { Id = 3, Name = "Alimentation", Description = "Produits alimentaires et boissons" }
            );
        });

        // Configuration des relations et contraintes pour Customer
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Adresse).IsRequired().HasMaxLength(200);
            
            // Configuration des données initiales pour Customer
            entity.HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Jean",
                    LastName = "Dupont",
                    Email = "jean.dupont@example.com",
                    PhoneNumber = "0123456789",
                    Adresse = "123 Rue de Paris, 75001 Paris"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Marie",
                    LastName = "Martin",
                    Email = "marie.martin@example.com",
                    PhoneNumber = "0987654321",
                    Adresse = "456 Avenue des Champs-Élysées, 75008 Paris"
                }
            );
        });

        // Configuration des relations et contraintes pour Order
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.OrderDate).IsRequired();
            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.Notes).HasMaxLength(500);

            // Relation avec Customer (un-à-plusieurs)
            entity.HasOne(e => e.Customer)
                  .WithMany(c => c.Orders)
                  .HasForeignKey(e => e.CustomerId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
                new Order
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    DeliveryDate = DateTime.UtcNow.AddDays(5),
                    Status = OrderStatus.Pending,
                    CustomerId = 1,
                    Notes = "Livrer entre 14h et 16h"
                }
            );
        });

        // Configuration des relations et contraintes pour OrderItem
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.UnitPrice).IsRequired().HasPrecision(18, 2);

            // Relation avec Order (un-à-plusieurs)
            entity.HasOne(e => e.Order)
                  .WithMany(o => o.OrderItems)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Relation avec Product (un-à-plusieurs)
            entity.HasOne(e => e.Product)
                  .WithMany(p => p.OrderItems)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);
           
        });

        // Configuration des relations et contraintes pour Product
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Price).IsRequired().HasPrecision(18, 2);
            entity.Property(e => e.Stock).IsRequired();
            entity.Property(e => e.Note).IsRequired();

            // Relation avec Category (un-à-plusieurs)
            entity.HasOne(e => e.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(e => e.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => e.Name);
            
            // Configuration des données initiales pour Product
            entity.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Smartphone XYZ",
                    Description = "Le dernier smartphone avec caméra haute résolution",
                    Price = 699.99m,
                    Stock = 50,
                    CategoryId = 1,
                    Note = 4
                },
                new Product
                {
                    Id = 2,
                    Name = "T-shirt Premium",
                    Description = "T-shirt en coton bio de haute qualité",
                    Price = 29.99m,
                    Stock = 100,
                    CategoryId = 2,
                    Note = 5
                },
                new Product
                {
                    Id = 3,
                    Name = "Café Arabica",
                    Description = "Café en grains de qualité supérieure",
                    Price = 12.99m,
                    Stock = 200,
                    CategoryId = 3,
                    Note = 4
                }
            );
        });
        
        // Configuration des relations et contraintes pour PriceHistory
        modelBuilder.Entity<PriceHistory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Price).IsRequired().HasPrecision(18, 2);
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate);

            entity.Property(e => e.ProductId).IsRequired();
            
            // Relation avec Product (un-à-plusieurs)
            entity.HasOne(e => e.Product)
                  .WithMany(p => p.PriceHistory)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            
            // Configuration des données initiales pour PriceHistory
            entity.HasData(
                new PriceHistory
                {
                    Id = 1,
                    ProductId = 1,
                    Price = 799.99m,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2023, 3, 31)
                },
                new PriceHistory
                {
                    Id = 2,
                    ProductId = 1,
                    Price = 699.99m,
                    StartDate = new DateTime(2023, 4, 1),
                    EndDate = null
                },
                new PriceHistory
                {
                    Id = 3,
                    ProductId = 2,
                    Price = 34.99m,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2023, 5, 31)
                },
                new PriceHistory
                {
                    Id = 4,
                    ProductId = 2,
                    Price = 29.99m,
                    StartDate = new DateTime(2023, 6, 1),
                    EndDate = null
                }
            );
        });
    }
}