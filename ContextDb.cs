namespace LibraryAPI.Resources;
using Microsoft.EntityFrameworkCore;


public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {

    }
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("Datetime2");
    }

    public DbSet<Book> Book { get; set; } = null!;
}
public class AuthorContext : DbContext
{

    public AuthorContext(DbContextOptions<AuthorContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Author>()
            .Property(e => e.Gender)
            .HasConversion<int>();
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("Datetime2");

    }

    public DbSet<Author> Author { get; set; } = null!;
}

public class BooksAuthorsContext : DbContext
{
    public BooksAuthorsContext(DbContextOptions<BooksAuthorsContext> options) : base(options)
    {

    }

    public DbSet<BookAuthor> BooksAuthors { get; set; } = null!;
}

