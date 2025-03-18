using Microsoft.EntityFrameworkCore;

using TablePerComponent.App.Host;
using TablePerComponent.App.Models;
using TablePerComponent.App.Persistence;
using TablePerComponent.App.RouteHandlers;

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
petRouteGroup.MapGet("/", PetRouteHandlers.HandleViewPets).WithName("GetPets");
petRouteGroup.MapPost("/bird", BirdRouteHandlers.HandleAddPet).WithName("CreateBird");
petRouteGroup.MapPost("/cat", CatRouteHandlers.HandleAddPet).WithName("CreateCat");
petRouteGroup.MapPost("/dog", DogRouteHandlers.HandleAddPet).WithName("CreateDog");
petRouteGroup.MapGet("/{id}", PetRouteHandlers.HandleViewPet).WithName("GetPetById");
petRouteGroup.MapGet("/{id}/dog", DogRouteHandlers.HandleViewPet).WithName("GetDogById");
petRouteGroup.MapGet("/{id}/cat", CatRouteHandlers.HandleViewPet).WithName("GetCatById");
petRouteGroup.MapGet("/{id}/bird", BirdRouteHandlers.HandleViewPet).WithName("GetBirdById");

app.Run();

