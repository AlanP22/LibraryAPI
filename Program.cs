using LibraryAPI;
using LibraryAPI.Resources;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Added in case of circular reference issue
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); ;
// Added DateOnly to DateTime2 conversion to serializer
builder.Services.AddMvc().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new DateOnlyConverterJSON()));
// configuration of connection to db
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();