using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using System.Diagnostics.Metrics;

namespace RS1_2024_25.API.Data
{
    public class ApplicationDbContext(
        DbContextOptions options) : DbContext(options)
    {
        public DbSet<MyAppUser> MyAppUsers { get; set; }
        public DbSet<MyAuthenticationToken> MyAuthenticationTokens { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<SkinType> SkinTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            // opcija kod nasljeđivanja
            // modelBuilder.Entity<NekaBaznaKlasa>().UseTpcMappingStrategy();


            // Set precision for decimal columns

            // TotalAmount in the Order table
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2); // Precision: 18 total digits, 2 decimal places

            // Discount in the OrderItem table
            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Discount)
                .HasPrecision(18, 2); // Precision: 18 total digits, 2 decimal places

            // Price in the OrderItem table
            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasPrecision(18, 2); // Precision: 18 total digits, 2 decimal places

            // Amount in the Payment table
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2); // Precision: 18 total digits, 2 decimal places

            // Price in the Product table
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // Precision: 18 total digits, 2 decimal places
        }

    }
}
