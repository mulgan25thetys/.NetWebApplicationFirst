using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Domain;

namespace Web.Data
{
    public class WebContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=Ecommerce.Api.Db;
                                           Integrated Security=True;");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");

            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<IdentityUserLogin<string>>(id => id.HasKey( k => k.UserId ) );
            modelBuilder.Entity<IdentityUserRole<string>>(ur => ur.HasKey(k => new
            {
                k.RoleId,
                k.UserId
            }));
            modelBuilder.Entity<IdentityUserToken<string>>(ut => ut.HasKey(k => new
            {
                k.UserId, k.LoginProvider,
            }));
        }
    }
}
