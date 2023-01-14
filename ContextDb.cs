namespace LibraryAPI.Resources;
using Microsoft.EntityFrameworkCore;


public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // added conversion of string values (male/female) to bit
        modelBuilder
             .Entity<Author>()
             .Property(e => e.Gender)
             .HasConversion<GenderToNumericCoverter>();
        // relationship configuration by fluentAPI
        modelBuilder.Entity<Book>()
            .HasOne(p => p.Author)
            .WithMany(b => b.Books);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        // added DateOnly to DateTime2 conversion
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("Datetime2");
    }

    public DbSet<Author> Author { get; set; } = null!;
    public DbSet<Book> Book { get; set; } = null!;
}


