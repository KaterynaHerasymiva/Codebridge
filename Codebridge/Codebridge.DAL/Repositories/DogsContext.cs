using Codebridge.BLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codebridge.DAL.Repositories;

public class DogsContext : DbContext
{
    public DbSet<Dog>? Dogs { get; set; }

    public DogsContext(DbContextOptions<DogsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Dog>().HasKey(d => d.Id);
        modelBuilder.Entity<Dog>().HasIndex(d => d.Name).IsUnique();

        modelBuilder.Entity<Dog>().HasData(new Dog(1, "Neo", "red&amber", 22, 32),
            new Dog(2, "Jessy", "black&white", 7, 14));
    }
}