using DotNet8SpecificationPattern.Data;
using DotNet8SpecificationPattern.Entities;
using DotNet8SpecificationPattern.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "Games"));

builder.Services.AddScoped<IGameRepository, GameRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    SeedData(context);
}

app.Run();


void SeedData(DataContext context)
{
    if (!context.Genres.Any())
    {
        var rpgGenre = new Genre { Name = "RPG" };
        var actionGenre = new Genre { Name = "Action" };

        var skyrim = new Game { Name = "Skyrim", Genre = rpgGenre };
        var witcher = new Game { Name = "Witcher 3", Genre = rpgGenre, DLCs  =
            [new DLC { Description = "description", Email = "justanemail@gamlo.com", Name = "DCVL" }]
        };
        var cod = new Game { Name = "Callo Of Duty", Genre = actionGenre };

        context.AddRange(rpgGenre, actionGenre);
        context.AddRange(skyrim, witcher, cod);
        context.SaveChanges();
    }

}
