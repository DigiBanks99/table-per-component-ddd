using Microsoft.EntityFrameworkCore;

using TablePerComponent.App.Host;
using TablePerComponent.App.Models;
using TablePerComponent.App.Persistence;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();
builder.AddDbContext();
builder.ConfigureSerialization();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.ApplyMigrations();

    app.MapOpenApi();
}

app.UseHttpsRedirection();

RouteGroupBuilder petRouteGroup = app.MapGroup("pet");
petRouteGroup.MapGet("/", async (PetDbContext dbContext) => await dbContext.Pets.ToListAsync()).WithName("GetPets");
petRouteGroup.MapPost("/bird", async (PetDbContext dbContext, Bird pet) => { await dbContext.Birds.AddAsync(pet); await dbContext.SaveChangesAsync(); }).WithName("CreateBird");
petRouteGroup.MapPost("/cat", async (PetDbContext dbContext, Cat pet) => { await dbContext.Cats.AddAsync(pet); await dbContext.SaveChangesAsync(); }).WithName("CreateCat");
petRouteGroup.MapPost("/dog", async (PetDbContext dbContext, Dog pet) => { await dbContext.Dogs.AddAsync(pet); await dbContext.SaveChangesAsync(); }).WithName("CreateDog");
petRouteGroup.MapGet("/{id}", async (PetDbContext dbContext, int id) => await dbContext.Pets.FindAsync(id)).WithName("GetPetById");
petRouteGroup.MapGet("/{id}/dog", async (PetDbContext dbContext, int id) => await dbContext.Dogs.FindAsync(id)).WithName("GetDogById");
petRouteGroup.MapGet("/{id}/cat", async (PetDbContext dbContext, int id) => await dbContext.Cats.FindAsync(id)).WithName("GetCatById");
petRouteGroup.MapGet("/{id}/bird", async (PetDbContext dbContext, int id) => await dbContext.Birds.FindAsync(id)).WithName("GetBirdById");

app.Run();

