using Microsoft.EntityFrameworkCore;

using TablePerComponent.App.Models;
using TablePerComponent.App.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
const string connectionName = "database";

var connectionString = builder.Configuration.GetConnectionString(connectionName) ??
                       throw new InvalidOperationException(
                           $"Connection String for '{connectionName}' was not found in config");
builder.Services.AddDbContext<PetDbContext>(options => { options.UseSqlServer(connectionString); });
builder.EnrichSqlServerDbContext<PetDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    /*using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<PetDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
    await dbContext.Database.MigrateAsync();*/

    app.MapOpenApi();
}

app.UseHttpsRedirection();

var petRouteGroup = app.MapGroup("pet");
petRouteGroup.MapGet("/", async (PetDbContext dbContext) => await dbContext.Pets.ToListAsync()).WithName("GetPets");
petRouteGroup.MapPost("/bird", async (PetDbContext dbContext, Bird pet) => { await dbContext.Birds.AddAsync(pet); await dbContext.SaveChangesAsync(); }).WithName("CreateBird");
petRouteGroup.MapPost("/cat", async (PetDbContext dbContext, Cat pet) => { await dbContext.Cats.AddAsync(pet); await dbContext.SaveChangesAsync(); }).WithName("CreateCat");
petRouteGroup.MapPost("/dog", async (PetDbContext dbContext, Dog pet) => { await dbContext.Dogs.AddAsync(pet); await dbContext.SaveChangesAsync(); }).WithName("CreateDog");
petRouteGroup.MapGet("/{id}", async (PetDbContext dbContext, int id) => await dbContext.Pets.FindAsync(id)).WithName("GetPetById");
petRouteGroup.MapGet("/{id}/dog", async (PetDbContext dbContext, int id) => await dbContext.Dogs.FindAsync(id)).WithName("GetDogById");
petRouteGroup.MapGet("/{id}/cat", async (PetDbContext dbContext, int id) => await dbContext.Cats.FindAsync(id)).WithName("GetCatById");
petRouteGroup.MapGet("/{id}/bird", async (PetDbContext dbContext, int id) => await dbContext.Birds.FindAsync(id)).WithName("GetBirdById");

app.Run();