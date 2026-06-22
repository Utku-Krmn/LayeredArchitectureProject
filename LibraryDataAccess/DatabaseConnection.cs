using LibraryCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryDataAccess;

public class DatabaseConnection : DbContext
{
    #region Tables

    // Define DbSet properties for each entity/table in the database
    public DbSet<Book>? Books { get; set; }
    public DbSet<Author>? Authors { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<User>? Users { get; set; }
    #endregion
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure the database connection string
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=LibraryDb;User Id=sa;Password=UtkuKaraman04;TrustServerCertificate=True;Encrypt=False;"); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure entity relationships and constraints using Fluent API if needed
        base.OnModelCreating(modelBuilder);
    }
}
