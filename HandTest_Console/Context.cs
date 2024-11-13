using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace HandTest_Console;

public class Context : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Drug> Drugs { get; set; }
    public DbSet<DrugItem> DrugsItems { get; set; }
    public DbSet<DrugStore> DrugStores { get; set; }
    public Context()
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DrugStore>()
            .OwnsOne(d => d.Address, a =>
            {
                a.Property(p => p.City).HasColumnName("City");
                a.Property(p => p.Street).HasColumnName("Street");
                a.Property(p => p.House).HasColumnName("House");
                a.Property(p => p.PostalCode).HasColumnName("Postcode");
                a.Property(p => p.Country).HasColumnName("Country");
            });

        // Additional configurations, if needed
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=postgres;username=postgres;password=12345;");
    }
    
}