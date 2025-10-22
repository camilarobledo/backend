using EmpresaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EmpresaAPI.Data;

public class EmpresaDbContext : DbContext
{
    public EmpresaDbContext(DbContextOptions<EmpresaDbContext> options) : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, FirstName = "Laura", LastName = "Gómez", Title = "Manager", BirthDate = new DateTime(1980, 5, 12), Country = "Argentina" },
            new Employee { Id = 2, FirstName = "Diego", LastName = "Pérez", Title = "Developer", BirthDate = new DateTime(1992, 7, 22), Country = "Chile" }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Alimentos" },
            new Category { Id = 2, Name = "Electrónica" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Yerba Mate Premium", CategoryId = 1 },
            new Product { Id = 2, Name = "Balanza BLE Big-B", CategoryId = 2 }
        );
    }
}

