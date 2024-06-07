using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    //Override do EF Core com FluentAPI
    protected override void OnModelCreating(ModelBuilder mb)
    {
        //Category
        mb.Entity<Category>().HasKey(c => c.CategoryId);
        mb.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();

        //Relacionamento Category -> Product
        mb.Entity<Category>().HasMany(rel => rel.Products).WithOne(c => c.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);

        //Product
        mb.Entity<Product>().Property(p => p.Name).HasMaxLength(100).IsRequired();
        mb.Entity<Product>().Property(p => p.Description).HasMaxLength(255).IsRequired();
        mb.Entity<Product>().Property(p => p.ImageURL).HasMaxLength(255).IsRequired();
        mb.Entity<Product>().Property(p => p.Price).HasPrecision(12,2);

        //Preenchimento inicial de Category
        mb.Entity<Category>().HasData(
            new Category{
                CategoryId = 1,
                Name = "Material Escolar",
            },
            new Category{
                CategoryId = 2,
                Name = "Acessórios",
            }
        );


        
    }






}