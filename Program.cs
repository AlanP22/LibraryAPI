using LibraryAPI;
using LibraryAPI.Resources;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMvc().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new DateOnlyConverterJSON()));
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));
builder.Services.AddDbContext<AuthorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));
builder.Services.AddDbContext<BooksAuthorsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();